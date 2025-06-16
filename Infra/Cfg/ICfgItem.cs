namespace Ngaq.Core.Infra.Cfg;

public interface ICfgItem{
	public IList<str> Path{get;set;}
	public ICfgValue? DfltValue{get;set;}
}

public interface ICfgItem<T>:ICfgItem{

}
