using System.Linq;
using System.Text;

namespace ReverseInteger;

public class Program
{
	public static void Main(string[] args)
	{

		//var result1 = new Solution().Reverse(4);
		var result2 = new Solution().Reverse(-123);
		var result3 = new Solution().Reverse(56123);
		var result4 = new Solution().Reverse(1534236469);
		var result5 = new Solution().Reverse(-1534236469);

		var result22 = new Solution2().Reverse(-123);
		var result32 = new Solution2().Reverse(56123);
		var result42 = new Solution2().Reverse(1534236469);
		var result52 = new Solution2().Reverse(-1534236469);

		Console.Read();
	}

}

class Solution
{
	public int Reverse(int x)
	{
		var sign = x > 0 ? "+" : "-";

		var splittedNumber = sign.Equals("+") ? x.ToString().ToCharArray() : x.ToString().ToCharArray().Skip(1);

		splittedNumber = Enumerable.Reverse(splittedNumber);

		var number = String.Join(String.Empty, splittedNumber);

		var finalStringNumber = sign.Equals("+") ? new StringBuilder(number).ToString() : new StringBuilder(sign).Append(number).ToString();

		int result = default;
		var convertionResult = Int32.TryParse(finalStringNumber,out result);

		if (!convertionResult)
		{
			return 0;
		}

		return result;
	}
}


class Solution2
{
	public int Reverse(int x)
	{
		var sign = x > 0 ? "+" : "-";

		var splittedNumber = sign.Equals("+") ? x.ToString().ToCharArray() : x.ToString().ToCharArray().Skip(1);

		var splittedNumbersArray = Enumerable.Reverse(splittedNumber).ToArray();

		var numberBuilder = new StringBuilder(String.Empty);
		for (int i = 0; i < splittedNumbersArray.Length; i++)
		{
			numberBuilder.Append(splittedNumbersArray[i]);	
		}
		var number = numberBuilder.ToString();

		var finalStringNumber = sign.Equals("+") ? new StringBuilder(number).ToString() : new StringBuilder(sign).Append(number).ToString();

		int result = default;
		var convertionResult = Int32.TryParse(finalStringNumber, out result);

		if (!convertionResult)
		{
			return 0;
		}

		return result;
	}
}