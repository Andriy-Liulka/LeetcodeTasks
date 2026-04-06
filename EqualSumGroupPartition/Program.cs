//https://leetcode.com/problems/equal-sum-grid-partition-i

public class Solution {
    public bool CanPartitionGrid(int[][] grid)
    {
        Span<long> verticalSums = stackalloc long[grid[0].Length];
        for (int i = 0; i < grid[0].Length; i++)
        {
            verticalSums[i] = 0;
        }
        Span<long> horizontalSums = stackalloc long[grid.Length];
        long globalSum = 0;
        int numberOfElements = 0;
        
        for (int i = 0; i < grid.Length; i++)
        {
            int localhorizontalSum = 0;
            for (int j = 0; j < grid[i].Length; j++)
            {
                globalSum += grid[i][j];
                localhorizontalSum += grid[i][j];
                verticalSums[j] += grid[i][j];
                numberOfElements++;
            }
            horizontalSums[i] =  localhorizontalSum;
        }
        
        double halfGSum = (double)globalSum / 2;

        long localHorizontalSum = 0;
        foreach (var sum in horizontalSums)
        {
            localHorizontalSum += sum;
            if (localHorizontalSum > halfGSum)
            {
                break;
            }
            if (localHorizontalSum == halfGSum)
            {
                return true;
            }
        }
        
        long localVerticalSum = 0;
        foreach (var sum in verticalSums)
        {
            localVerticalSum +=  sum;
            if (localVerticalSum > halfGSum)
            {
                break;
            }
            if (localVerticalSum == halfGSum)
            {
                return true;
            }
        }

        return false;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        new Solution().CanPartitionGrid([[1,4],[2,3]]).Show("true"); //true
        new Solution().CanPartitionGrid([[1,3],[2,4]]).Show("false"); // false
        new Solution().CanPartitionGrid([[1,1],[1,1]]).Show("true"); // true
        new Solution().CanPartitionGrid([[2,2,2],[3,3,3]]).Show("false"); // false
        new Solution().CanPartitionGrid([[4,4,4],[1,2,3]]).Show("false"); // false
        new Solution().CanPartitionGrid([[4,4],[1,2], [1,1]]).Show("false"); // false
        new Solution().CanPartitionGrid([[4,4],[1,1], [1,1]]).Show("true"); // true
        new Solution().CanPartitionGrid([[1],[2]]).Show("false"); // false
        new Solution().CanPartitionGrid([[1,2]]).Show("false"); // false
        new Solution().CanPartitionGrid([[28443],[33959]]).Show("false"); // false
        new Solution().CanPartitionGrid([[42047],[57775],[99822]]).Show("true"); // true
        new Solution().CanPartitionGrid([[1,1,1,1,1,1],[1,1,1,1,1,1]]).Show("true"); // true
        new Solution().CanPartitionGrid([[3,1,2,3],[11,3,4,1]]).Show("true"); // true
        new Solution().CanPartitionGrid([[3,1,2,3],[10,3,4,1]]).Show("false"); // false
    }

}

public static class Extensions
{
    public static void Show(this bool value, string expected)
    {
        Console.WriteLine($"Result: {value}, should be: {expected}");
    }
}
