namespace LongestSubstringWithoutRepeatingCharacters;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();

        Console.WriteLine( sln.LengthOfLongestSubstring("aaaaa"));
        Console.WriteLine( sln.LengthOfLongestSubstring("adad"));
        Console.WriteLine( sln.LengthOfLongestSubstring("abca4cbua"));
        Console.WriteLine( sln.LengthOfLongestSubstring("S"));
    }
}


//adad
//aaaaa

public class Solution {
    public int LengthOfLongestSubstring(string s)
    {
        int maxUniqueStringLength = 0;
        var uniqueValuesDict = new Dictionary<char, int>();
        var minTrustedIndex = 0;
        int localN = 0;

        for (int i = 0; i < s.Length; i++)
        {
            //No Duplicate symbol
            if (!uniqueValuesDict.ContainsKey(s[i]) || (uniqueValuesDict.TryGetValue(s[i], out var indexUnTrusted) && indexUnTrusted < minTrustedIndex))
            {
                uniqueValuesDict[s[i]] = i;
                localN++;
                if (localN > maxUniqueStringLength)
                {
                    maxUniqueStringLength = localN;
                }
            }
            //Duplicate symbol is noticed
            else if (uniqueValuesDict.TryGetValue(s[i], out var indexTrusted) && indexTrusted >= minTrustedIndex)
            {
                minTrustedIndex = indexTrusted + 1;
                uniqueValuesDict[s[i]] = i;

                localN = i - indexTrusted;
            }
        }
        return maxUniqueStringLength;
    }
}