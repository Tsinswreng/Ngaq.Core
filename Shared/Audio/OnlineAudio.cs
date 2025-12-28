using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ngaq.Core.Shared.Audio;

public class OnlineAudio {
	private static readonly HttpClient _http = new HttpClient {
		Timeout = TimeSpan.FromSeconds(30)
	};

	/// <summary>
	/// 下載一次，之後交給 Audio 的工廠無限重讀。
	/// </summary>
	public async Task<Audio> Get(string url, CT Ct = default) {
		if (string.IsNullOrWhiteSpace(url))
			throw new ArgumentException("Url is empty.");

		// 1. 下載到記憶體
		using var resp = await _http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, Ct);
		resp.EnsureSuccessStatusCode();

		var type = DetectType(resp.Content.Headers.ContentType?.MediaType, url);

		var ms = new MemoryStream();
		await resp.Content.CopyToAsync(ms, Ct);
		var bytes = ms.ToArray();          // 真正快取起來

		// 2. 包成工廠：每次給一條全新的 MemoryStream
		Task<Stream> Factory(CancellationToken _)
			=> Task.FromResult<Stream>(new MemoryStream(bytes));

		return new Audio(Factory, type);
	}

	#region 原本的分類邏輯保持不變
	private static EAudioType DetectType(string? mime, string url) {
		if (mime != null) {
			return mime switch {
				"audio/mpeg" or "audio/mp3" => EAudioType.Mp3,
				"audio/wav" or "audio/x-wav" => EAudioType.Wav,
				_ => InferFromExtension(url)
			};
		}
		return InferFromExtension(url);
	}

	private static EAudioType InferFromExtension(string url) {
		var ext = Path.GetExtension(url.AsSpan()).TrimStart('.').ToString().ToLowerInvariant();
		return ext switch {
			"mp3" => EAudioType.Mp3,
			"wav" => EAudioType.Wav,
			_ => throw new NotSupportedException($"Unknown audio type: {url}")
		};
	}
	#endregion
}
