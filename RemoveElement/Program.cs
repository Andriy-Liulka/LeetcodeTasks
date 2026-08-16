//https://leetcode.com/problems/remove-element/description/

namespace RemoveElement;

public class Solution {
    public int RemoveElement(int[] nums, int val)
    {
        int[] newArray = new int[nums.Length];
        Array.Copy(nums, newArray, nums.Length);
        int numberOfNeededElems = 0;
        int rewrittenArrayIndex = 0;
        for (int i = 0; i < newArray.Length; i++)
        {
            if (newArray[i] == val)
            {
                numberOfNeededElems++;
            }
            else
            {
                nums[rewrittenArrayIndex] = newArray[i];
                rewrittenArrayIndex++;
            }
        }

        return nums.Length - numberOfNeededElems;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        int[] array = [3, 2, 2, 3];
        var result = solution.RemoveElement(array, 3);

        int[] array1 = [0,1,2,2,3,0,4,2];
        var result1 = solution.RemoveElement(array1, 2);
    }
}