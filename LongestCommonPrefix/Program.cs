namespace LongestCommonPrefix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var prefix1 = new Solution().LongestCommonPrefix(["flower", "flow", "flight"]); // "fl"
            var prefix2 = new Solution().LongestCommonPrefix(["dog", "racecar", "car"]);    // ""
            var prefix3 = new Solution().LongestCommonPrefix(["a"]);    // "a"
            var prefix4 = new Solution().LongestCommonPrefix([""]);    // ""
            var prefix5 = new Solution().LongestCommonPrefix(["ab","a"]);    // ""
        }
    }

    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {

            if (strs.Length == 0)
            {
                return String.Empty;
            }

            Dictionary<string, HashSet<string>> prefixes = new Dictionary<string, HashSet<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                if (String.IsNullOrEmpty(strs[i]))
                {
                    return String.Empty;
                }

                if (!prefixes.TryGetValue(strs[i], out _))
                {
                    prefixes[strs[i]] = new HashSet<string>();
                }

                for (int j = 0; j <= strs[i].Length; j++)
                {
                    var subStr = strs[i].Substring(0,j);
                    prefixes[strs[i]].Add(subStr);
                }
            }

            var word = strs[0];
            var prefix = String.Empty;

            for (int i = 1; i <= word.Length; i++)
            {
                prefix = word.Substring(0, i);

                foreach (var str in strs)
                {
                    if (!prefixes[str].Contains(prefix))
                    {
                        return prefix.Substring(0, prefix.Length - 1);
                    }
                }
            }

            return prefix;
        }
    }
}
