namespace Ngaq.Core.Infra;

// public interface I_StaticVersion{
// 	public static abstract Version Version{get;set;}
// }


public interface I_Version{
	#if false
	//默認實現 序列化旹無此字段
	public Version Version{get=>AppVersion.Inst.Version; set{}}
	#endif

	public Version? Version{get; set;}
	#if Impl
	= AppVersion.Inst.Version;
	#endif
}
