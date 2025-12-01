namespace Ngaq.Core.Shared.Word.Models.Dto;

using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Base.Models.Req;
using Tsinswreng.CsPage;

public class ReqScltWordsOfLearnResultByTimeInterval:IReq{
	public Tempus TimeStart{get;set;}
	public Tempus TimeEnd{get;set;}
	public Tempus TimeInterval{get;set;}
	public str LearnResult{get;set;}
	public IPageQry PageQry{get;set;}
}

