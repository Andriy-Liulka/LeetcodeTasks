//https://leetcode.com/problems/search-in-rotated-sorted-array

namespace SearchInRotatedSortedArray;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();
        Console.WriteLine(sln.Search([1,2,3,4,5,6,7,8,9,10], 5)); // 4
        Console.WriteLine(sln.Search([4,5,6,7,0,1,2], 0)); // 4
        Console.WriteLine(sln.Search([4,5,6,7,0,1,2], 3)); // -1
        Console.WriteLine(sln.Search([4,5,6,7,8,9,10,11,12,13,0,1,2], 0)); // 10
        Console.WriteLine(sln.Search([4,5,6,7,8,9,10,11,12,13,0,1,2], 13)); // 9
        Console.WriteLine(sln.Search([5,1,2,3,4], 1)); // 1
        Console.WriteLine(sln.Search([5,1,2,3,4], 5)); // 0
    }
}

public class Solution
{
    public int Search(int[] nums, int target)
    {
        return Find(nums, 0, nums.Length - 1, target);
    }
    private static int Find(int[] nums, int indexLeft, int indexRight, int target)
    {
        if (indexLeft >= indexRight && nums[indexLeft] != target)
            return -1;
        int currentIndex = indexLeft + (indexRight - indexLeft) / 2;
        if (nums[currentIndex] == target)
            return currentIndex;
        if (nums[indexLeft] <= target && target < nums[currentIndex]
            ||
            (target >= nums[indexLeft] || target <= nums[currentIndex]) && nums[indexLeft] > nums[currentIndex])
            return Find(nums, indexLeft, currentIndex - 1, target);
        return Find(nums, currentIndex + 1, indexRight, target);
    }
}

