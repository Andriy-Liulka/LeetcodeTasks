//https://leetcode.com/problems/combination-sum-ii/

namespace CombinationSum_2
{
    public class Program
    {
        static void Main(string[] args)
        {
             var result = new Solution().CombinationSum2([10, 1, 2, 7, 6, 1, 5], 8);
             var result2 = new Solution().CombinationSum2([2, 5, 2, 1, 2], 5);

        }

    }

    public class Solution
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var resultList = new List<IList<int>>();

            Find(ref resultList, new HashSet<int>(), new List<int>(), candidates.ToList(), 0, target);

            return resultList;
        }

        public void Find(ref List<IList<int>> resultSet, HashSet<int> existingElemsChecksums, List<int> fillingList, List<int> candidates, int currentSum, int target)
        {
            if (currentSum > target)
                return;

            if (currentSum == target)
            {
                var elemsChecksum = CalculateChecksum(fillingList);

                if (!existingElemsChecksums.Contains(elemsChecksum))
                {
                    var list = new int[fillingList.Count];
                    fillingList.CopyTo(list);
                    resultSet.Add(list.ToList());
                    existingElemsChecksums.Add(elemsChecksum);
                }
                return;
            }

            var uniqueElements = candidates.ToHashSet();
            for (int i = 0; i < uniqueElements.Count; i++)
            {
                var sum = currentSum + candidates[i];
                var difference = target - sum;

                fillingList.Add(candidates[i]);

                var nextIterationCandidate = new List<int>(candidates.Count - 1);
                for (int j = 0; j < candidates.Count; j++)
                {
                    if (i == j || candidates[j] > difference)
                    {
                        continue;
                    }
                    nextIterationCandidate.Add(candidates[j]);
                }

                Find(ref resultSet,
                    existingElemsChecksums,
                    fillingList,
                    nextIterationCandidate, 
                    sum, 
                    target);

                fillingList.RemoveAt(fillingList.Count - 1);
            }
        }

        private int CalculateChecksum(List<int> arr)
        {
            int hash = 30;
            for (int i = 0; i < arr.Count; i++)
                hash *= arr[i];

            return (int)(hash & 0x7FFFFFFF); ;
        }
    }
}
