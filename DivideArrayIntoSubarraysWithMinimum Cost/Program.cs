//https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-i/?envType=daily-question&envId=2026-02-01

public class Solution 
{
    public int MinimumCost(int[] nums)
    {
        int firstElem = nums[0];
        nums[0] = -1;
        Array.Sort(nums);
        return firstElem + nums[1] + nums[2];
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        int six = new Solution().MinimumCost([1, 2, 3, 4]);//1+2+3=6
        int six_2 = new Solution().MinimumCost([1,2,3,12]);//6
        int twelve = new Solution().MinimumCost([5,4,3]);//12
        int twelve_2 = new Solution().MinimumCost([10,3,1,1]);//12
    }
} 