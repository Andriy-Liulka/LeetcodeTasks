namespace MinimumDistanceToTheTargetElement;

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        Console.WriteLine(solution.GetMinDistance([5,3,6], 5 ,2));
        Console.WriteLine(solution.GetMinDistance([1,2,3,4,5], 3 ,4));
    }
}

public class Solution {
    public int GetMinDistance(int[] nums, int target, int start)
    {
        int i = start;
        int j = start;
        while (i >= 0 || j < nums.Length)
        {
            if (i >= 0 && nums[i] == target)
                return Math.Abs(i - start);
            if (j < nums.Length && nums[j] == target)
                return Math.Abs(j - start);
            i--;
            j++;
        }
        return 0;
    }
}