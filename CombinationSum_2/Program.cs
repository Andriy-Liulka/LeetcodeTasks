//https://leetcode.com/problems/combination-sum-ii/

namespace CombinationSum_2
{
    public class Program
    {
        static void Main(string[] args)
        {
             var result = new Solution().CombinationSum2([10, 1, 2, 7, 6, 1, 5], 8);
             var result2 = new Solution().CombinationSum2([2, 5, 2, 1, 2], 5);
             var result3 = new Solution().CombinationSum2([1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1], 27);
             var result4 = new Solution().CombinationSum2([4, 4, 2, 1, 4, 2, 2, 1, 3], 6);

        }

    }

    public class Solution
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var resultList = new List<IList<int>>();

            var usageReport = new Dictionary<int, int>();
            foreach (var candidate in candidates)
            {
                var isPresent = usageReport.TryGetValue(candidate, out int value);
                if (isPresent)
                {
                    usageReport[candidate]++;
                }
                else
                {
                    usageReport.Add(candidate, 1);
                }
            }

            Find(ref resultList, new HashSet<int>(), usageReport, new List<int>(), candidates.ToHashSet(), 0, target);

            return resultList;
        }

        public void Find(ref List<IList<int>> resultSet, HashSet<int> existingElemsChecksums, Dictionary<int,int> availableItems, List<int> fillingList, HashSet<int> candidates, int currentSum, int target)
        {
            if (currentSum > target)
                return;

            if (currentSum == target)
            {
                var elemsChecksum = CalculateChecksum(fillingList);

                if (!existingElemsChecksums.Contains(elemsChecksum))
                {
                    resultSet.Add(new List<int>(fillingList));
                    existingElemsChecksums.Add(elemsChecksum);
                }
                return;
            }

            foreach (var candidate in candidates)
            {
                var sum = currentSum + candidate;
                var difference = target - sum;

                fillingList.Add(candidate);
                availableItems[candidate]--;

                var nextIterationCandidate = new HashSet<int>(candidates.Count);
                foreach (var subCandidate in candidates)
                {
                    var isAllowed = availableItems[subCandidate] > 0;
                    if (isAllowed && subCandidate <= difference)
                    {
                        nextIterationCandidate.Add(subCandidate);
                    }
                }

                Find(ref resultSet,
                    existingElemsChecksums,
                    availableItems,
                    fillingList,
                    nextIterationCandidate, 
                    sum, 
                    target);

                fillingList.RemoveAt(fillingList.Count - 1);
                availableItems[candidate]++;
            }
        }

        private int CalculateChecksum(List<int> arr)
        {
            int hash = 30;
            for (int i = 0; i < arr.Count; i++)
                hash *= (arr[i] ^ 0x5A5A5A5A);

            return (int)(hash & 0x7FFFFFFF); ;
        }

    }
}
