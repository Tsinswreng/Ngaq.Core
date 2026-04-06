namespace Ngaq.Core.Shared.Dictionary.Models.Po.NormLang;

public class InitNormLang{
	public static PoNormLang Mk(
		str Code, str NativeName
	){
		var R = new PoNormLang();
		R.Code = Code;
		R.NativeName = NativeName;
		return R;
	}
	
	[Doc(@$"內容不固定、後續可能增改")]
	public static IList<PoNormLang> GetNormLangList(){
		return new List<PoNormLang> {
			Mk("en", "English"),
			Mk("en-US", "American English"),
		};
	}
}
