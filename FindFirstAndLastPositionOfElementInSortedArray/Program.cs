namespace FindFirstAndLastPositionOfElementInSortedArray;
public class Program
{
	public static void Main(string[] args)
	{
		var result = new Solution().SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
		var result2 = new Solution().SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6);

		Console.Read();
	}



}

public class Solution
{
	public int[] SearchRange(int[] nums, int target)
	{
		var index = 0;
		var convertedValues = nums.ToDictionary(x => index++, x => x);

		var finalSelection = convertedValues.Where(x => x.Value == target);

		if (!finalSelection.Any())
		{
			return new int[] { -1, -1 };
		}

		return new int[] { finalSelection.First().Key, finalSelection.Last().Key };
	}
}