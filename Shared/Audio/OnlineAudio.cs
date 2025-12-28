using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ngaq.Core.Shared.Audio;

public class OnlineAudio {
	private static readonly HttpClient _http = new HttpClient() {
		// 按需调整超时
		Timeout = TimeSpan.FromSeconds(30)
	};

	public async Task<Audio> GetAsy(string Url) {
		if (string.IsNullOrWhiteSpace(Url))
			throw new ArgumentException("Url is empty.");

		// 1. 下载
		using var resp = await _http.GetAsync(Url, HttpCompletionOption.ResponseHeadersRead);
		resp.EnsureSuccessStatusCode();

		// 2. 根据 Content-Type 或 URL 后缀猜格式
		var type = DetectType(resp.Content.Headers.ContentType?.MediaType, Url);

		// 3. 拷到 MemoryStream 并保证 Position=0
		var ms = new MemoryStream();
		await resp.Content.CopyToAsync(ms);
		ms.Position = 0;

		return new Audio(ms, type);
	}

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
}
