//https://leetcode.com/problems/find-the-length-of-the-longest-common-prefix/description/?envType=daily-question&envId=2026-05-21


public class Solution {
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        var uniqueArr1 = new HashSet<int>();
        var uniqueArr2 = new HashSet<int>();

        for (int i = 0; i < arr1.Length; i++)
        {
            for (int j = 0; j < arr2.Length; j++)
            {
                int valueToCompare_1 = arr1[i];
                int valueToCompare_2 = arr2[j];

                var valueToCompare_1_Length = GetLength(valueToCompare_1);
                var valueToCompare_2_Length = GetLength(valueToCompare_2);
                
                int biggerValue = valueToCompare_1_Length > valueToCompare_2_Length ? valueToCompare_1_Length : valueToCompare_2_Length;
                int smallerValue = valueToCompare_1_Length < valueToCompare_2_Length ? valueToCompare_1_Length : valueToCompare_2_Length;

                int lengthDifference = Math.Abs(valueToCompare_1_Length - valueToCompare_2_Length);

                int upgradedSmallValue = smallerValue * (lengthDifference * 10);
                
                
            } 
        } 
    }

    private int GetLength(int number)
    {
        return number == 0 ? 1 : (int)Math.Log10(Math.Abs(number)) + 1;
    }
}


public static class Program
{
    public static void Main(string[] args)
    {
        new Solution().LongestCommonPrefix();
    }


}