namespace Ngaq.Core.Shared.Audio;

public interface IAudioPlayer{
	public Task<IPlayState?> Play(Stream S, EAudioType Type, CT Ct);
}



