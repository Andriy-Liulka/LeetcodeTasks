namespace CountCommasInRange;

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        //Console.WriteLine(solution.CountCommas(11280));
        Console.WriteLine(solution.CountCommas(100_000));
    }
}

public class Solution {
    public int CountCommas(int n)
    {
        // if (n < 1000)
        // {
        //     return 0;
        // }
        //
        // int numbersInDigit = (int)Math.Log10(n);
        //
        // int numberOf3ths = (int)Math.Round((decimal)numbersInDigit/3);
        //
        // var result = (int)(n - (Math.Pow(10, numbersInDigit))) + 1;
        //
        // return result * numberOf3ths;

        if (n < 1000)
            return 0;

        // int numberoOfCommas = 0;
        // for (int i = 1; i <= n; i++)
        // {
        //     int numberInDigit = (int)Math.Log10(i);
        //     int numberOfThirds = numberInDigit/3;
        //     numberoOfCommas += numberOfThirds;
        // }

        return n - 999;
    }
}