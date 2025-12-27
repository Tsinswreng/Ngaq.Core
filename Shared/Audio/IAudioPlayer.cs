namespace Ngaq.Core.Shared.Audio;

public interface IAudioPlayer{
	public Task<obj?> PlayAsy(Stream S, EAudioType Type);
}



