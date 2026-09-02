namespace RottingOranges;

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        Console.WriteLine(solution.OrangesRotting([
            [2, 1, 1],
            [1, 1, 0],
            [0, 1, 1]])); //4
        Console.WriteLine(solution.OrangesRotting([
            [2, 1, 1, 0],
            [1, 1, 0, 0],
            [0, 1, 1, 1],
            [0, 1, 1, 0]])); //5
        Console.WriteLine(solution.OrangesRotting([
            [2, 1, 1, 0],
            [1, 1, 0, 1],
            [0, 1, 1, 0],
            [0, 1, 1, 0]])); //-1
        Console.WriteLine(solution.OrangesRotting([[2,1,1],[0,1,1],[1,0,1]])); //-1
        Console.WriteLine(solution.OrangesRotting([[0,2]])); //0
    }
}

public class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        List<int[]> rottenApplesPairs = new List<int[]>();
        int freshApplesMaxNumber = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                int number = grid[i][j];
                if (number == 2)
                    rottenApplesPairs.Add([i, j]);
                else if (number == 1)
                    freshApplesMaxNumber++;
            }
        }

        if (freshApplesMaxNumber <= 0)
            return 0;

        return RotApples(grid, rottenApplesPairs, 0, 0, freshApplesMaxNumber);
    }

    private int RotApples(int[][] grid, List<int[]> rottenApplesPairs, int numberOfMinutes, int rottenApplesNumber,
        int freshApplesMaxNumber)
    {
        List<int[]> newRottenApplesList = new List<int[]>();
        foreach (int[] rottenApplesPair in rottenApplesPairs)
        {
            int i = rottenApplesPair[0];
            int j = rottenApplesPair[1];

            List<int[]> directions = GetAllPossibleDirections(i, j, grid.Length - 1, grid[0].Length - 1);
            foreach (int[] direction in directions)
            {
                int futureI = direction[0];
                int futureJ = direction[1];
                if (grid[futureI][futureJ] == 1)
                {
                    grid[futureI][futureJ] = 2;
                    newRottenApplesList.Add([futureI, futureJ]);
                }
            }
        }

        if (newRottenApplesList.Count <= 0 && rottenApplesNumber != freshApplesMaxNumber)
            return -1;
        if (newRottenApplesList.Count <= 0 && rottenApplesNumber == freshApplesMaxNumber)
            return numberOfMinutes;

        return RotApples(grid, newRottenApplesList, numberOfMinutes + 1, rottenApplesNumber + newRottenApplesList.Count,
            freshApplesMaxNumber);
    }

    private static List<int[]> GetAllPossibleDirections(int i, int j, int iMax, int jMax)
    {
        List<int[]> directions = new List<int[]>(4);
        if (i - 1 >= 0)
            directions.Add([i - 1, j]);
        if (j + 1 <= jMax)
            directions.Add([i, j + 1]);
        if (i + 1 <= iMax)
            directions.Add([i + 1, j]);
        if (j - 1 >= 0)
            directions.Add([i, j - 1]);
        return directions;
    }
}