using Ngaq.Core.Shared.Audio;

namespace Ngaq.Core.Shared.Word.Models;


public class Audio{
	public EAudioType Type{get;set;}
	public Stream? Data{get;set;}

}

public class Pronunciation{
	public str Lang{get;set;} = "";
	//如 Ipa, 假名 等
	public str TextType{get;set;} = "";
	public str Text{get;set;} = "";
	public str? AudioUrl{get;set;}
	public Audio? Audio{get;set;}
}

public enum ELang{
	Unknown,
	English,
	Chinese,
	Japanese,
	Italian,
	Spanish,
	French,
}

