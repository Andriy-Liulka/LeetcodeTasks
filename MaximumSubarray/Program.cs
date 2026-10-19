//https://leetcode.com/problems/maximum-subarray

namespace MaximumSubarray;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.MaxSubArray([-2, 1, -3, 4, -1, 2, 1, -5, 4])); //6
        Console.WriteLine(sln.MaxSubArray([1, 5, -8, 6, 4, -2, 4, 12])); //24
        Console.WriteLine(sln.MaxSubArray([5,4,-1,7,8])); //23
        Console.WriteLine(sln.MaxSubArray([-1, -5, -3, -10])); // -1
        Console.WriteLine(sln.MaxSubArray([-1, -5, -3, -10, 1])); // 1
    }
}

public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int[] sums = new int[nums.Length + 1];
        sums[0] = 0;
        int max = nums[0];
        int i = 0;
        for (int j = 1; j <= nums.Length; j++)
        {
            sums[j] = sums[j - 1] + nums[j - 1];
            max = Math.Max(sums[j] - sums[i], max);
            if (sums[j] - sums[i] < 0)
                i = j;
        }
        return max;
    }
}