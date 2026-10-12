//https://leetcode.com/problems/subarray-sum-equals-k

using System.Diagnostics;
using System.Globalization;

namespace SubarraySumEqualsK;

class Program
{
    static void Main(string[] args)
    {
        var sln = new SolutionDM_NormalMine();
         //Console.WriteLine(sln.SubarraySum([1,1,1],2)); //2
         //Console.WriteLine(sln.SubarraySum([1,2,3],3)); //2
        //Console.WriteLine(sln.SubarraySum([1, 1, 1, 1, 1, 1, 5, 3, 3, 4, 2, 2, 2],6)); //5
         //Console.WriteLine(sln.SubarraySum([1],0)); //0
        Console.WriteLine(sln.SubarraySum([-7, 4, 1, 2, -5, 8],3)); //3
        // Console.WriteLine(sln.SubarraySum([-5, 8],3)); //1
        // Console.WriteLine(sln.SubarraySum([-5, -5, -5],-10)); //2
        // Console.WriteLine(sln.SubarraySum([],-10)); //2
        // Console.WriteLine(sln.SubarraySum([2, -2, 2, -2, 2, -2, 2, -2, 2, -2,
        //                                         2, -2, 2, -2, 2, -2, 2, -2, 2, -2,
        //                                         2, -2, 2, -2, 2, -2, 2, -2, 2, -2,
        //                                         2, -2, 2, -2, 2, -2, 2, -2, 2, -2,
        //                                         2, -2, 2, -2, 2, -2, 2, -2, 2, -2,
        //                                         2, -2, 2, -2, 2, -2, 2, -2, 2, -2,
        //                                         2, -2, 2, -2, 2, -2, 2, -2, 2, -2,
        //                                         2, -2, 2, -2, 2, -2, 2, -2, 2, -2,
        //                                         2, -2, 2, -2, 2, -2, 2, -2, 2, -2,
        //                                         2, -2, 2, -2, 2, -2, 2, -2, 2, -2],2)); //1225
        using (new TimeChecker())
        {
            Console.WriteLine(sln.SubarraySum(GenerateBigTestCase(50_000), 2));
        }

    }

    private static int[] GenerateBigTestCase(int elements)
    {
        int number = 2;
        int negativeNumber = number * -1;
        bool isOdd = true;
        var list = new List<int>(elements);
        for (int i = 0; i < elements; i++)
        {
            if (isOdd)
            {
                list.Add(number);
                isOdd = false;
            }
            else
            {
                list.Add(negativeNumber);
                isOdd = true;
            }
        }
        return list.ToArray();
    }
}

public class Solution
{
    public int SubarraySum(int[] nums, int k) {
        int currentNumber = 0;
        int left = 0;
        int right = 0;
        int numberOfSubarrays = 0;
        while(right < nums.Length)
        {
            currentNumber += nums[right];
            if(currentNumber == k)
                numberOfSubarrays++;
            while(currentNumber >= k && left < right)
            {
                currentNumber -= nums[left];
                left++;
                if(currentNumber == k && left >= right)
                    numberOfSubarrays++;
            }
            // while(currentNumber < k && left < right)
            // {
            //     currentNumber -= nums[left];
            //     left++;
            //     if(currentNumber == k && left >= right)
            //         numberOfSubarrays++;
            // }
            right++;
        }
        return numberOfSubarrays;
    }
}

public class SolutionBruteForce
{
    public int SubarraySum(int[] nums, int k)
    {
        int left = 0;
        int numberOfSubarrays = 0;
        while (left < nums.Length)
        {
            int sum = 0;
            int right = left;
            while (right < nums.Length)
            {
                sum += nums[right];
                if (sum == k)
                {
                    numberOfSubarrays++;
                }
                right++;
            }
            left++;
        }
        return numberOfSubarrays;
    }
}

public class SolutionDM
{
    public int SubarraySum(int[] nums, int k)
    {
        int left = 0;
        int numberOfSubarrays = 0;
        Dictionary<int, int> sums = new Dictionary<int, int>();
        while (left < nums.Length)
        {
            int sum = 0;
            int right = left;
            while (right < nums.Length)
            {
                if (sums.TryGetValue(left, out var prevSumLeft) && sums.TryGetValue(right, out var prevSumRight))
                {
                    sum = prevSumRight - prevSumLeft;
                }
                else
                {
                    sum += nums[right];
                    if (left == 0)
                    {
                        sums[right] = sum;
                    }
                }
                if (sum == k)
                {
                    numberOfSubarrays++;
                }
                right++;
            }
            left++;
        }
        return numberOfSubarrays;
    }
}

public class SolutionDM_Normal {
    public int SubarraySum(int[] nums, int k) {
        Dictionary<int, int> prefixSumCounts = new(nums.Length + 1)
        {
            [0] = 1
        };

        int subarrayCount = 0;
        int prefixSum = 0;

        foreach (int num in nums)
        {
            prefixSum += num;
            int targetPrefixSum = prefixSum - k;

            prefixSumCounts.TryGetValue(targetPrefixSum, out int count);
            subarrayCount += count;

            prefixSumCounts.TryGetValue(prefixSum, out count);
            prefixSumCounts[prefixSum] = count + 1;
        }

        // foreach (var (key, value) in prefixSumCounts)
        // {
        //     Console.WriteLine($"key:{key} value:{value}");
        // }
        return subarrayCount;
    }
}

public class SolutionDM_NormalMine
{
    public int SubarraySum(int[] nums, int k)
    {
        Dictionary<int, int> prefixSumCounts = new(nums.Length) { {0, 1}};
        int subarrayCount = 0;
        int sum = 0;
        foreach (int numItem in nums)
        {
            sum += numItem;
            int prefix = sum - k;

            int count = 0;
            prefixSumCounts.TryGetValue(prefix, out count);
            subarrayCount += count;

            prefixSumCounts.TryGetValue(sum, out count);
            prefixSumCounts[sum] = count + 1;
        }
        return subarrayCount;
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