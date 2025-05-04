//using MassTransit;
using System.Buffers.Binary;
namespace Ngaq.Core.Util;

public class IdUtil {

	public static UInt128 NewUInt128() {
		var bytes = Ulid.NewUlid().ToByteArray();
		var ans = BinaryPrimitives.ReadUInt128BigEndian(bytes);
		return ans;
	}


	public static string ToBase64Url(UInt128 value) {
		// 拆分为高64位（upper）和低64位（lower）
		ulong upper = (ulong)(value >> 64);
		ulong lower = (ulong)value;

		// 大端序写入：先upper后lower
		byte[] bytes = new byte[16];
		BinaryPrimitives.WriteUInt64BigEndian(bytes.AsSpan(0, 8), upper);  // 高64位在前
		BinaryPrimitives.WriteUInt64BigEndian(bytes.AsSpan(8, 8), lower);  // 低64位在后

		// 转换为Base64Url
		string base64 = Convert.ToBase64String(bytes);
		return base64.TrimEnd('=')
			.Replace('+', '-')
			.Replace('/', '_')
		;
	}

	public static UInt128 FromBase64Url(string base64Url) {
		// 还原为标准Base64并补填充
		string base64 = base64Url.Replace('-', '+')
			.Replace('_', '/')
		;
		switch (base64.Length % 4) {
			case 2: base64 += "=="; break;
			case 3: base64 += "="; break;
		}

		// 解码为字节数组
		byte[] bytes = Convert.FromBase64String(base64);
		if (bytes.Length != 16)
			throw new ArgumentException("Invalid byte length for UInt128");

		// 大端序读取：前8字节为upper，后8字节为lower
		ulong upper = BinaryPrimitives.ReadUInt64BigEndian(bytes.AsSpan(0, 8));
		ulong lower = BinaryPrimitives.ReadUInt64BigEndian(bytes.AsSpan(8, 8));

		return (UInt128)upper << 64 | lower;
	}


}


/*

function base64UrlToDecimal(base64UrlString) {
  // 1. 将 Base64URL 转换为标准的 Base64 编码
  let base64 = base64UrlString.replace(/-/g, '+').replace(/_/g, '/');

  // 2. 补齐 Base64 字符串的长度，使其长度是 4 的倍数
  while (base64.length % 4) {
    base64 += '=';
  }

  // 3. 使用 atob() 解码 Base64 字符串
  const decodedString = atob(base64);

  // 4. 将解码后的字符串转换为 BigInt
  let decimalValue = BigInt(0);
  for (let i = 0; i < decodedString.length; i++) {
    decimalValue = (decimalValue * BigInt(256)) + BigInt(decodedString.charCodeAt(i));
  }

  return decimalValue.toString(); // 返回字符串形式的 BigInt
}

// 示例
const base64UrlString = 'AZabdYHHTZPXGVRxYkQw8g';
const decimalString = base64UrlToDecimal(base64UrlString);
console.log(decimalString);

 */
