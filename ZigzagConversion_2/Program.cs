using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ZigzagConversion;

public class Program
{
	public static void Main(string[] args)
	{
		var result1 = new Solution().Convert("PAYPALISHIRING", 3);
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
		if (numRows == 1)
			return s;

		var result = new StringBuilder();
		var perIter = numRows * 2 - 2;
		for (int row = 0; row < numRows; row++)
		{
			int i = 0;
			while ((i + row) < s.Length)
			{
				result.Append(s[i + row]);
				if (row != 0 && row != numRows - 1)
				{
					if ((i + perIter - row) < s.Length)
					{
						result.Append(s[i + perIter - row]);
					
					}
				}

				i += perIter;
			}
		}
		return result.ToString();
	}
}