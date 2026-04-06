namespace Ngaq.Core.Shared.Dictionary.Models;

[Doc(@$"Normalized Language")]
public class NormLang{
	public ELangIdentType Type{get;set;} = ELangIdentType.Bcp47;
	public str Code{get;set;} = "";
	
}

public class NormLangWithNativeName : NormLang{
	public str NativeName{get;set;} = "";
}

