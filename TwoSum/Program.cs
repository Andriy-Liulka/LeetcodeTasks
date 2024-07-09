using System.Linq;
using System.Xml;

namespace TwoSum;
public class Program
{
	public static void Main(string[] args)
	{
		var result1 = new Solution().TwoSum(new[] { 2, 7, 11, 15 },9);
		var result2 = new Solution().TwoSum(new[] { 3, 2, 4 }, 6);
		var result3 = new Solution().TwoSum(new[] { 3, 3 }, 6);
		var result4 = new Solution().TwoSum(new[] { 0, 4, 3, 0 }, 0);
		var result5 = new Solution().TwoSum(new[] { -1, -2, -3, -4, -5 }, -8);
		var result6 = new Solution().TwoSum(new[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11);
		Console.Read();
    }

}

public class Solution
{
	public int[] TwoSum(int[] nums, int target)
	{

		Dictionary<int,int> dict = new Dictionary<int,int>();

		for (int i = 0; i < nums.Length; i++)
		{
			if (dict.ContainsKey(target-nums[i]))
			{
				return new int[] { i, dict[target - nums[i]] };
			}
			else if(!dict.ContainsKey(nums[i]))
			{
				dict.Add(nums[i],i);
			}
		}

		return new int[2];
	}
}