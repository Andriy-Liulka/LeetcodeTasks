//https://leetcode.com/problems/longest-valid-parentheses

namespace LongestValidParentheses;

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution2();
        //Console.WriteLine(solution.LongestValidParentheses("(()())()"));
        //Console.WriteLine(solution.LongestValidParentheses("(((((((((((((((((((((((((()"));
        // Console.WriteLine(solution.LongestValidParentheses("(()()())((((()"));
        //Console.WriteLine(solution.LongestValidParentheses("(()())"));
        // Console.WriteLine(solution.LongestValidParentheses("()()()()()"));
        //Console.WriteLine(solution.LongestValidParentheses("()()()()(()"));
        // Console.WriteLine(solution.LongestValidParentheses("()()()()(())"));
        //Console.WriteLine(solution.LongestValidParentheses("()()()()(())))))"));
        //Console.WriteLine(solution.LongestValidParentheses("(()()())((((()(()(()))((((((()()())()()"));
        //Console.WriteLine(solution.LongestValidParentheses("(()()())((((()(()(()))"));
        //Console.WriteLine(solution.LongestValidParentheses("(()(((()"));
        //Console.WriteLine(solution.LongestValidParentheses(")()())()()("));
        Console.WriteLine(solution.LongestValidParentheses(")))))((((("));
    }
}

public class Solution
{
    public int LongestValidParentheses(string s)
    {
        int length = 0;
        int maxCompletedParenthesisLength = 0;

        _ = GoFurther(s, 0, 0, ref length, ref maxCompletedParenthesisLength);

        return maxCompletedParenthesisLength;
    }

    private static int GoFurther(
        string s,
        int index,
        int depth,
        ref int length,
        ref int maxCompletedParenthesisLength)
    {
        int pairs = 0;
        for (int i = index; i < s.Length; i++)
        {
            if (depth <= 0 && s[i] == ')')
            {
                length++;
                pairs = 0;
            }
            else if (s[i] == '(')
            {
                length++;
                pairs += GoFurther(s, i + 1, depth + 1, ref length, ref maxCompletedParenthesisLength);
                maxCompletedParenthesisLength = Math.Max(pairs, maxCompletedParenthesisLength);
                i = length - 1;
            }
            else
            {
                length++;
                pairs += 2;
                maxCompletedParenthesisLength = Math.Max(pairs, maxCompletedParenthesisLength);
                return pairs;
            }
        }
        return 0;
    }
}

//More optimal copied solution
public class Solution2 {
    public int LongestValidParentheses(string s) {

        int open = 0;
        int close = 0;
        int max = 0;

        foreach (var t in s)
        {
            if (t == '(') {
                open++;
            }
            if (t == ')') {
                close++;
            }
            if (open == close) {
                max = Math.Max(max, 2*close);
            }
            else if (close > open) {
                close = 0;
                open = 0;
            }
        }

        open = 0;
        close = 0;

        for (int b = s.Length-1; b > 0; b--) {
            if(s[b] == '(') {
                open++;
            }
            if (s[b] == ')') {
                close++;
            }
            if (open == close) {
                max = Math.Max(max, 2*open);
            }
            else if (open > close) {
                close = 0;
                open = 0;
            }
        }

        return max;
    }
}