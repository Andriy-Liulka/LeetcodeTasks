//https://leetcode.com/problems/combination-sum-ii/

namespace CombinationSum_2
{
    public class Program
    {
        static void Main(string[] args)
        {
             var result = new Solution().CombinationSum2([], 0);

        }

    }

    public class Solution
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var possibleNumbers = candidates.Where(x => x <= target);
            var dictOccurrences = new Dictionary<int, int>();

            foreach (var possibleNumber in possibleNumbers)
            {
                var isPresent = dictOccurrences.ContainsKey(possibleNumber);

                if (isPresent)
                {
                    dictOccurrences[possibleNumber] += 1;
                }
                else
                {
                    dictOccurrences[possibleNumber] = 1;
                }
            }





            return new List<IList<int>>();
        }
    }
}
