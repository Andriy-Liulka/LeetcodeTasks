using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ZigzagConversion;

public class Program
{
	public static void Main(string[] args)
	{
		//var result1 = new Solution().Convert("PAYPALISHIRING", 3);
		//var result2 = new Solution().Convert("PAYPALISHIRING", 4);
		var result3 = new Solution().Convert("ABC", 2);

		//Console.WriteLine(result1.Equals("PAHNAPLSIIGYIR"));
		//Console.WriteLine(result2.Equals("PINALSIGYAHRPI"));

		Console.Read();
	}

}

public class Solution
{
	public string Convert(string s, int numRows)
	{

		if (s.Length <= 2 || numRows < 2)
		{
			return s;
		}
		const int lenght = 7;
		var reversedArray = new char[lenght][];
		int symbolsConverted = 0;
		reversedArray[0] = s.Substring(0, numRows).ToCharArray();
		symbolsConverted += numRows;

		var lastArrayLack = 0;

		var intermediateCounter = numRows-2;

		for (int i = 1; i < lenght; i++)
		{
			if (i % (numRows-1) == 0 && i > 1)
			{
				var nextSubStringLenght = (s.Length - symbolsConverted > numRows ? numRows : s.Length - symbolsConverted);

				if (nextSubStringLenght < numRows)
				{
					lastArrayLack = numRows - nextSubStringLenght;
				}

				reversedArray[i] = s.Substring(symbolsConverted, nextSubStringLenght).ToCharArray();
				symbolsConverted += numRows;
				intermediateCounter = numRows - 2;
			}	
			else
			{
				var nextArray = new char[numRows];
				var nextSymbolToInsert = s[symbolsConverted++];

				nextArray[intermediateCounter] = nextSymbolToInsert;

				reversedArray[i] = nextArray;
				intermediateCounter--;
			}
		}
		StringBuilder finalString = new StringBuilder();

		for (int i = 0; i < numRows; i++)
		{
			if (i >= numRows - lastArrayLack)
			{
				finalString.Append(reversedArray.GetStringFromColumn(i, true));
			}
			else
			{
				finalString.Append(reversedArray.GetStringFromColumn(i, false));
			}
		}
		
		return finalString.ToString();
	}
}

public static class Extensions
{
	public static string GetStringFromColumn(this char[][] array, int column, bool lackOfLastRow)
	{
		return new string(Enumerable.Range(0, lackOfLastRow ? array.Length - 1 : array.Length)
			.Select(x => array[x][column])
			.Where(x => !x.Equals('\0'))
			.ToArray());
	}
}