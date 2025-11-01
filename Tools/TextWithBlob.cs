namespace Ngaq.Core.Tools;

using System;
using System.Buffers;
using System.Text;

/// <summary>
/// 格式：| UInt64頭(大端, 定義文本部分ʹ長度) | UTF-8 文本 | 二进制负载 |
/// </summary>
public interface ITextWithBlob{
	public u64 HeaderBytesLen{get;set;}
	public string Text { get;set;}
	public ReadOnlyMemory<byte> Blob { get;set;}
}

public class TextWithBlob: ITextWithBlob{
	public u64 HeaderBytesLen{get;set;}
	public string Text { get;set;}
	public ReadOnlyMemory<byte> Blob { get;set;}
	public TextWithBlob(str Text, ReadOnlyMemory<byte> Blob){
		this.HeaderBytesLen = (u64)Encoding.UTF8.GetByteCount(Text);
		this.Text = Text;
		this.Blob = Blob;
	}




}

public static class ToolTextWithBlob {
	private const i32 HeaderLen = 8;

	#region --- 打包 ---
	/// <summary>
	/// 将 text + binary 打包成 BlobWithText 实例（还未序列化）。
	/// </summary>
	public static TextWithBlob Pack(string Text, ReadOnlyMemory<byte> Blob){
		return new TextWithBlob(Text, Blob);
	}

	/// <summary>
	/// 序列化成字节数组，可直接写入 NetworkStream。
	/// </summary>
	public static byte[] ToByteArr<TSelf>(
		this TSelf z
	)where TSelf:ITextWithBlob{
		i32 textByteCount = z.HeaderBytesLen.ToInt();
		u64 total = HeaderLen + (u64)textByteCount + (u64)z.Blob.Length;
		byte[] arr = new byte[total];

		// 写头（固定小端）
		System.Buffers.Binary.BinaryPrimitives.WriteUInt64BigEndian(arr.AsSpan(0, HeaderLen), (ulong)textByteCount);

		// 写 text
		Encoding.UTF8.GetBytes(z.Text, arr.AsSpan(HeaderLen, textByteCount));
		// 写 binary
		z.Blob.CopyTo(arr.AsMemory(HeaderLen + textByteCount));
		return arr;
	}

	/// <summary>
	/// 序列化到 IBufferWriter，适合与 System.IO.Pipelines 搭配。
	/// </summary>
	public static TSelf WriteTo<TSelf>(
		this TSelf z
		,IBufferWriter<byte> Writer
	)where TSelf:ITextWithBlob
	{
		//int textByteCount = Encoding.UTF8.GetByteCount(z.Text);
		i32 textByteCount = z.HeaderBytesLen.ToInt();
		Span<byte> span = Writer.GetSpan(HeaderLen + textByteCount + z.Blob.Length);

		// header
		System.Buffers.Binary.BinaryPrimitives.WriteUInt64BigEndian(span, (ulong)textByteCount);
		span = span.Slice(HeaderLen);

		// text
		Encoding.UTF8.GetBytes(z.Text, span);
		span = span.Slice(textByteCount);

		// binary
		z.Blob.Span.CopyTo(span);

		Writer.Advance(HeaderLen + textByteCount + z.Blob.Length);
		return z;
	}
	#endregion

	#region --- 解包 ---
	/// <summary>
	/// 从完整的数据块解析，成功返回实例，否则抛 ArgumentException。
	/// </summary>
	public static TextWithBlob Parse(ReadOnlyMemory<byte> Data) {
		if (Data.Length < HeaderLen){
			throw new ArgumentException("数据长度不足 8 字节头部");
		}

		ulong textByteCountU = System.Buffers.Binary.BinaryPrimitives.ReadUInt64BigEndian(Data.Span.Slice(0, HeaderLen));

		int textByteCount = checked((int)textByteCountU);
		int totalNeed = HeaderLen + textByteCount;
		if (Data.Length < totalNeed){
			throw new ArgumentException("数据长度不足，文本域尚未完整");
		}
		string text = Encoding.UTF8.GetString(Data.Span.Slice(HeaderLen, textByteCount));
		ReadOnlyMemory<byte> binary = Data.Slice(totalNeed);

		return new TextWithBlob(text, binary);
	}

	/// <summary>
	/// 尝试从缓冲区头部解析一个包，如果长度不足返回 null，且不消耗缓冲区。
	/// 适合先收几个字节再判断的场景。
	/// </summary>
	public static TextWithBlob? TryParse(ref ReadOnlySequence<byte> Buffer) {
		if (Buffer.Length < HeaderLen){
			return null;
		}

		ulong textByteCountU = System.Buffers.Binary.BinaryPrimitives.ReadUInt64BigEndian(Buffer.FirstSpan.Slice(0, HeaderLen));

		int textByteCount = checked((int)textByteCountU);
		long totalNeed = HeaderLen + textByteCount;
		if (Buffer.Length < totalNeed){
			return null;
		}

		// 长度足够，真正消费
		var seq = Buffer.Slice(0, totalNeed);
		string text = Encoding.UTF8.GetString(seq.Slice(HeaderLen, textByteCount));
		ReadOnlyMemory<byte> binary = seq.Slice(totalNeed).ToArray(); // 这里 ToArray 可换成 Pool 复用

		Buffer = Buffer.Slice(totalNeed);
		return new TextWithBlob(text, binary);
	}
	#endregion
}


#if false
下面只挑“会跑挂/跑错”的问题，其余风格/别名/命名一律忽略。
行号按你贴出的 1-base 计数。

------------------------------------------------
1. 行 117：ReadOnlySequence.FirstSpan 可能不足 8 字节
   当 Buffer.IsSingleSegment==false 且第一段长度<8 时，FirstSpan 只有前面几个字节，
   直接 Slice(0,HeaderLen) 会抛 ArgumentOutOfRangeException。
   应改用 `Buffer.First.Span` 或 `System.Buffers.BuffersExtensions.ToSpan(Buffer.Slice(0,HeaderLen))`。

2. 行 127：Encoding.UTF8.GetString 只能接受连续内存
   `seq.Slice(HeaderLen,textByteCount)` 返回的是 ReadOnlySequence<byte>，
   如果它跨多个段，GetString 会抛 ArgumentException。
   必须先把文本段复制到临时数组或 ArrayPool 再 GetString。

3. 行 128：binary 部分直接 ToArray()
   逻辑没错，但大数据块会一次性分配 LOH，
   建议用 ArrayPool<byte>.Shared.Rent/Return 做零拷贝复用，或至少提示调用者注意。

4. 行 044、067：HeaderBytesLen 与 Text 可能不一致
   结构体允许外部直接 set HeaderBytesLen，
   如果先改 HeaderBytesLen 再改 Text，ToByteArr/WriteTo 会把错误的 textByteCount 写进包头，
   导致对端解析失败。
   解决：把 HeaderBytesLen 改成内部字段，只读公开；或者每次序列化时重新 Encoding.UTF8.GetByteCount(Text)。

5. 行 097、119：checked((int)textByteCountU)
   当对端恶意发送 textByteCountU > Int32.MaxValue 时抛 OverflowException，
   虽然比内存溢出好，但仍属于 DoS 入口。
   建议先判断 if (textByteCountU > Array.MaxLength) throw new ArgumentException("text too long")。

------------------------------------------------
以上 5 处属于“不修就一定会炸”的关键缺陷，其余实现细节暂不赘述。
#endif
