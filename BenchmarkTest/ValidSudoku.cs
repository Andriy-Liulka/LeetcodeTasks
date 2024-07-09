//using BenchmarkDotNet.Attributes;

//namespace BenchmarkTest;

//[MemoryDiagnoser]
//[RankColumn]
//public class ValidSudoku
//{
//	public char[][] benchmarkBoard;

//	[Params(1, 2, 3)]
//	public int Case { get; set; }

//	[IterationSetup]
//	public void Setup()
//	{
//		benchmarkBoard = Case switch
//		{
//			1 => new char[9][]
//					{
//						new char[9]{'5', '3', '.', '.', '7', '.', '.', '.', '.'},
//						new char[9]{'6', '.', '.', '1', '9', '5', '.', '.', '.'},
//						new char[9]{'.', '9', '8', '.', '.', '.', '.', '6', '.'},
//						new char[9]{'8', '.', '.', '.', '6', '.', '.', '.', '3'},
//						new char[9]{'4', '.', '.', '8', '.', '3', '.', '.', '1'},
//						new char[9]{'7', '.', '.', '.', '2', '.', '.', '.', '6'},
//						new char[9]{'.', '6', '.', '.', '.', '.', '2', '8', '.'},
//						new char[9]{'.', '.', '.', '4', '1', '9', '.', '.', '5'},
//						new char[9]{'.', '.', '.', '.', '8', '.', '.', '7', '9' }
//					},
//			2 => new char[9][]
//					{
//						new char[9]{'8', '3', '.', '.', '7', '.', '.', '.', '.'},
//						new char[9]{'6', '.', '.', '1', '9', '5', '.', '.', '.'},
//						new char[9]{'.', '9', '8', '.', '.', '.', '.', '6', '.'},
//						new char[9]{'8', '.', '.', '.', '6', '.', '.', '.', '3'},
//						new char[9]{'4', '.', '.', '8', '.', '3', '.', '.', '1'},
//						new char[9]{'7', '.', '.', '.', '2', '.', '.', '.', '6'},
//						new char[9]{'.', '6', '.', '.', '.', '.', '2', '8', '.'},
//						new char[9]{'.', '.', '.', '4', '1', '9', '.', '.', '5'},
//						new char[9]{'.', '.', '.', '.', '8', '.', '.', '7', '9'}
//					},
//			3 => new char[9][]
//					{
//						new char[9]{'7', '.', '.', '.', '4', '.', '.', '.', '.'},
//						new char[9]{'.', '.', '.', '8', '6', '5', '.', '.', '.'},
//						new char[9]{'.', '1', '.', '2', '.', '.', '.', '.', '.'},
//						new char[9]{'.', '.', '.', '.', '.', '9', '.', '.', '.'},
//						new char[9]{'.', '.', '.', '.', '5', '.', '5', '.', '.'},
//						new char[9]{'.', '.', '.', '.', '.', '.', '.', '.', '.'},
//						new char[9]{'.', '.', '.', '.', '.', '.', '2', '.', '.'},
//						new char[9]{'.', '.', '.', '.', '.', '.', '.', '.', '.'},
//						new char[9]{'.', '.', '.', '.', '.', '.', '.', '.', '.'}
//					},
//			_ => new char[9][]
//		};
//	}

//	[Benchmark]
//	public bool FirstSolution() 
//	{
//		return new Solution1().IsValidSudoku(benchmarkBoard);
//	}

//	[Benchmark]
//	public bool ThroughArraysSolution()
//	{
//		return new Solution2().IsValidSudoku(benchmarkBoard);
//	}

//	[Benchmark]
//	public bool ThroughGroupBySolution()
//	{
//		return new Solution3().IsValidSudoku(benchmarkBoard);
//	}
//}

//public class Solution1
//{
//	const int BoxSize = 3;
//	public bool IsValidSudoku(char[][] board)
//	{
//		//var answer = true;
//		int rowBoxNumber = default;
//		int columnBoxNumber = default;

//		for (int i = 0; i < board.Length; i++)
//		{
//			//Column check
//			var columnArray = GetColumn(board, i);
//			if (!IsUniq(columnArray))
//			{
//				return false;
//			}

//			//RowCheck
//			var rowArray = GetRow(board, i);
//			if (!IsUniq(rowArray))
//			{
//				return false;
//			}

//			//Box check
//			var boxArray = GetBox(board, rowBoxNumber, columnBoxNumber);
//			if (!IsUniq(boxArray))
//			{
//				return false;
//			}
//			columnBoxNumber++;
//			if (columnBoxNumber >= 3)
//			{
//				columnBoxNumber = 0;
//				rowBoxNumber++;
//			}
//		}

//		return true;
//	}

//	private bool IsUniq(IEnumerable<char> array)
//	{
//		var initialArray = array.Where(x => !x.Equals('.'));

//		return initialArray.Distinct().Count() == initialArray.Count();
//	}
//	private IEnumerable<char> GetColumn(char[][] twoDArray, int column)
//	{
//		return Enumerable.Range(0, twoDArray.Length)
//			.Select(x => twoDArray[x][column]);
//	}

//	private IEnumerable<char> GetRow(char[][] twoDArray, int row)
//	{
//		return twoDArray[row];
//	}

//	private IList<char> GetBox(char[][] twoDArray, int rowNumber, int columnNumber)
//	{
//		var finalArray = new List<char>(BoxSize * BoxSize);
//		for (int i = rowNumber * BoxSize; i <= (rowNumber * BoxSize + BoxSize) - 1; i++)
//		{
//			var row = Enumerable.Range(columnNumber * BoxSize, BoxSize)
//				.Select(x => twoDArray[i][x]);
//			finalArray.AddRange(row);
//		}
//		return finalArray;
//	}
//}

//public class Solution2
//{
//	const int BoxSize = 3;
//	public bool IsValidSudoku(char[][] board)
//	{
//		//var answer = true;
//		int rowBoxNumber = default;
//		int columnBoxNumber = default;

//		for (int i = 0; i < board.Length; i++)
//		{
//			//Column check
//			var columnArray = GetColumn(board, i);
//			if (!IsUniq(columnArray))
//			{
//				return false;
//			}

//			//RowCheck
//			var rowArray = GetRow(board, i);
//			if (!IsUniq(rowArray))
//			{
//				return false;
//			}

//			//Box check
//			var boxArray = GetBox(board, rowBoxNumber, columnBoxNumber);
//			if (!IsUniq(boxArray))
//			{
//				return false;
//			}
//			columnBoxNumber++;
//			if (columnBoxNumber >= 3)
//			{
//				columnBoxNumber = 0;
//				rowBoxNumber++;
//			}
//		}

//		return true;
//	}

//	private bool IsUniq(char[] array)
//	{
//		var initialArray = array.Where(x => !x.Equals('.'));

//		return initialArray.Distinct().Count() == initialArray.Count();
//	}
//	private char[] GetColumn(char[][] twoDArray, int column)
//	{
//		return Enumerable.Range(0, twoDArray.Length)
//			.Select(x => twoDArray[x][column]).ToArray();
//	}

//	private char[] GetRow(char[][] twoDArray, int row)
//	{
//		return twoDArray[row];
//	}

//	private char[] GetBox(char[][] twoDArray, int rowNumber, int columnNumber)
//	{
//		var finalArray = new List<char>(BoxSize * BoxSize);
//		for (int i = rowNumber * BoxSize; i <= (rowNumber * BoxSize + BoxSize) - 1; i++)
//		{
//			var row = Enumerable.Range(columnNumber * BoxSize, BoxSize)
//				.Select(x => twoDArray[i][x]);
//			finalArray.AddRange(row);
//		}
//		return finalArray.ToArray();
//	}
//}

//public class Solution3
//{
//	const int BoxSize = 3;
//	public bool IsValidSudoku(char[][] board)
//	{
//		//var answer = true;
//		int rowBoxNumber = default;
//		int columnBoxNumber = default;

//		for (int i = 0; i < board.Length; i++)
//		{
//			//Column check
//			var columnArray = GetColumn(board, i);
//			if (!IsUniq(columnArray))
//			{
//				return false;
//			}

//			//RowCheck
//			var rowArray = GetRow(board, i);
//			if (!IsUniq(rowArray))
//			{
//				return false;
//			}

//			//Box check
//			var boxArray = GetBox(board, rowBoxNumber, columnBoxNumber);
//			if (!IsUniq(boxArray))
//			{
//				return false;
//			}
//			columnBoxNumber++;
//			if (columnBoxNumber >= 3)
//			{
//				columnBoxNumber = 0;
//				rowBoxNumber++;
//			}
//		}

//		return true;
//	}

//	private bool IsUniq(char[] array)
//	{
//		return !array.Where(x => !x.Equals('.')).GroupBy(x => x).Any(x => x.Count() > 1);
//	}
//	private char[] GetColumn(char[][] twoDArray, int column)
//	{
//		return Enumerable.Range(0, twoDArray.Length)
//			.Select(x => twoDArray[x][column]).ToArray();
//	}

//	private char[] GetRow(char[][] twoDArray, int row)
//	{
//		return twoDArray[row];
//	}

//	private char[] GetBox(char[][] twoDArray, int rowNumber, int columnNumber)
//	{
//		var finalArray = new List<char>(BoxSize * BoxSize);
//		for (int i = rowNumber * BoxSize; i <= (rowNumber * BoxSize + BoxSize) - 1; i++)
//		{
//			var row = Enumerable.Range(columnNumber * BoxSize, BoxSize)
//				.Select(x => twoDArray[i][x]);
//			finalArray.AddRange(row);
//		}
//		return finalArray.ToArray();
//	}
//}