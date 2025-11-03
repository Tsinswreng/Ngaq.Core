namespace Ngaq.Core.Shared.Word.Models.Dto;

using Ngaq.Core.Shared.Word.Models.Po.Kv;
using Ngaq.Core.Shared.Word.Models.Po.Learn;
using Ngaq.Core.Shared.Word.Models.Po.Word;
using Tsinswreng.CsTools;

public class DtoSyncTwoWords{
	public PoWord? ChangedPoWord{get;set;}

	public IList<PoWordProp>? NeoProps{get;set;}
	public IList<PoWordProp>? ChangedProps{get;set;}

	public IList<PoWordLearn>? NeoLearns{get;set;}
	public IList<PoWordLearn>? ChangedLearns{get;set;}
}


public static class ExtnDtoSyncTwoWords{
	public static DtoSyncWords ToDtoSyncWords(
		this DtoSyncTwoWords z
		,IJnWord WordInDb
	){
		var R = new DtoSyncWords();
		var NeoPart = new JnWord{Word=z.ChangedPoWord??WordInDb.Word};
		NeoPart.Props.AddRange(z.NeoProps??[]);
		NeoPart.Learns.AddRange(z.NeoLearns??[]);

		var ChangedPart = new JnWord{Word=z.ChangedPoWord??WordInDb.Word};
		ChangedPart.Props.AddRange(z.ChangedProps??[]);
		ChangedPart.Learns.AddRange(z.ChangedLearns??[]);
		var dtoUpd = new DtoUpdWord(WordInDb, NeoPart, ChangedPart);
		R.UpdatedWords.Add(dtoUpd);
		return R;
	}
}
