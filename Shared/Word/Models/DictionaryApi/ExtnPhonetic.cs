namespace Ngaq.Core.Shared.Word.Models.DictionaryApi;

public static class ExtnPhonetic{
	extension(Phonetic z){
		public async Task<Pronunciation> ToPronunciation(CT Ct){
			var R = new Pronunciation();
			R.Lang = ELang.English.ToString();
			R.AudioUrl = z.audio;
			R.TextType = EPronunciationTextType.Ipa.ToString();
			R.Lang = ELang.English.ToString();
			await R.AssignAudioFromUrl(Ct);
			return R;
		}
	}
}



