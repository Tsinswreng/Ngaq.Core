﻿// namespace Ngaq.Core.Word.WeightAlgo;

// public  partial interface IA{
// 	str? A{get;set;}
// }

// public  partial interface IB{
// 	str? B{get;set;}
// }

// public  partial interface IC{
// 	str? C{get;set;}
// }

// public  partial interface IS:IA,IB{

// }

// public  partial interface IL:IA,IB,IC{}

// public  partial class S:IA,IB{
// 	public str? A{get;set;} = "S-A";
// 	public str? B{get;set;} = "S-B";
// }

// public  partial class L:IA,IB,IC{
// 	public str? A{get;set;} = "L-A";
// 	public str? B{get;set;} = "L-B";
// 	public str? C{get;set;} = "L-C";
// }



// public  partial class MainWeightAlgo{
// 	public static i32 Main(string[] args){
// 		Console.WriteLine(null is double?);//->False
// double? d = null;
// 		Console.WriteLine(d is double?); // -> False
// 		Console.WriteLine(null is string);
// //System.Console.WriteLine(null instanceof string);
// 		// var CS = new S();
// 		// //IS IS = Unsafe.As<S,IS>(ref CS);
// 		// IS IS = (IS)CS;
// 		// System.Console.WriteLine(IS.A);
// 		// IS S = (IS)new S();
// 		// IL L = (IL)new L();
// 		// S = (S)L;
// 		// L = (L)S;
// 		// if(args.Length == 0){
// 		// 	Err("Please provide input file path as command line argument.");
// 		// 	return 1;
// 		// }
// 		// var JsonJnWords = args[0];
// 		// var JnWords = JSON.parse<IList<JnWord>>(JsonJnWords);
// 		// if(JnWords == null){
// 		// 	Err("Failed to parse JSON.");
// 		// 	return 1;
// 		// }
// 		// IList<IWeightWord> WeightWords = JnWords.Select(x=>(IWeightWord)(new WeightWord(x))).ToList();
// 		return 0;

// 	}

// 	static nil Err(str S){
// 		Console.WriteLine(S);
// 		return Nil;
// 	}
// }

