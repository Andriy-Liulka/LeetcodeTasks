//using BenchmarkDotNet.Attributes;

//namespace BenchmarkTest;

////var result1 = new Solution().TwoSum(new[] { 2, 7, 11, 15 }, 9);
////var result2 = new Solution().TwoSum(new[] { 3, 2, 4 }, 6);
////var result3 = new Solution().TwoSum(new[] { 3, 3 }, 6);
////var result4 = new Solution().TwoSum(new[] { 0, 4, 3, 0 }, 0);
////var result5 = new Solution().TwoSum(new[] { -1, -2, -3, -4, -5 }, -8);

//[MemoryDiagnoser]
//[RankColumn]
//public class TwoSum
//{
//	//[Params(new int[] { 2, 7, 11, 15 }, new int[] { 3, 2, 4 }, )]
//	public int[] numbers;

//	[GlobalSetup]
//	public void Setup()
//	{
//		numbers = Enumerable.Range(0, 10000).ToArray();
//	}

//	record Elem(int index, int value);

//	[Benchmark]
//	public void WithRecord()
//	{
//		var elems = numbers.Select((int x, int i) => new Elem(i, x)).ToDictionary(x => x.index, x => x.value);
//	}

//	[Benchmark]
//	public void WithKeyValue()
//	{
//		var elems = numbers.Select((int x, int i) => KeyValuePair.Create(i,x)).ToDictionary(x => x.Key, x => x.Value);
//	}
//}
