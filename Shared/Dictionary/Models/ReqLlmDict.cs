namespace Ngaq.Core.Shared.Dictionary.Models;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Ngaq.Core.Infra;


/// 词典查询请求，支持多模式查询
public class ReqLlmDict {
	/// 唯一请求ID，用于追踪/缓存（UUID-v4字符串）
	public string Id { get; set; } = "";
	public Tempus UnixMs { get; set; }

	/// 核心查询内容
	public Query Query { get; set; } = new Query();

	/// 语言配置
	public OptLang OptLang { get; set; } = new OptLang();

	/// 用户偏好配置
	public Preferences? Preferences { get; set; } = null;

	/// 扩展元数据（用于AI个性化）暫不需
	//public UserContext UserContext { get; set; } = new UserContext();
}

/// 核心查询内容
public class Query {
	/// 查询词（源语言）
	public string Term { get; set; } = "";

	/// 可选：上下文句子，用于消歧
	public string? ContextSentence { get; set; }

}

/// 语言配置（核心动态配置）
public class OptLang {
	/// 源语言配置
	public LangInfo SrcLang { get; set; } = new LangInfo();

	/// 目标语言配置
	public IList<LangInfo> TgtLangs { get; set; } = [];
}

/// 语言信息（源/目标/额外目标语言通用结构）
public class LangInfo {
	/// ISO 639-1 语言代码（如en、zh、ja）
	public string Iso639_1 { get; set; } = "";

	/// 可选：地区变体（如us|uk|au|cn|jp...）
	public string? Variety { get; set; }

	/// 可选：书写系统（用于多书写语言如中文简繁，hans=简体, hant=繁体）
	public string? Script { get; set; }
}

/// 用户偏好配置
public class Preferences {
	public QueryMode QueryMode { get; set; } = QueryMode.Standard;
	public DetailLevel DetailLevel { get; set; } = DetailLevel.Comprehensive;

	public bool TryIncludeExamples { get; set; } = true;

	public bool TryIncludeSynonyms { get; set; } = true;

	public bool TryIncludeAntonyms { get; set; } = false;

	public bool TryIncludeEtymology { get; set; } = true;

	public int MaxExamples { get; set; } = 3;
}

// /// 扩展元数据（用于AI个性化）
// public class UserContext {
// 	/// 用户语言水平，影响释义复杂度
// 	public ProficiencyLevel ProficiencyLevel { get; set; } = ProficiencyLevel.Intermediate;

// 	/// 可选：关联查询历史（用于连贯释义）暫不實現
// 	//public IList<string> PreviousQueries { get; set; } = new List<string>();
// }

/// 查询模式枚举
public enum QueryMode {
	Standard,
	Etymology,
	Usage,
	Collocation,
	Encyclopedia
}

/// 释义详细程度枚举
public enum DetailLevel {
	Brief,
	Standard,
	Comprehensive,
	Academic
}

/// 用户语言水平枚举
public enum ProficiencyLevel {
	Beginner,
	Intermediate,
	Advanced,
	Expert
}

#if false
class Sample{
	const str s =
"""
Id: "1cwMqe3zEnhxG28qZoRVX"
UnixMs: 1740000000000
Query:
  Term: "acquiesce"
  ContextSentence: "He chose to acquiesce to the decision"
OptLang:
  SrcLang:
    Iso639_1: "en"
    Variety: "us"
    Script: null
  TgtLangs:
    - Iso639_1: "zh"
      Variety: "tw"
      Script: "hant"
    - Iso639_1: "ja"
      Variety: "jp"
      Script: ""
""";
}


#endif
