namespace SetMatrixZeroes;

public class Program
{
	public static void Main(string[] args)
	{
		new Solution().SetZeroes
		(
			new int[3][]
			{
				new int[4]{ 0, 1 ,2, 0 },
				new int[4]{ 3, 4, 5, 2 },
				new int[4]{ 1, 3, 1, 5 }
			}
		);

	}

}

public record Indexes(int x,int y);

public class Solution
{
	public void SetZeroes(int[][] matrix)
	{
		var heigh = matrix.Length;
		var width = matrix[0].Length;

		var elems = matrix.SelectMany(x => x);

		var elemeWithIndexes = elems
			.Select((x, i) => KeyValuePair.Create(i,x))
			.Where(x => x.Value == 0)
			.Select(x => x.Key);

		var coordinates = elemeWithIndexes.Select(x => new Indexes(x / width,x % width));

		var rowNumbers = coordinates.Select(x => x.x).Distinct().ToArray();
		var columnNumbers = coordinates.Select(x => x.y).Distinct().ToArray();

		SetZeroesInRows(matrix, width, rowNumbers);
		SetZeroesInColumn(matrix, heigh, columnNumbers);
    }

	public void SetZeroesInRows(int[][] matrix, int rowLenght,int[] rowNumbers)
	{
		for (int i = 0; i < rowNumbers.Length; i++)
		{
			var array = new int[rowLenght];
			Array.Fill(array, 0);
			matrix[rowNumbers[i]] = array;
		}
	}

	public void SetZeroesInColumn(int[][] matrix, int columnHeight, int[] columnNumbers)
	{
		for (int j = 0; j < columnNumbers.Length; j++)
		{
			for (int i = 0; i < columnHeight; i++)
			{
				matrix[i][columnNumbers[j]] = 0;
			}
		}
	}
}