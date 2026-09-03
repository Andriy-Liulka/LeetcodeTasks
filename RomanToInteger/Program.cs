//https://leetcode.com/problems/roman-to-integer/description

namespace RomanToInteger;

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        Console.WriteLine(solution.RomanToInt("IV"));
        Console.WriteLine(solution.RomanToInt("MCMXCIV"));
        Console.WriteLine(solution.RomanToInt("XXI"));
    }
}

public class Solution {
    private readonly Dictionary<char, int> ValuesDictionary = new Dictionary<char, int>
    {
        ['I'] = 1,
        ['V'] = 5,
        ['X'] = 10,
        ['L'] = 50,
        ['C'] = 100,
        ['D'] = 500,
        ['M'] = 1000,
    };
    public int RomanToInt(string s)
    {
        int sum = 0;
        for(int i = 0; i < s.Length; i++)
        {
            if(i + 1 <= s.Length - 1){
                if(ValuesDictionary[s[i]] < ValuesDictionary[s[i + 1]])
                    sum -= ValuesDictionary[s[i]];
                else
                    sum += ValuesDictionary[s[i]];
            }
            else
                sum += ValuesDictionary[s[i]];
        }
        return sum;
    }
}