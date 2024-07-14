//https://leetcode.com/problems/reverse-substrings-between-each-pair-of-parentheses/description/

namespace ReverseSubstringsBetweenEachPairOfParentheses;

public class Solution
{
    public string ReverseParentheses(string s)
    {
        var leftBreckerStach = new Stack<int>();
        var rightBrecketStack = new Queue<int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                leftBreckerStach.Push(i);
            }
            else if (s[i] == ')')
            {
                rightBrecketStack.Enqueue(i);
            }
        }
        var leftBreckersStackCount = leftBreckerStach.Count;
        for (int i = 0; i < leftBreckersStackCount; i++)
        {
            var leftBreckerIndex = leftBreckerStach.Pop();
            leftBreckerIndex = leftBreckerIndex < 0 ? 0 : leftBreckerIndex;

            var rightBreckerIndex = rightBrecketStack.Dequeue() - (i*2);

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
        var solutor = new Solution();
        //var result1 = solutor.ReverseParentheses("(abcd)");
        //var result2 = solutor.ReverseParentheses("(u(love)i)");
        //var result3 = solutor.ReverseParentheses("(ed(et(oc))el)");
        var result4 = solutor.ReverseParentheses("ta()usw((((a))))");
    }
}