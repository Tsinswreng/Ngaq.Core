namespace Ngaq.Core.Infra.Errors;
using Tsinswreng.CsCfg;

public interface IErrItem:ICfgItem{
	public ISet<str> Tags{get;set;}
}

public class ErrItem:CfgItem<nil>, IErrItem {
	public ISet<str> Tags{get;set;} = new HashSet<str>();
	public static IErrItem Mk(IErrItem? Parent, IList<str> Path, IList<str>? Tags = null){
		var R = new ErrItem();
		R.Parent = Parent;
		R.RelaPathSegs = Path;
		if(Tags != null){
			R.Tags.UnionWith(Tags);
		}
		return R;
	}

	public static IErrItem MkC(IErrItem? Parent, IList<str> Path, IList<str>? Tags = null){
		var R = Mk(Parent, Path, Tags);
		R.Tags.Add(TagsErr.BadReq);
		return R;
	}

	public static IErrItem MkS(IErrItem? Parent, IList<str> Path, IList<str>? Tags = null){
		var R = Mk(Parent, Path, Tags);
		R.Tags.Add(TagsErr.SrvErr);
		return R;
	}
}

public static class ExtnErrKeySeg{
	public static ErrBase ToErr(this IErrItem z, params obj?[] Args){
		return ErrBase.Mk(z, Args);
	}
}
