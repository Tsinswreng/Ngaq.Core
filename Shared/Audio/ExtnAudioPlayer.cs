namespace Ngaq.Core.Shared.Audio;

public static class ExtnAudioPlayer{
	extension(IAudioPlayer z){
		public Task<IPlayState?> Play(Audio Audio, CT Ct){
			return z.Play(Audio.Data, Audio.Type, Ct);
		}
	}
}
