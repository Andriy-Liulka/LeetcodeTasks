//https://leetcode.com/problems/permutations-ii/

namespace Permutations_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result1 = new Solution().PermuteUnique([1, 2, 3]);
            var result2 = new Solution().PermuteUnique([0, 1]);
            var result3 = new Solution().PermuteUnique([1]);
            var result4 = new Solution().PermuteUnique([1, 2, 3, 4]);
            var result5 = new Solution().PermuteUnique([1, 1, 2]);
        }
    }

    public class Solution
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var resultSet = new List<IList<int>>();
            PermuteInternal(new HashSet<int>(), resultSet, nums);
            return resultSet;
        }

        public void PermuteInternal(HashSet<int> uniqueCheckSums, List<IList<int>> resultSet, int[] nums, int fixedElemIndex = 0)
        {
            var lastElemIndex = nums.Length - 1;

            for (int i = fixedElemIndex; i < nums.Length; i++)
            {
                if (fixedElemIndex >= lastElemIndex)
                {
                    var checkSum = CalculateChecksum(nums);
                    if (!uniqueCheckSums.Contains(checkSum))
                    {
                        resultSet.Add(new List<int>(nums));
                        uniqueCheckSums.Add(checkSum);
                    }
                    return;
                }
                else if (fixedElemIndex == i || nums[fixedElemIndex] == nums[i])
                {
                    PermuteInternal(uniqueCheckSums, resultSet, nums, fixedElemIndex + 1);
                }
                else
                {
                    Swap(i, fixedElemIndex, nums);
                    PermuteInternal(uniqueCheckSums, resultSet, nums, fixedElemIndex + 1);
                    Swap(i, fixedElemIndex, nums);
                }
            }
        }

        public void Swap(int firstIndex, int secondIndex, int[] array)
        {
            (array[firstIndex], array[secondIndex]) = (array[secondIndex], array[firstIndex]);
        }

        private int CalculateChecksum(int[] arr)
        {
            int hash = 15;
            for (int i = 0; i < arr.Length; i++)
            {
                hash = hash * 31 + arr[i];
            }

            return hash;
        }
    }
}
