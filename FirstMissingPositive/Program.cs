//https://leetcode.com/problems/first-missing-positive/description

namespace FirstMissingPositive;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();
        // Console.WriteLine(sln.FirstMissingPositive([1,4,5,7,8,4,5,2,1,5,4, -20, -4, -3]));
        // Console.WriteLine(sln.FirstMissingPositive([1,2,3,4,5,6]));
        // Console.WriteLine(sln.FirstMissingPositive([2147483647]));
        Console.WriteLine(sln.FirstMissingPositive([1,2,3,10,2147483647,9]));
    }
}

public class Solution {
    public int FirstMissingPositive(int[] nums) {
        var uniqueNums = new HashSet<int>();
        int max = nums[0];
        foreach(int num in nums)
        {
            if(num > 0)
            {
                uniqueNums.Add(num);
                if(num > max)
                    max = num;
            }
        }
        long maxValue = (long)max + 1;
        for(int i = 1; i <= maxValue; i++)
        {
            if(!uniqueNums.Contains(i))
                return i;
        }
        return 1;
    }
}