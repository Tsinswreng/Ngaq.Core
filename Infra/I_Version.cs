namespace Ngaq.Core.Infra;

// public interface I_StaticVersion{
// 	public static abstract Version Version{get;set;}
// }


public interface I_Version{
	public Version Version{get=>AppVersion.Inst.Version; set{}}
}
