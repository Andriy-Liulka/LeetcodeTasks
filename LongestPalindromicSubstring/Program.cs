namespace LongestPalindromicSubstring;

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();

        Console.WriteLine(solution.LongestPalindrome("babad")); 
        Console.WriteLine(solution.LongestPalindrome("ddgtdgabaggsr"));
        Console.WriteLine(solution.LongestPalindrome("dddddddddddddddddddddddddd"));
        Console.WriteLine(solution.LongestPalindrome("llllllllsm"));
        Console.WriteLine(solution.LongestPalindrome("d"));
        Console.WriteLine(solution.LongestPalindrome("klsdmfmatamanamataadd"));
        Console.WriteLine(solution.LongestPalindrome("klsdfdasfsadfasdfsdmfmatamanamataaddsdfsafsdf"));
        Console.WriteLine(solution.LongestPalindrome("cbbd"));
        // ata m anna m ata
        // atamannamata
    }
}

public class Solution {
    public string LongestPalindrome(string s) {
        int n = s.Length;
        bool[,] dp = new bool[n, n];
        int iPalindrome = 0;
        int jPalindrome = 0;

        for (int i = 0; i < n; i++)
        {
            dp[i, i] = true;
        }
        for (int i = 0; i < n - 1; i++)
        {
            dp[i, i + 1] = s[i] == s[i + 1];
            if (dp[i, i + 1])
            {
                iPalindrome = i;
                jPalindrome = i + 1;
            }
        }
        int circlesWithoutPalindrom = 0;
        for (int palindromeLength = 2; palindromeLength < n; palindromeLength++)
        {
            bool isPalindrome = false;
            for (int i = 0; i < n - palindromeLength; i++)
            {
                int j = i + palindromeLength;
                if (s[i] == s[j] && dp[i + 1, j - 1])
                {
                    isPalindrome = true;
                    circlesWithoutPalindrom = 0;
                    dp[i, j] = true;
                    iPalindrome = i;
                    jPalindrome = j;
                }
            }
            if (!isPalindrome)
            {
                circlesWithoutPalindrom++;
            }
            //Check even and odd substrings if we miss palindrome
            if (circlesWithoutPalindrom > 2)
                break;
        }
        return s.Substring(iPalindrome, jPalindrome - iPalindrome + 1);
    }
}

public class Solution2 {
    public string LongestPalindrome(string s) {
        int n = s.Length;
        bool[,] dp = new bool[n, n];
        int iPalindrome = 0;
        int jPalindrome = 0;

        for (int i = 0; i < n; i++)
        {
            dp[i, i] = true;
        }
        for (int i = 0; i < n - 1; i++)
        {
            if (s[i] == s[i + 1])
            {
                dp[i, i + 1] = true;
                iPalindrome = i;
                jPalindrome = i + 1;
            }
        }

        for (int palindromeLength = 2; palindromeLength < n; palindromeLength++)
        {
            for (int i = 0; i < n - palindromeLength; i++)
            {
                int j = i + palindromeLength;
                if (s[i] == s[j] && dp[i + 1, j - 1])
                {
                    dp[i, j] = true;
                    iPalindrome = i;
                    jPalindrome = j;
                }
            }
        }
        return s.Substring(iPalindrome, jPalindrome - iPalindrome + 1);
    }
}