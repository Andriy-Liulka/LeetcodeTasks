//https://leetcode.com/problems/find-unique-binary-string/description/?envType=daily-question&envId=2026-03-08

public class Solution
{
    public string FindDifferentBinaryString(string[] nums)
    {
        HashSet<string> availableValues = nums.ToHashSet();

        char[] myChars = new char[nums[0].Length];
        Array.Fill(myChars, '0');
        string result = "";

        var localStr = new string(myChars);
        if (!availableValues.Contains(localStr))
        {
            return localStr;
        }

        MoveThroughPossibleCombinations(
            ref result,
            nums[0].Length,
            availableValues,
            0,
            myChars);

        return result;
    }

    private void MoveThroughPossibleCombinations(
        ref string result,
        int elemSize,
        HashSet<string> availableValues,
        int shift,
        char[] originalStr)
    {
        if (!string.IsNullOrEmpty(result))
        {
            return;
        }

        for (int i = shift; i < elemSize; i++)
        {
            originalStr[i] = '1';
            var localStr = new string(originalStr);
            if (!availableValues.Contains(localStr))
            {
                result = localStr;
                return;
            }

            MoveThroughPossibleCombinations(ref result, elemSize, availableValues, shift + 1, originalStr);
            originalStr[i] = '0';
        }
    }
}

public static class Program
{
    public static void Main(string[] args)
    {

        new Solution().FindDifferentBinaryString(["01", "10"]).Show();
        new Solution().FindDifferentBinaryString(["00", "01"]).Show();
        new Solution().FindDifferentBinaryString(["111", "011", "001"]).Show();
        new Solution().FindDifferentBinaryString(["000", "100", "010", "001", "110", "101", "011"]).Show();
    }

    public static void Show(this string str)
    {
        Console.WriteLine(str);
    }
}
