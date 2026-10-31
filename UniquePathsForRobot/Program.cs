//https://leetcode.com/problems/unique-paths
//Was solved by https://www.youtube.com/watch?v=GhiRlhPlJ9Q

namespace UniquePathsForRobot;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.UniquePaths(20,20));
    }
}

public class Solution
{
    public int UniquePaths(int n, int m)
    {
        return CalcPath(n,m, new int[n+1,m+1]);
    }
    private static int CalcPath(int n, int m, int[,] arr)
    {
        if(n < 1 || m < 1)
            return 0;

        if(n == 1 && m == 1)
            return 1;

        if(arr[n,m] !=0)
            return arr[n,m];

        arr[n,m] = CalcPath(n-1,m,arr) + CalcPath(n,m-1,arr);
        return arr[n,m];
    }
}