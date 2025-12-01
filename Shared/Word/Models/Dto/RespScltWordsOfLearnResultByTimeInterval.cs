namespace Ngaq.Core.Shared.Word.Models.Dto;

using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Base.Models.Resp;
using Tsinswreng.CsPage;



public class TimeIntervalCnt{
	public Tempus TimeStart{get;set;}
	public Tempus TimeEnd{get;set;}
	public i64 Cnt{get;set;}
}

public class RespScltWordsOfLearnResultByTimeInterval:IResp{
	public IPageAsyE<TimeIntervalCnt> IntervalPage{get;set;}
}

