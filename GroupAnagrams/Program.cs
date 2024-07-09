//https://leetcode.com/problems/group-anagrams/

namespace GroupAnagrams;

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, IList<string>> resultController = new Dictionary<string, IList<string>>();

        if (strs is null)
        {
            return new List<IList<string>>();
        }
        else if (strs.Length == 0)
        {
            return new List<IList<string>>();
        }
        else if (strs.Length == 1 && string.IsNullOrEmpty(strs[0]))
        {
            return new List<IList<string>> { new List<string> { String.Empty } };
        }


        for (int i = 0; i < strs.Length; i++)
        {
            var orderedStr = GetOrderedElem(strs[i]);
            if (resultController.ContainsKey(orderedStr))
            {
                resultController[orderedStr].Add(strs[i]);
            }
            else
            {
                var stringsCollector = new List<string> { strs[i] };

                resultController.Add(orderedStr, stringsCollector);
            }
        }

        return resultController.Values.ToList();
    }

    private string GetOrderedElem(string str)
    {
        return new string(str.Order().ToArray());
    }
}

public class Solution2
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<int, IList<string>> resultController = new Dictionary<int, IList<string>>();

        var array = Enumerable.Repeat(0, 26).ToArray();

        foreach (var str in strs)
        {

            foreach (var letter in str)
            {
                array[letter - 'a'] += 1;
            }

            if (!resultController.ContainsKey(array.GetHashCode()))
            {
                resultController.Add(array.GetHashCode(), new List<string> { str });
            }
            else
            {
                resultController[array.GetHashCode()].Add(str);
            }

            Array.Clear(array);
        }

        return resultController.Values.ToList();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var result1 = new Solution2().GroupAnagrams(["eat", "tea", "tan", "ate", "nat", "bat"]);
        var result2 = new Solution2().GroupAnagrams([""]);
        var result3 = new Solution2().GroupAnagrams(["a"]);


    }
}