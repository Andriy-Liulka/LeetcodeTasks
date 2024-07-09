//namespace BenchmarkTest;
//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Reports;

//[MemoryDiagnoser]
//[RankColumn]
//public class SetMatrixZeroes
//{
//	[Params(10,100,1000,10000)]
//	public int arraySize;
//	public int[][] TestData;

//	[IterationSetup]
//	public void Setup()
//	{
//		TestData = new int[arraySize][];
//		for (int i = 0; i < arraySize; i++)
//		{
//			TestData[i] = Enumerable.Range(0, arraySize).ToArray();
//		}
//		for (int i = 0; i < arraySize; i++)
//		{
//			for (int j = 0; j < 100; j++)
//			{
//				TestData[i][new Random().Next(0, arraySize - 1)] = 0;
//			}
//		}
//	}

//	public record Indexes(int x, int y);

//	[Benchmark]
//	public void FindNormalWay()
//	{
//		var heigh = TestData.Length;
//		var width = TestData[0].Length;

//		var elems = TestData.SelectMany(x => x);

//		var elemeWithIndexes = elems
//			.Select((x, i) => KeyValuePair.Create(i, x))
//			.Where(x => x.Value == 0)
//			.Select(x => x.Key);

//		var coordinates = elemeWithIndexes.Select(x => new Indexes(x / width, x % width));
//	}

//	[Benchmark]
//	public void FindBadWay()
//	{
//		IList<Indexes> coordinates = new List<Indexes>();

//		var heigh = TestData.Length;
//		var width = TestData[0].Length;
//		for (int i = 0; i < heigh; i++)
//		{
//			for (int j = 0;  j < width;  j++)
//			{
//				if (TestData[i][j] == 0)
//				{
//					coordinates.Add(new Indexes(i,j));
//				}
//			}
//		}
//	}
//}