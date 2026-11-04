namespace MinimumPathSum;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution4Optimal();
        //Console.WriteLine(sln.MinPathSum([[1,3,1],[1,5,1],[4,2,1]])); //7
        Console.WriteLine(sln.MinPathSum([[1,2,3],[4,5,6]])); //12
        // Console.WriteLine(sln.MinPathSum([[1,3,6,6],
        //                                        [1,5,3,2],
        //                                        [4,4,1,1],
        //                                        [4,2,3,1]])); //13
    }
}

public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        int min = int.MaxValue;
        Search(0,0,grid,0, ref min);
        return min;
    }

    private static void Search(int i, int j, int[][] grid, int currentSum, ref int minSoFar)
    {
        if (currentSum > minSoFar)
            return;
        if(i >= grid.Length || j >= grid[0].Length)
            return;
        if(i == grid.Length - 1 && j == grid[0].Length - 1)
        {
            minSoFar = Math.Min(currentSum + grid[i][j], minSoFar);
            return;
        }
        Search(i, j + 1, grid, currentSum + grid[i][j], ref minSoFar);
        Search(i + 1, j, grid,currentSum + grid[i][j], ref minSoFar);
    }
}

public class Solution2
{
    public int MinPathSum(int[][] grid)
    {
        int[,] passedWays = new int[grid.Length, grid[0].Length];
        passedWays[grid.Length - 1, grid[0].Length - 1] = int.MaxValue;
        Search(0,0,grid,passedWays,0);
        return passedWays[grid.Length - 1, grid[0].Length - 1];
    }

    private static void Search(int i, int j, int[][] grid, int[,] passedWays, int currentSum)
    {
        int lastI = grid.Length - 1;
        int lastJ = grid[0].Length - 1;

        if (currentSum > passedWays[lastI, lastJ])
            return;
        if(i >= grid.Length || j >= grid[0].Length)
            return;
        if(i == grid.Length - 1 && j == grid[0].Length - 1)
        {
            passedWays[lastI, lastJ] = Math.Min(currentSum + grid[i][j], passedWays[lastI, lastJ]);
            return;
        }
        int newSum = currentSum + grid[i][j];
        if (passedWays[i,j] == 0 || passedWays[i,j] > newSum)
            passedWays[i, j] = newSum;
        else if(passedWays[i, j] <= newSum)
            return;

        Search(i, j + 1, grid, passedWays, newSum);
        Search(i + 1, j, grid,passedWays, newSum);
    }
}

public class Solution3
{
    public int MinPathSum(int[][] grid)
    {
        int min = int.MaxValue;
        var result = Search(0,0,grid,0, ref min);
        return min;
    }

    private static int Search(int i, int j, int[][] grid, int currentSum, ref int minSoFar)
    {
        if(currentSum > minSoFar)
        {
            return int.MaxValue;
        }
        if(i >= grid.Length || j >= grid[0].Length)
        {
            return int.MaxValue;
        }
        if(i == grid.Length - 1 && j == grid[0].Length - 1)
        {
            var res = currentSum + grid[i][j];
            minSoFar = Math.Min(res, minSoFar);
            return int.MaxValue;
        }
        var left = Search(i, j + 1, grid, currentSum + grid[i][j], ref minSoFar);
        var bottom = Search(i + 1, j, grid,currentSum + grid[i][j], ref minSoFar);

        return Math.Min(left, bottom);
    }
}

public class SolutionOptimalCopied
{
    public int MinPathSum(int[][] grid)
    {
        Show.ShowArr(grid);
        for (int i = grid.Length - 1; i >= 0; i--)
        {
            for (int j = grid[0].Length - 1; j >= 0; j--)
            {
                if (i == grid.Length - 1 && j != grid[0].Length - 1)
                {
                    grid[i][j] += grid[i][j + 1];
                }
                else if (j == grid[0].Length - 1 && i != grid.Length - 1)
                {
                    grid[i][j] += grid[i + 1][j];
                }
                else if (j != grid[0].Length - 1 && i != grid.Length - 1)
                {
                    grid[i][j] += Math.Min(grid[i + 1][j], grid[i][j + 1]);
                }
            }
        }
        Show.ShowArr(grid);
        return grid[0][0];
    }
}

public static class Show
{
    public static void ShowArr(int[][] grid)
    {
        Console.WriteLine("-------------");
        foreach (var subGrid in grid)
        {
            foreach (var item in subGrid)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("-------------");
    }
}


public class Solution4Optimal
{
    public int MinPathSum(int[][] grid)
    {
        for (int i = grid.Length - 1; i >= 0; i--)
        {
            for (int j = grid[0].Length - 1; j >= 0; j--)
            {
                if (i == grid.Length - 1 && j != grid[0].Length - 1)
                {
                    grid[i][j] += grid[i][j + 1];
                }
                else if (j == grid[0].Length - 1 && i != grid.Length - 1)
                {
                    grid[i][j] += grid[i + 1][j];
                }
                else if (i != grid.Length - 1 && j != grid[0].Length - 1)
                {
                    grid[i][j] += Math.Min(grid[i + 1][j], grid[i][j + 1]);
                }
            }
        }
        return grid[0][0];
    }
}