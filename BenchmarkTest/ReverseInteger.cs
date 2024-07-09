//using BenchmarkDotNet.Attributes;
//using System.Text;

//namespace BenchmarkTest;

//[MemoryDiagnoser]
//[RankColumn]
//public class ReverseInteger
//{
//    [Params(161612616,65165161,123,-16161,-4566,-123456,11333111)]
//    public  int x { get; set; }

//    [Benchmark]
//    public int Standart()
//    {
//		var sign = x > 0 ? "+" : "-";

//		var splittedNumber = sign.Equals("+") ? x.ToString().ToCharArray() : x.ToString().ToCharArray().Skip(1);

//		splittedNumber = Enumerable.Reverse(splittedNumber);

//		var number = String.Join(String.Empty, splittedNumber);

//		var finalStringNumber = sign.Equals("+") ? new StringBuilder(number).ToString() : new StringBuilder(sign).Append(number).ToString();

//		int result = default;
//		var convertionResult = Int32.TryParse(finalStringNumber, out result);

//		if (!convertionResult)
//		{
//			return 0;
//		}

//		return result;
//	}

//	[Benchmark]
//	public int AttemptToImprove()
//	{
//		var sign = x > 0 ? "+" : "-";

//		var splittedNumber = sign.Equals("+") ? x.ToString().ToCharArray() : x.ToString().ToCharArray().Skip(1);

//		splittedNumber = Enumerable.Reverse(splittedNumber);

//		var number = String.Join(String.Empty, splittedNumber);

//		var finalStringNumber = sign.Equals("+") ? new StringBuilder(number).ToString() : new StringBuilder(sign).Append(number).ToString();

//		int result = default;
//		var convertionResult = Int32.TryParse(finalStringNumber, out result);

//		if (!convertionResult)
//		{
//			return 0;
//		}

//		return result;
//	}
//}
