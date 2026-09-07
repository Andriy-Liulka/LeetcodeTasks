//https://leetcode.com/problems/generate-parentheses

using System.Diagnostics;

namespace GenerateParentheses;

class Program
{
    static void Main(string[] args)
    {
        //var solution = new Solution4();
        //Show(solution.GenerateParenthesis(3));

        using (new TimeChecker())
        {
            var solution2 = new Solution3();
            solution2.GenerateParenthesis(14);
        }

        using (new TimeChecker())
        {
            var solution2 = new Solution4();
            solution2.GenerateParenthesis(14);
        }
    }

    private static void Show(IList<string> result)
    {
        Console.WriteLine("Result");
        foreach (var item in result)
        {
            Console.Write(item+"  ,  ");
        }
    }
    public static void ShowCurrent(char[] array) => Console.WriteLine(new string(array));
}

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        int size = n * 2;
        IList<string> result = new List<string>(size);
        char[] initString = new char[size];

        for (int i = 1; i <= size; i++)
        {
            if (i % 2 != 0)
                initString[i - 1] = '(';
            else
                initString[i - 1] = ')';
        }
        result.Add(new string(initString));

        int swallowingNumber = 0;
        while (swallowingNumber < n - 1)
        {
            int endIndex = size - 1 - swallowingNumber;

            for (int i = swallowingNumber + 2; i <= endIndex; i += 2)
            {
                initString[i - 1] = initString[i];
                initString[i] = initString[i + 1];
                initString[i + 1] = ')';
                result.Add(new string(initString));
            }

            swallowingNumber++;
        }

        return result;
    }
}

public class Solution2
{
    public IList<string> GenerateParenthesis(int n)
    {
        int size = n * 2;
        IList<string> result = new List<string>(size);
        char[] initString = new char[size];

        for (int i = 1; i <= size; i++)
        {
            if (i % 2 != 0)
                initString[i - 1] = '(';
            else
                initString[i - 1] = ')';
        }
        result.Add(new string(initString));
        Program.ShowCurrent(initString);

        for (int fullSwallowingNumber = 0; fullSwallowingNumber < n - 1; fullSwallowingNumber++)
        {
            // True
            // |
            //()()()()()
            //False ->>
            //        |
            //()()()()()
            bool isLeft = true;
            int heapSize = 2;
            int swallowedNumber = 0;
            int maxToSwallow = n - fullSwallowingNumber - 1;
            while (swallowedNumber < maxToSwallow)
            {
                if (isLeft)
                {
                    SwallowNeighbour(initString, fullSwallowingNumber + heapSize - 1, isLeft: true);
                    swallowedNumber++;
                    heapSize += 2;
                    result.Add(new string(initString));
                    Program.ShowCurrent(initString);
                    for (int i = fullSwallowingNumber + heapSize - 1; i < size - fullSwallowingNumber - 1; i+=2)
                    {
                        int startIndex = i;
                        ShiftHeapOneStep(initString, startIndex, heapSize, true);
                        result.Add(new string(initString));
                        Program.ShowCurrent(initString);
                    }

                    isLeft = false;
                }
                else
                {
                    SwallowNeighbour(initString, size - heapSize - fullSwallowingNumber, isLeft: false);
                    swallowedNumber++;
                    heapSize += 2;
                    result.Add(new string(initString));
                    Program.ShowCurrent(initString);
                    for (int i = size - fullSwallowingNumber - heapSize; i > fullSwallowingNumber; i -= 2)
                    {
                        int startIndex = i;
                        ShiftHeapOneStep(initString, startIndex, heapSize, false );
                        result.Add(new string(initString));
                        Program.ShowCurrent(initString);
                    }
                    isLeft = true;
                }
            }
        }
        return result;
    }

    //Left -> eat left neighbour
    //Right -> eat right neighboiur
    //   |       - HeapIndex isLeft == true
    //(())()()()
    //        |  - HeapIndex isLeft == false
    //()()()()(())
    private static void SwallowNeighbour(char[] currentStr, int heapIndex, bool isLeft)
    {
        if (isLeft)
        {
            currentStr[heapIndex] = currentStr[heapIndex + 1];
            currentStr[heapIndex + 1] = currentStr[heapIndex + 2];
            currentStr[heapIndex + 2] = ')';
        }
        else
        {
            currentStr[heapIndex] = currentStr[heapIndex - 1];
            currentStr[heapIndex - 1] = currentStr[heapIndex - 2];
            currentStr[heapIndex - 2] = '(';
        }
    }

    private static void ShiftHeapOneStep(char[] currentStr, int startIndex, int size, bool isLeftDirection)
    {
        //isLeftDirection <<-
        //!isLeftDirection ->>
        //   |       - startIndex isLeft == true
        //(())()()()
        //        |  - startIndex isLeft == false
        //()()()()(())

        if (isLeftDirection)
        {
            for (int i = startIndex; i >= startIndex - size + 1; i--)
            {
                currentStr[i + 2] = currentStr[i];
            }
            currentStr[startIndex - size + 1] = '(';
            currentStr[startIndex - size + 2] = ')';
        }
        else
        {
            for (int i = startIndex; i < startIndex + size; i++)
            {
                currentStr[i - 2] = currentStr[i];
            }
            currentStr[startIndex + size - 2] = '(';
            currentStr[startIndex + size - 1] = ')';
        }
    }
}

class Solution3 {
    public List<String> GenerateParenthesis(int n) {
        List<string> res = new List<string>();
        Recurse(res, 0, 0, "", n);
        return res;
    }

    private static void Recurse(List<string> res, int left, int right, string s, int n) {
        if (s.Length == n * 2) {
            res.Add(s);
            return;
        }

        if (left < n) {
            Recurse(res, left + 1, right, s + "(", n);
        }

        if (right < left) {
            Recurse(res, left, right + 1, s + ")", n);
        }
    }
}

class Solution4
{
    public List<String> GenerateParenthesis(int n) {
        List<string> res = new List<string>();
        RecurseBrowse(res, 0, 0, new char[n * 2], 0, n);
        return res;
    }

    private static void RecurseBrowse(List<string>  res, int left, int right, char[] s, int index, int n)
    {
        if (index == n * 2 - 1)
        {
            s[index] = ')';
            res.Add(new string(s));
            return;
        }

        if (left < n)
        {
            s[index] = '(';
            RecurseBrowse(res, left + 1, right, s, index+1, n);
        }

        if (right < left)
        {
            s[index] = ')';
            RecurseBrowse(res, left, right + 1, s, index+1, n);
        }
    }
}

public class TimeChecker : IDisposable
{
    private readonly Stopwatch _timer = Stopwatch.StartNew();

    public TimeChecker()
    {
        _timer.Start();
    }
    public void Dispose()
    {
        _timer.Stop();
        Console.WriteLine(_timer.ElapsedMilliseconds);
    }
}