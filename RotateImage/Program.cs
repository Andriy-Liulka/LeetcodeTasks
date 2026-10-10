//https://leetcode.com/problems/rotate-image

namespace RotateImage;

class Program
{
    static void Main(string[] args)
    {
        var sln = new SwapSolution();
        int[][] matrix = [[1,2,3],[4,5,6],[7,8,9]];
        sln.Rotate(matrix);
        Show(matrix);
    }

    public static void Show(int[][] matrix)
    {
        foreach (var item in matrix)
        {
            Console.WriteLine(string.Join(",", item));
        }
    }
}

public class Solution 
{
    public void Rotate(int[][] matrix)
    {
        Queue<int> elements = new Queue<int>();
        foreach (var t in matrix)
            foreach (var t1 in t)
                elements.Enqueue(t1);

        for(int i = matrix.Length - 1; i >= 0; i--)
        {
            for(int j = 0; j < matrix[i].Length; j++)
            {
                matrix[j][i] = elements.Dequeue();
            }
        }
    }
}

public class SwapSolution {
    public void Rotate(int[][] matrix) {
        //swap diagonally
        int row = matrix.Length, col = matrix[0].Length;
        for(int r = 0; r < row; r++) {
            for(int c = 0; c <= r; c++) {
                (matrix[r][c], matrix[c][r]) = (matrix[c][r], matrix[r][c]);
            }
        }

        Program.Show(matrix);
        for(int r = 0; r < row; r++) {
            for(int c = 0; c < col / 2; c++) {
                (matrix[r][c], matrix[r][col - 1 - c]) = (matrix[r][col - 1 - c], matrix[r][c]);
            }
        }
    }
}