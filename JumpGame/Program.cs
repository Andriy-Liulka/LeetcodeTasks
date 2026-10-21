//https://leetcode.com/problems/jump-game

namespace JumpGame;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.CanJump([2, 3, 1, 1, 4])); //true
        Console.WriteLine(sln.CanJump([3,2,1,0,4])); // false
        Console.WriteLine(sln.CanJump([2, 1, 4, 3, 4, 1, 0, 0, 0, 1])); // false
        Console.WriteLine(sln.CanJump([20, 1, 4, 3, 4, 1, 0, 0, 0, 1])); // true
        Console.WriteLine(sln.CanJump([0,1])); // false
    }
}

public class Solution
{
    public bool CanJump(int[] nums)
    {
        int maxIndex = 0;
        for (int i = 0; i <= maxIndex && i < nums.Length; i++)
            maxIndex = Math.Max(maxIndex, i + nums[i]);
        return maxIndex >= nums.Length -1;
    }
}