using System.Collections;

namespace Ngaq.Core.Model;


public struct Existing_Duplication<T>{

	public Existing_Duplication(
		T Existing
		,T Duplication
	){
		this.Existing = Existing;
		this.Duplication = Duplication;
	}
	/// <summary>
	/// 既存于數據源中者
	/// </summary>
	public T Existing { get; set; }
	/// <summary>
	/// 與[既存]者褈者
	/// </summary>
	public T Duplication { get; set; }
}

public struct DuplicationGroup<T>{
	public IList<Existing_Duplication<T>> Existing_Duplications{get;set;}
	// /// <summary>
	// /// 原已存在(當是得從數據源)
	// /// </summary>
	// public IEnumerable<T>? Existings { get; set; }

	// /// <summary>
	// /// 與[原已存在]褈者
	// /// </summary>
	// public IEnumerable<T>? Duplicates{get;set;}

	/// <summary>
	/// 未存在(待添加)
	/// </summary>
	public IList<T>? NonExistings { get; set; }
}
