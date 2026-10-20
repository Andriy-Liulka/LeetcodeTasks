//https://leetcode.com/problems/spiral-matrix

namespace SpiralMatrix;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();
        Show(sln.SpiralOrder([[1,2,3],[4,5,6],[7,8,9]]));
        Show(sln.SpiralOrder([[1,2,3,4],[5,6,7,8],[9,10,11,12]]));
        Show(sln.SpiralOrder([[1,2,3,4,5]]));
        Show(sln.SpiralOrder([[1],[2],[3],[4],[5]]));
        Show(sln.SpiralOrder([[1,2],[3,4],[5,6],[7,8],[9,10]]));
        Show(sln.SpiralOrder([[1,2],[3,4]]));
        //1 2
        //3 4
        //5 6
        //7 8
        //9 10
    }

    private static void Show(IList<int> result)
    {
        Console.WriteLine("Result:");
        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int totalCells = matrix.Length * matrix[0].Length;
        IList<int> list = new List<int>(totalCells);
        int firstRow = 0;
        int lastRow = matrix.Length - 1;
        int firstColumn = 0;
        int lastColumn = matrix[0].Length - 1;
        do
        {
            for (int i = firstColumn; i <= lastColumn; i++)
                list.Add(matrix[firstRow][i]);
            firstRow++;
            for (int i = firstRow; i <= lastRow; i++)
                list.Add(matrix[i][lastColumn]);
            lastColumn--;
            for (int i = lastColumn; i >= firstColumn && lastRow >= firstRow; i--)
                list.Add(matrix[lastRow][i]);
            for (int i = lastRow - 1; i >= firstRow && lastColumn >= firstColumn; i--)
                list.Add(matrix[i][firstColumn]);
            firstColumn++;
            lastRow--;
        } while (list.Count < totalCells);
        return list;
    }
}