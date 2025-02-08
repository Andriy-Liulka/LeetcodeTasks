//https://leetcode.com/problems/search-insert-position/description/

namespace SearchInsertPosition
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result1 = new Solution().SearchInsert([1, 3, 5, 6], 5); // Expected 2
            var result2 = new Solution().SearchInsert([1, 3, 5, 7], 6); // Expected 3
            var result3 = new Solution().SearchInsert([1, 3, 5, 6], 7); // Expected 4
            var result4 = new Solution().SearchInsert([1, 3, 5, 6, 7, 9, 10, 15, 18, 19, 23], 14); // Expected 7
        }
    }
    // 1 1 1 1 1 1
    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            var index = Search(0, nums.Length - 1, nums, target);

            return index;
        }

        public int Search(int startIndex, int endIndex, int[] nums, int target)
        {
            if (startIndex >= endIndex && nums[startIndex] > target)
            {
                return startIndex;
            }
            else if (startIndex >= endIndex && nums[startIndex] < target)
            {
                return startIndex + 1;
            }

            var middleIndex = startIndex + ((endIndex - startIndex) / 2);

            if (nums[middleIndex] < target)
            {
                return Search(middleIndex + 1, endIndex, nums, target);
            }
            else if(nums[middleIndex] > target)
            {
                return Search(startIndex, middleIndex - 1, nums, target);
            }
            else
            {
                return middleIndex;
            }
        }
    }
}
