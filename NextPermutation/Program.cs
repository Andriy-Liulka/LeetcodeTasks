//https://leetcode.com/problems/next-permutation

namespace NextPermutation;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();

        int[] arr1 = [1, 2, 3];
        sln.NextPermutation(arr1);
        Show(arr1); // 1 3 2
        
        int[] arr2 = [1, 2, 4, 3];
        sln.NextPermutation(arr2);
        Show(arr2); // 1 3 2 4
        
        int[] arr3 = [1, 1, 5];
        sln.NextPermutation(arr3);
        Show(arr3); // 1 5 1
        
        int[] arr4 = [4, 3, 2, 1];
        sln.NextPermutation(arr4);
        Show(arr4); // 1 2 3 4
        
        int[] arr5 = [1, 3, 2];
        sln.NextPermutation(arr5);
        Show(arr5); // 2 1 3
        
        int[] arr6 = [2, 3, 1];
        sln.NextPermutation(arr6);
        Show(arr6); // 3 1 2

        int[] arr7 = [1, 5, 1];
        sln.NextPermutation(arr7);
        Show(arr7); // 1 5 1
    }

    private static void Show(int[] nums)
    {
        Console.Write("[");
        foreach (int numb in nums)
        {
            Console.Write($" {numb} ");
        }
        Console.Write("]");
        Console.WriteLine();
    }
}

public class Solution
{
    public void NextPermutation(int[] nums) {
        for(int i = nums.Length-1; i > 0; i--)
        {
            bool isSwapFound = nums[i] > nums[i-1];
            if(nums[i] > nums[i-1] || i == 1)
            {
                int k = isSwapFound ? i : 0;
                for (int j = nums.Length - 1; j >= k; k++)
                {
                    (nums[k], nums[j]) = (nums[j], nums[k]);
                    j--;
                }
                if (!isSwapFound)
                    return;
                int n = i;
                while (nums[i-1] >= nums[n] && n < nums.Length)
                    n++;
                (nums[n], nums[i-1]) = (nums[i-1], nums[n]);
                return;
            }
        }
    }
}