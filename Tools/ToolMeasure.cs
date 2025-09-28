using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Ngaq.Core.Tools;
public static class TimingExt {
	public static TRet Time<TRet>(this Func<TRet> a, [CallerMemberName] string name = "") {
		var sw = Stopwatch.StartNew();
		var R = a();
		sw.Stop();
		Console.WriteLine($"{name} 耗时 {sw.ElapsedMilliseconds} ms");
		return R;
	}

	public static async Task<TRet> TimeAsy<TRet>(this Func<Task<TRet>> Fn, [CallerMemberName] string name = "") {
		System.Console.WriteLine($">in {name}");
		var sw = Stopwatch.StartNew();
		var R = await Fn();
		sw.Stop();
		Console.WriteLine($"<in {name} 耗时 {sw.ElapsedMilliseconds} ms");
		return R;
	}

	// public static async Task<TRet> TimeAsy<TRet>(this Task<TRet> a, [CallerMemberName] string name = "") {
	// 	var sw = Stopwatch.StartNew();
	// 	var R = await a;
	// 	sw.Stop();
	// 	Console.WriteLine($"{name} 耗时 {sw.ElapsedMilliseconds} ms");
	// 	return R;
	// }

}

public interface IStopWatch{
	public void Start();
	public void Stop();
	public void Restart();
	public i64 ElapsedMilliseconds{get;set;}
}


public class TswGStopWatch : IStopWatch{
	Stopwatch Sw = new();
	public void Start(){
		Sw.Start();
	}
	public void Stop(){
		Sw.Stop();
	}
	public void Restart(){
		Sw.Restart();
	}
	public i64 ElapsedMilliseconds{get{
		return Sw.ElapsedMilliseconds;
	}
	set{

	}}
}

public class EmptyStopWatch : IStopWatch{
	public void Start(){}
	public void Stop(){}
	public void Restart(){}
	public i64 ElapsedMilliseconds{get;set;}
}
