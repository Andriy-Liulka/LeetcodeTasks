using System.Diagnostics;

namespace ClimbingStairs;

class Program
{
    static void Main(string[] args)
    {
        //var sln = new SolutionCopied();
        // Console.WriteLine(sln.ClimbStairs(1)); //1
        // Console.WriteLine(sln.ClimbStairs(2)); //2
        // Console.WriteLine(sln.ClimbStairs(3)); //3
        // Console.WriteLine(sln.ClimbStairs(4)); //5
        //Console.WriteLine(sln.ClimbStairs(5)); //8
        //  Console.WriteLine(sln.ClimbStairs(6)); //13
        // Console.WriteLine(sln.ClimbStairs(10)); //89
        //    Console.WriteLine(sln.ClimbStairs(20)); //
        //   Console.WriteLine(sln.ClimbStairs(35));
        // Console.WriteLine(sln.ClimbStairs(23));
        //Console.WriteLine();
        //Console.WriteLine(sln.ClimbStairs(24));
        //  Console.WriteLine(sln.ClimbStairs(35));
         // Console.WriteLine(sln.ClimbStairs(40));
         //Console.WriteLine(sln.ClimbStairs(45));
         //Test(50,100);
         using (new TimeChecker())
         {
             TestSolutionCopied(100,1000);
         }
         using (new TimeChecker())
         {
             TestSolution5(100,1000);
         }

    }

    private static void Test(int start = 1, int end = 45)
    {
        var sln = new Solution4();
        var sln2 = new SolutionCopied();
        for (int i = start; i <= end; i++)
        {
            Console.WriteLine($"{i}: {nameof(Solution4)}: {sln.ClimbStairs(i)} {nameof(SolutionCopied)}: {sln2.ClimbStairs(i)}");
        }
    }

    private static void TestSolutionCopied(int start = 1, int end = 45)
    {
        var sln2 = new SolutionCopied();
        for (int i = start; i <= end; i++)
        {
            sln2.ClimbStairs(i);
        }
    }
    private static void TestSolution5(int start = 1, int end = 45)
    {
        var sln2 = new Solution5();
        for (int i = start; i <= end; i++)
        {
            sln2.ClimbStairs(i);
        }
    }
}

public class Solution
{
    public int ClimbStairs(int n)
    {
        int possibleWays = 1; //We include n of [1 1 1 1 ...] right away
        Recurse(ref possibleWays, 0, n);
        return possibleWays;
    }

    private static void Recurse(ref int possibleWays, int startFrom, int n)
    {
        if (startFrom >= n)
        {
            possibleWays++;
            return;
        }

        int current = startFrom;
        for (int i = 0; i < n; i++)
        {
            current += i;
            current += 2;
            Recurse(ref possibleWays, current, n);
            current -= i;
            current -= 2;
        }
    }
}

public class Solution2
{
    public int ClimbStairs(int n)
    {
        int maxNumberOfTwos = n / 2;
        int visits = 0;
        for (int j = 0; j <= maxNumberOfTwos; j++)
        {
            Recurse(ref visits, 0, j, 0, n);
        }
        return visits;
    }

    private static void Recurse(
        ref int combinationsFound,
        int twosPlaced,
        int needToPlaceTwos,
        int currentPosition,
        int n)
    {
        if (twosPlaced == needToPlaceTwos)
        {
            combinationsFound++;
            return;
        }

        int increment = 0;
        for (int i = currentPosition + 1; i < n; i++)
        {
            currentPosition += increment;
            currentPosition += 2;
            Recurse(ref combinationsFound, twosPlaced + 1, needToPlaceTwos, currentPosition, n);
            currentPosition -= increment;
            currentPosition -= 2;
            increment++;
        }
    }
}

public class Solution3
{
    public int ClimbStairs(int n)
    {
        int visits = 0;
        for (int j = 0; j <= n / 2; j++)
            Recurse(ref visits, 0, j, 0, n);
        return visits;
    }

    private static void Recurse(
        ref int combinationsFound,
        int twosPlaced,
        int needToPlaceTwos,
        int currentPosition,
        int n)
    {
        if (twosPlaced == needToPlaceTwos)
        {
            combinationsFound++;
            return;
        }
        int increment = 0;
        for (int i = currentPosition + 1; i < n; i++)
        {
            Recurse(ref combinationsFound, twosPlaced + 1, needToPlaceTwos, currentPosition + increment + 2, n);
            increment++;
        }
    }
}

public class Solution4
{
    public int ClimbStairs(int n)
    {
        int maxNumberOfTwos = n / 2;
        long result = 0;
        for (int i = 0; i <= maxNumberOfTwos; i++)
        {
            int sumOfTheRest = n - (2 * i);
            int fullCombinationsNumber = sumOfTheRest + i;
            result += Fact(fullCombinationsNumber, i);
        }
        return (int)result;
    }
    private static long Fact(int n, int k)
    {
        if (k < 0 || k > n) 
            return 0;
        if (k == 0 || k == n) 
            return 1;

        // Symmetry property optimization
        if (k > n - k)
            k = n - k;

        long result = 1;
        for (int i = 1; i <= k; i++)
            result = result * (n - i + 1) / i;

        return result;
    }
}

public class Solution5
{
    public int ClimbStairs(int n)
    {
        long result = 0;
        for (int i = 0; i <= n / 2; i++)
            result += Fact(n - (2 * i) + i, i);
        return (int)result;
    }
    private static long Fact(int n, int k)
    {
        if (k < 0 || k > n)
            return 0;
        if (k == 0 || k == n)
            return 1;
        if (k > n - k)
            k = n - k;
        long result = 1;
        for (int i = 1; i <= k; i++)
            result = result * (n - i + 1) / i;
        return result;
    }
}

public class SolutionCopied
{
    public int ClimbStairs(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 2;

        for(int i = 2; i < n;i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n - 1];
    }
}

file class TimeChecker : IDisposable
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