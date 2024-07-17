//https://leetcode.com/problems/reverse-substrings-between-each-pair-of-parentheses/description/

namespace ReverseSubstringsBetweenEachPairOfParentheses;

//public class Solution
//{
//    public string ReverseParentheses(string s)
//    {
//        var leftBreckerStack = new Stack<int>();
//        var rightBrecketStack = new Stack<(int, int)>();
//        var queue = new Queue<int>();
//        queue.Enqueue(2);
//        queue.Dequeue();

//        var temporareRightStack = new Stack<int>();

//        for (int i = 0; i < s.Length; i++)
//        {
//            if (s[i] == '(')
//            {
//                FillQueue(ref rightBrecketStack, temporareRightStack);
//                temporareRightStack.Clear();

//                leftBreckerStack.Push(i);
//            }
//            else if (s[i] == ')')
//            {
//                temporareRightStack.Push(i);
//            }
//        }
//        FillQueue(ref rightBrecketStack, temporareRightStack);
//        temporareRightStack.Clear();

//        var leftBreckersStackCount = leftBreckerStack.Count;
//        for (int i = 0; i < leftBreckersStackCount; i++)
//        { 
//            var leftBreckerIndex = leftBreckerStack.Pop();
//            leftBreckerIndex = leftBreckerIndex < 0 ? 0 : leftBreckerIndex;

//            var (rightIndex, changeStap) = rightBrecketStack.Pop();

//            var rightBreckerIndex = rightIndex - (changeStap * 2);

//            string reverseCandidate = s.Substring(leftBreckerIndex + 1, rightBreckerIndex - leftBreckerIndex - 1);

//            var reversedString = ReverseString(reverseCandidate);

//            s = s.Remove(leftBreckerIndex, rightBreckerIndex - leftBreckerIndex + 1).Insert(leftBreckerIndex, reversedString);
//        }

//        return s;
//    }

//    private string ReverseString(string str)
//    {
//        return new string(str.Reverse().ToArray());
//    }

//    private void FillQueue(ref Stack<(int, int)> queue, Stack<int> fromQueue)
//    {
//        int iterator = fromQueue.Count - 1;
//        while (fromQueue.Count > 0)
//        {
//            queue.Push((fromQueue.Pop(), iterator));
//            iterator--;
//        }
//    }
//}

public class PositionStack<T>
{
    private int _size;
    private T?[] _array;
    private Stack<int> _emptyPlaceIndexes;
    private int _top;
    public int Count => _size;

    public PositionStack()
    {
        _top = 0;
        _array = new T[2];
        _emptyPlaceIndexes = new Stack<int>();
    }

    public void Push(T item)
    {
        var lastEmptyIndex = _emptyPlaceIndexes.Pop();

        _array[lastEmptyIndex] = item;
    }

    public T Pop()
    {
        if (_top < 0 || _array.Length <= 0)
        {
            throw new Exception("Error");
        }
        _size--;
        var elem = _array[--_top];

        return elem;
    }

    private void Resize()
    {
        var newArray = new T[_array.Length * 2];

        Array.Copy(_array, newArray, _array.Length);

        _array = newArray;
    }

    public void IncrementSize()
    {
        _size++;

        if (_size == _array.Length)
        {
            Resize();
        }
        _emptyPlaceIndexes.Push(_top);
        _top++;
    }
}

public class Solution2
{
    public string ReverseParentheses(string s)
    {
        var leftBrecketStack = new Stack<int>();
        var rightBreckerStack = new PositionStack<(int, int)>();
        int fullBrecketsCount = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                leftBrecketStack.Push(i);
                rightBreckerStack.IncrementSize();
            }
            else if (s[i] == ')')
            {
                rightBreckerStack.Push((i, fullBrecketsCount));
                fullBrecketsCount++;
            }
        }
        var brecketsCount = (leftBrecketStack.Count + rightBreckerStack.Count) / 2;
        for (int i = 0; i < brecketsCount; i++)
        {
            var leftBreckerIndex = leftBrecketStack.Pop();
            leftBreckerIndex = leftBreckerIndex < 0 ? 0 : leftBreckerIndex;

            var (rightIndex, changeStap) = rightBreckerStack.Pop();

            var rightBreckerIndex = rightIndex - (changeStap * 2);

            string reverseCandidate = s.Substring(leftBreckerIndex + 1, rightBreckerIndex - leftBreckerIndex - 1);

            var reversedString = ReverseString(reverseCandidate);

            s = s.Remove(leftBreckerIndex, rightBreckerIndex - leftBreckerIndex + 1).Insert(leftBreckerIndex, reversedString);
        }


        return s;
    }

    private string ReverseString(string str)
    {
        return new string(str.Reverse().ToArray());
    }

}


internal class Program
{
    static void Main(string[] args)
    {
        var solutor = new Solution2();
        var result1 = solutor.ReverseParentheses("(abcd)");
        var result2 = solutor.ReverseParentheses("(u(love)i)");
        var result3 = solutor.ReverseParentheses("(ed(et(oc))el)");
        var result4 = solutor.ReverseParentheses("ta()usw((((a))))");
        var result5 = solutor.ReverseParentheses("n(ev(t)((()lfevf))yd)cb()");
    }
}