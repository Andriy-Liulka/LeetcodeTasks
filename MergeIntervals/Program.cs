//https://leetcode.com/problems/merge-intervals

namespace MergeIntervals;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution3();
        Show(sln.Merge([[1,3],[2,6],[8,10],[15,18]]));
        Show(sln.Merge([[1,4],[4,5]]));
        Show(sln.Merge([[4,7],[1,4]]));
        Show(sln.Merge([[1,3]]));
        Show(sln.Merge([[1,4],[0,2],[3,5]]));
        Show(sln.Merge([[2,3], [4,5], [6,7], [8,9], [1,10]]));
        Show(sln.Merge([[3,5],[0,0],[4,4],[0,2],[5,6],[4,5],[3,5],[1,3],[4,6],[4,6],[3,4]]));
    }

    private static void Show(int[][] intervals)
    {
        foreach(var interval in intervals)
        {
            Console.Write($"[{interval[0]}, {interval[1]}] ");
        }
        Console.WriteLine();
    }
}

public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        List<int[]> sortedIntervals = new List<int[]>(intervals.Length);
        HashSet<int> usedIndexes = new HashSet<int>();
        for(int i = 0; i < intervals.Length; i++)
        {
            if(usedIndexes.Contains(i))
                continue;
            int[] arrayToCheck = intervals[i];
            for(int j = i + 1; j < intervals.Length; j++)
            {
                if(IsOverlapping(arrayToCheck, intervals[j]))
                {
                    usedIndexes.Add(j);
                    arrayToCheck = Merge(arrayToCheck, intervals[j]);
                }
            }
            sortedIntervals.Add(arrayToCheck);
        }
        return sortedIntervals.ToArray();
    }
    private static bool IsOverlapping(int[] first, int[] second)
        => !(first[1] < second[0] || second[1] < first[0]);
    private static int[] Merge(int[] first, int[] second)
        => [Math.Min(first[0], second[0]), Math.Max(first[1], second[1])];
}

public class Solution2
{
    public int[][] Merge(int[][] intervals)
    {
        List<int[]> sortedIntervals = new List<int[]>(intervals.Length);
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        HashSet<int> arraysToSkip = new HashSet<int>(intervals.Length);
        for(int i = 0; i < intervals.Length; i++)
        {
            if (arraysToSkip.Contains(i))
                continue;
            for (int j = i; j < intervals.Length; j++)
            {
                if (arraysToSkip.Contains(j))
                    continue;
                if (IsOverlapping(intervals[i], intervals[j]))
                {
                    arraysToSkip.Add(j);
                    intervals[i] = Merge(intervals[i], intervals[j]);
                }
            }
            sortedIntervals.Add(intervals[i]);
        }
        return sortedIntervals.ToArray();
    }
    private static bool IsOverlapping(int[] first, int[] second)
        => !(first[1] < second[0] || second[1] < first[0]);
    private static int[] Merge(int[] first, int[] second)
        => [Math.Min(first[0], second[0]), Math.Max(first[1], second[1])];
}

public class Solution3
{
    public int[][] Merge(int[][] intervals)
    {
        List<int[]> sortedIntervals = new List<int[]>(intervals.Length);
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        int[] merged = intervals[0];
        int lastIndex = intervals.Length - 1;
        for(int i = 0; i <= lastIndex; i++)
        {
            if (i < lastIndex && AreOverlapping(merged, intervals[i + 1]))
                merged = Merge(merged, intervals[i + 1]);
            else
            {
                sortedIntervals.Add(merged);
                if (i < lastIndex)
                    merged = intervals[i + 1];
            }
        }
        return sortedIntervals.ToArray();
    }
    private static bool AreOverlapping(int[] first, int[] second)
        => !(first[1] < second[0] || second[1] < first[0]);
    private static int[] Merge(int[] first, int[] second)
        => [Math.Min(first[0], second[0]), Math.Max(first[1], second[1])];
}