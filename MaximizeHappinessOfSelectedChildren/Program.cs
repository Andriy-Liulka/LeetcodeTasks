//https://leetcode.com/problems/maximize-happiness-of-selected-children/description/?envType=daily-question&envId=2025-12-25

public class Program
{
    public static void Main(string[] args)
    {
        var res1 = new Solution().MaximumHappinessSum([1, 2, 3], 2);    // 4
        var res2 = new Solution().MaximumHappinessSum([1, 1, 1, 1], 1); // 1
        var res3 = new Solution().MaximumHappinessSum([2, 3, 4, 5], 1); // 5
        var res4 = new Solution().MaximumHappinessSum([2,98,45], 1); // 98
        var res5 = new Solution().MaximumHappinessSum([12,1,42], 3); // 53

    }
}

public class Solution {
    public long MaximumHappinessSum(int[] happiness, int k)
    {
        Array.Sort(happiness);
        long maxHappiness = 0;
        for (int i = 1; i <= k; i++)
        {
            maxHappiness += Math.Max(0,happiness[^i] - (i - 1));
        }
        return maxHappiness;
    }
}