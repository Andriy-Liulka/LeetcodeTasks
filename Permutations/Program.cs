//https://leetcode.com/problems/permutations/

namespace Permutations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result1 = new Solution().Permute([1, 2, 3]);
            var result2 = new Solution().Permute([0,1]);
            var result3 = new Solution().Permute([1]);
            var result4 = new Solution().Permute([1,2,3,4]);

        }
    }

    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var resultSet = new List<IList<int>>();
            PermuteInternal(resultSet, nums);
            return resultSet;
        }

        private void PermuteInternal(IList<IList<int>> resultList, int[] nums, int startIndex = 0)
        {
            for (int i = startIndex; i < nums.Length; i++)
            {
                if (startIndex >= nums.Length - 1)
                {
                    resultList.Add(new List<int>(nums));
                    return;
                }

                Swap(startIndex, i, nums);
                PermuteInternal(resultList, nums, startIndex + 1);
                Swap(startIndex, i, nums);
            }
        }

        private void Swap(int firstIndex, int secondIndex, int[] array)
        {
            (array[firstIndex], array[secondIndex]) = (array[secondIndex], array[firstIndex]);
        }
    }
}
