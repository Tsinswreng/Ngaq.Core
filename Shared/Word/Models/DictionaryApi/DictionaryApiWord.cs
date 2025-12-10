namespace Ngaq.Core.Shared.Word.Models.DictionaryApi;

using Ngaq.Core.Infra.IF;



public class License:IAppSerializable{
	public str name{get;set;}
	public str url{get;set;}
}

public class Phonetic:IAppSerializable{
	public str text{get;set;}
	public str audio{get;set;}
	public str sourceUrl{get;set;}
	public License license{get;set;}
}

public class Definition:IAppSerializable{
	public str definition{get;set;}
	public IList<str> synonyms{get;set;}
	public IList<str> antonyms{get;set;}
	public str example{get;set;}
}

public class Meaning:IAppSerializable{
	public str partOfSpeech{get;set;}
	public IList<Definition> definitions{get;set;}
	public IList<str> synonyms{get;set;}
	public IList<str> antonyms{get;set;}
}

public class DictionaryApiWord:IAppSerializable{
	public str word{get;set;}
	public IList<Phonetic> phonetics{get;set;}
	public IList<Meaning> meanings{get;set;}
	public str license{get;set;}
	public IList<str> sourceUrls{get;set;}

}
