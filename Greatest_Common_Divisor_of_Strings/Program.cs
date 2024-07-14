using System.Text;

namespace Greatest_Common_Divisor_of_Strings;

internal class Program
{
    static void Main(string[] args)
    {
        var executor = new Solution();
        Console.WriteLine(executor.GcdOfStrings("ABCABC", "ABC"));
        Console.WriteLine(executor.GcdOfStrings("ABABAB", "ABAB"));
        Console.WriteLine(executor.GcdOfStrings("LEET", "CODE"));
    }
}
public class Solution
{
    public string GcdOfStrings(string str1, string str2)
    {
        var strArray1 = str1.ToList();
        var strArray2 = str2.ToList();
        string division = String.Empty;
        string mainStr = str1.Length < str2.Length ? str1 : str2;
        List<char> mainList = mainStr.ToList();

        for (int i = 1; i <= mainList.Count; i++)
        {
            var comparer = new StringBuilder(mainStr, 0, i, 1000);
            var subList1 = str1.Chunk(i);
            var subList2 = str2.Chunk(i);
            bool result1 = subList1.All(x => new String(x).Contains(comparer.ToString()));
            bool result2 = subList2.All(x => new String(x).Contains(comparer.ToString()));
            if (result1 && result2)
            {
                division = comparer.ToString();
            }
            else
            {
                if (comparer.Length > mainList.Count)
                {
                    break;
                }
            }
        }
        return division;
    }
}
