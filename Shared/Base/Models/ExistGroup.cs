namespace Ngaq.Core.Shared.Base.Models;

public partial struct Existing_Duplication<T>{

	public Existing_Duplication(
		T Existing
		,T Duplication
	){
		this.Existing = Existing;
		this.Duplication = Duplication;
	}

	/// 既存于數據源中者
	public T Existing { get; set; }
	/// 與[既存]者褈者
	public T Duplication { get; set; }
}

//TODO 用IEnumerable成員?
public partial struct DuplicationGroup<T>{
	public IList<Existing_Duplication<T>> Existing_Duplications{get;set;}
	// /// 原已存在(當是得從數據源)
	// public IEnumerable<T>? Existings { get; set; }

	// /// 與[原已存在]褈者
	// public IEnumerable<T>? Duplicates{get;set;}

	/// 未存在(待添加)
	public IList<T>? NonExistings { get; set; }
}
