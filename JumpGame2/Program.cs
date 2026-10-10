//https://leetcode.com/problems/jump-game-ii/

using System.Diagnostics;

namespace JumpGame2;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution4();
        using (new TimeChecker())
        {
             //Console.WriteLine(sln.Jump([2, 3, 0, 1, 4])); // 2
             //Console.WriteLine(sln.Jump([2, 3, 1, 1, 4])); // 2
             Console.WriteLine(sln.Jump([2, 3, 1, 4, 1, 2, 4, 3, 1])); // 4
             Console.WriteLine(sln.Jump([4, 1, 1, 1, 1])); // 1
             Console.WriteLine(sln.Jump([
                 8, 2, 4, 4, 4, 9, 5, 2, 5, 8, 8, 0, 8, 6, 9, 1, 1, 6, 3, 5, 1, 2, 6, 6, 0, 4, 8, 6, 0, 3, 2, 8, 7, 6, 5,
                 1, 7, 0, 3, 4, 8, 3, 5, 9, 0, 4, 0, 1, 0, 5, 9, 2, 0, 7, 0, 2, 1, 0, 8, 2, 5, 1, 2, 3, 9, 7, 4, 7, 0, 0,
                 1, 8, 5, 6, 7, 5, 1, 9, 9, 3, 5, 0, 7, 5
             ]));//13
        }
        
        
    }
}

public class Solution
{
    public int Jump(int[] nums)
    {
        int min = int.MaxValue;
        int[] visited = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
            visited[i] = -1;
        Find(nums, 0, 0, visited, ref min);
        return min;
    }

    private static void Find(int[] nums, int currIndex, int stepNumber, int[] visited, ref int min)
    {
        if (currIndex == nums.Length - 1)
        {
            if (stepNumber < min)
                min = stepNumber;
            return;
        }

        for (int i = 1; i <= nums[currIndex]; i++)
        {
            int nextIndex = currIndex + i;
            if (nextIndex >= nums.Length || stepNumber >= min)
                break;
            Find(nums, nextIndex, stepNumber + 1, visited, ref min);
        }
    }
}

public class Solution2
{
    public int Jump(int[] nums)
    {
        int[] memo = new int[nums.Length];
        Array.Fill(memo, -1);
        var result =  MinJumpsFrom(nums, 0, memo);
        return result;
    }

    private static int MinJumpsFrom(int[] nums, int currIndex, int[] memo)
    {
        if (currIndex >= nums.Length - 1)
            return 0;
        if (memo[currIndex] != -1)
            return memo[currIndex];

        int minJumps = int.MaxValue;
        int maxJump = nums[currIndex];
        for (int i = 1; i <= maxJump; i++)
        {
            int nextIndex = currIndex + i;
            if (nextIndex >= nums.Length)
                break;

            int jumpsFromNext = MinJumpsFrom(nums, nextIndex, memo);
            if (jumpsFromNext != int.MaxValue)
                minJumps = Math.Min(minJumps, 1 + jumpsFromNext);
        }
        memo[currIndex] = minJumps;
        return memo[currIndex];
    }
}

public class Solution3 {
    public int Jump(int[] nums) {
        int count = 0;
        int left = 0;
        int right = 0;
        while (right < nums.Length - 1)
        {
            var farthest = 0;
            //Console.WriteLine("Before For");
            for (var i = left; i < right + 1; i++)
            {
                //Console.WriteLine($"farthest: {farthest}, i: {i}, nums[i]: {nums[i]}");
                farthest = Math.Max(farthest, i + nums[i]);
            }
            left = right + 1;
            right = farthest;
            count++;
            //Console.WriteLine("After For");
            //Console.WriteLine($"left: {left}");
            //Console.WriteLine($"right: {right}");
            //Console.WriteLine($"count: {count}");
        }
        return count;
    }
}

public class Solution4
{
    public int Jump(int[] nums)
    {
        int right = 0;
        int left = 0;
        int count = 0;
        while (right < nums.Length - 1)
        {
            int fathest = 0;
            for (int i = left; i <= right; i++)
            {
                fathest = Math.Max(fathest, i + nums[i]);
            }
            left = right + 1;
            right = fathest;
            count++;
        }
        return count;
    }
}

public class CopiedTheFastestSolution {
    public int Jump(int[] nums) {
        int jumps = 0; int currentEnd = 0; int farthest = 0;
        for(int i=0; i<nums.Length-1; i++){
            farthest = Math.Max(farthest,i+nums[i]);
            if(i==currentEnd){
                currentEnd = farthest;
                jumps++;
            }
        }
        return jumps;
    }
}

public class TimeChecker : IDisposable
{
    private readonly Stopwatch _timer = Stopwatch.StartNew();

    public TimeChecker()
    {
        _timer.Start();
    }
    public void Dispose()
    {
        _timer.Stop();
        Console.WriteLine($"Took: {_timer.ElapsedMilliseconds} ms");
    }
}