using Ngaq.Core.Infra.IF;

namespace Ngaq.Core.Shared.Dictionary.Models;

[Doc(@$"Normalized Language")]
public interface INormLang{
	public ELangIdentType Type{get;set;}
	public str Code{get;set;}
}

public class NormLang
	:INormLang
	,IAppSerializable
{
	public ELangIdentType Type{get;set;} = ELangIdentType.Bcp47;
	public str Code{get;set;} = "";
	
}

public class NormLangWithName
	:NormLang
	,IAppSerializable
{
	public str NativeName{get;set;} = "";
}

