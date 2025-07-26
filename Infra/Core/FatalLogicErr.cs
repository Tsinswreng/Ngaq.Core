namespace Ngaq.Core.Infra.Core;

/// <summary>
/// 預料外ʹ理則謬
/// </summary>
public  partial class FatalLogicErr : Exception{
	public FatalLogicErr(str? msg):base(msg){

	}
}
