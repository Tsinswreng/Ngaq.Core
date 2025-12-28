namespace Ngaq.Core.Shared.Audio;
public class Audio{
	public Audio(Stream Data, EAudioType Type){
		this.Data = Data;
		this.Type = Type;
	}
	public EAudioType Type{get;set;}
	public Stream Data{get;set;}

}
