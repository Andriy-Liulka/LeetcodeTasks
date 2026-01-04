

public class Solution {
    public IList<IList<int>> Generate(int numRows) 
    {
        IList<IList<int>> triangle = new List<IList<int>>(numRows);
        for (int i = 0; i < numRows; i++)
        {
            var rowElem = new List<int>(i + 1);
            rowElem.Add(1);
            if (i == 0)
            {
                triangle.Add(rowElem);
                continue;
            }
                

            if (i == 1)
            {
                rowElem.Add(1);
                triangle.Add(rowElem);
                continue;
            }

            for (int j = 1; j < i; j++)
            {
                rowElem.Add(triangle[i-1][j - 1] + triangle[i-1][j]);
            }
            rowElem.Add(1);
            triangle.Add(rowElem);
        }

        return triangle;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var res1 =new Solution().Generate(5);
    }
}