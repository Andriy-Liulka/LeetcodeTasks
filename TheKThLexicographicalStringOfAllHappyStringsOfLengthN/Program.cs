
using System.Diagnostics;

public class Solution {
    public string GetHappyString(int n, int k)
    {
        char[] happyStringStart = new char[n];
        Array.Fill(happyStringStart, 'a');
        
        string kThString = "";
        int currentIteration = 0;
        Find(ref kThString, k, ref currentIteration, happyStringStart, 0);
        
        return kThString;
    }

    private void Find(ref string kThString, int k, ref int currentIteration, char[] happyString, int depth)
    {
        if (depth >= happyString.Length)
        {
            for (int i = 0; i < happyString.Length - 1; i++)
            {
                if (happyString[i] == happyString[i + 1])
                {
                    return;
                }
            }
            currentIteration++;
            if (k == currentIteration)
            {
                kThString = new string(happyString);
            }
            
            return;
        }

        if (depth > 1 && happyString[depth - 1] == happyString[depth - 2])
        {
            return;
        }
        
        var maxDegreeOfHapiness = 3; // a, b, =)
        for (int i = 1; i <= maxDegreeOfHapiness; i++)
        {
            Find(ref kThString, k, ref currentIteration, happyString, depth + 1);
            
            happyString[depth]++;
        }

        happyString[depth] = 'a';
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        using (new TimeCounter(Console.WriteLine))
        {
            new Solution().GetHappyString(1, 3).Show();//"c"
            new Solution().GetHappyString(1, 4).Show();//""
            new Solution().GetHappyString(3, 9).Show();//"cab"
            new Solution().GetHappyString(4, 15).Show();//bcba
            new Solution().GetHappyString(10, 100).Show();//abacbabacb
        }


    }

    public static void Show(this string str)
    {
        Console.WriteLine($"Result: {str}");
    }
}

public class TimeCounter : IDisposable
{
    private Stopwatch _stopwatch =  new Stopwatch();
    private Action<string> _loggingCallback;

    public TimeCounter(Action<string> loggingCallback)
    {
        _loggingCallback = loggingCallback;
        _stopwatch.Start();
    }
    
    public void Dispose()
    {
        _stopwatch.Stop();
        _loggingCallback($"Execution took: {_stopwatch.Elapsed.TotalSeconds} s");
    }
}