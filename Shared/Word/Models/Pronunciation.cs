namespace Ngaq.Core.Shared.Word.Models;

public enum EAudioType{
	Unknown
}

public class Audio{
	public EAudioType Type{get;set;}
	public u8[]? Data{get;set;}
}

public class Pronunciation{
	public str Lang{get;set;}
	public str TextType{get;set;}
	public str Text{get;set;}
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

