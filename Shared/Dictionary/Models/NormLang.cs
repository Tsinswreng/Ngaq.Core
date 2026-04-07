using Ngaq.Core.Infra.IF;

namespace Ngaq.Core.Shared.Dictionary.Models;

[Doc(@$"Normalized Language")]
public class NormLang:IAppSerializable{
	public ELangIdentType Type{get;set;} = ELangIdentType.Bcp47;
	public str Code{get;set;} = "";
	
}

public class NormLangWithName
	:NormLang
	,IAppSerializable
{
	public str NativeName{get;set;} = "";
}

