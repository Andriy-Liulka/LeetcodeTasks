//https://leetcode.com/problems/letter-combinations-of-a-phone-number/

namespace LetterCombinationsOfPhoneNumber;

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        Show(solution.LetterCombinations("29"));
        //Show(solution.LetterCombinations("23456789"));
        Show(solution.LetterCombinations("9"));
    }

    private static void Show( IList<string> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}

public class Solution
{
    private static Dictionary<char, string> _map = new()
    {
        ['2'] = "abc",
        ['3'] = "def",
        ['4'] = "ghi",
        ['5'] = "jkl",
        ['6'] = "mno",
        ['7'] = "pqrs",
        ['8'] = "tuv",
        ['9'] = "wxyz"
    };

    public IList<string> LetterCombinations(string digits)
    {
        var list = new List<string>((int)Math.Pow(3, digits.Length));
        TakeNext(list, digits);
        return list;
    }

    private static void TakeNext(List<string> list, string digits, int index = 0, string currentCombination = "")
    {
        if (index >= digits.Length)
        {
            list.Add(currentCombination);
            return;
        }

        foreach (var symbol in _map[digits[index]])
            TakeNext(list, digits, index + 1, currentCombination + symbol);
    }
}