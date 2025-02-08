//https://leetcode.com/problems/combination-sum-ii/

using System.Collections.Generic;

namespace CombinationSum_2
{
    public class Program
    {
        static void Main(string[] args)
        {
             var result = new Solution().CombinationSum2_2([10, 1, 2, 7, 6, 1, 5], 8);
             var result2 = new Solution().CombinationSum2_2([2, 5, 2, 1, 2], 5);

        }

    }

    public class Solution
    {
        public IList<IList<int>> CombinationSum2_2(int[] candidates, int target)
        {
            //target = 8
            //1 1 1 1 1 1 1 1 = 8
            //2 1 1 1 1 1 1   = 8
            //3 1 1 1 1 1     = 8
            //4 1 1 1 1       = 8
            //5 1 1 1         = 8
            //6 1 1           = 8
            //7 1             = 8
            //8               = 8

            //4 4

            //var array = new int[target];
            //Array.Fill(array, 0);
            //array[0] = target;
            //var cases = new List<int[]>();

            //while (array.Any(x => x != 1))

            //{
            //    var destinationArray = new int[target];
            //    Array.Copy(array, destinationArray, target);
            //    cases.Add(destinationArray);

            //}

            //IEnumerable<int> possibleNumbers = candidates.Where(x => x <= target);
            //var dictOccurrences = new Dictionary<int, int>();

            //foreach (var possibleNumber in possibleNumbers)
            //{
            //    var isPresent = dictOccurrences.ContainsKey(possibleNumber);
            //    if (isPresent)
            //    {
            //        dictOccurrences[possibleNumber] += 1;
            //    }
            //    else
            //    {
            //        dictOccurrences[possibleNumber] = 1;
            //    }
            //}

            //foreach (var number in possibleNumbers)
            //{
            //    var mandatoRyNumber = number;
            //    var usedElemsList

            //    while (true)
            //    {

            //    }
            //}

            var resultList = new List<IList<int>>();

            Find(ref resultList, new List<int>(), candidates, 0, target);


            //var template = new int[8];
            //Array.Fill(template, 1);

            //var list = new List<int>(target);

            //var usedDict = new Dictionary<int, int>();

            //while (template[(target/2)-1] != template[target/2] || template[target/2] != target/2) // end of possible values as only unique arrays should be included
            //{
            //    for (int i = 0; i < target; i++)
            //    {
            //        var value = template[i];

            //        if (dictOccurrences.TryGetValue(value, out _))
            //        {
            //            if (!usedDict.TryGetValue(value, out _))
            //            {
            //                usedDict[value] = 1;
            //                list.Add(value);
            //            }
            //            else
            //            {
            //                usedDict[value]++;
            //                list.Add(value);
            //            }
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }

            //    ToNextIteration(template, target);

            //    list.Clear();
            //    usedDict.Clear();
            //}


            return resultList;
        }

        public void Find( ref List<IList<int>> resultSet, List<int> fillingList, IEnumerable<int> candidates, int currentSum, int target)
        {
            if (currentSum > target)
                return;

            if(currentSum == target)
            {
                var list = new int[fillingList.Count];
                fillingList.CopyTo(list);
                resultSet.Add(list.ToList());
                return;
            }

            foreach (var candidate in candidates)
            {
                var sum = currentSum + candidate;
                var difference = target - sum;

                fillingList.Add(candidate);

                Find(ref resultSet, 
                    fillingList,
                    candidates
                    .TakeWhile(x => x != candidate).Concat(candidates.SkipWhile(x => x != candidate)).Skip(1)
                    .Where(x => x <= difference), 
                    sum, 
                    target);

                fillingList.Clear();
            }
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IEnumerable<int> possibleNumbers = candidates.Where(x => x <= target);
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

            var resultDictionary = new Dictionary<int, List<int>>();

            var dictUsedValuesOccurrences = new Dictionary<int, int>();

            foreach (var number in possibleNumbers)
            {
                if (!dictUsedValuesOccurrences.ContainsKey(number))
                {
                    dictUsedValuesOccurrences[number] = 1;
                }
                else
                {
                    dictUsedValuesOccurrences[number] += 1;
                }

                var localList = new List<int>{ number };
 
                var sum = number;
                int searchedValue = 0;

                while (sum != target)
                {
                    if (searchedValue == 0)
                    {
                        searchedValue = target - sum;
                    }

                    var isPresent = dictOccurrences.TryGetValue(searchedValue, out _);

                    if (isPresent && 
                        IsAllowed(dictOccurrences, dictUsedValuesOccurrences, searchedValue))
                    {
                        dictUsedValuesOccurrences[searchedValue] += 1;
                        sum += searchedValue;
                        localList.Add(searchedValue);
                    }
                    else
                    {
                        searchedValue--;

                        searchedValue--;
                        if (searchedValue == 0)
                        {
                            break;
                        }
                    }
                }

                if (sum == target)
                {
                    resultDictionary.TryAdd(CalculateChecksum(localList), localList);
                }

                dictUsedValuesOccurrences.Clear();
            }

            return new List<IList<int>>();
        }

        private void ToNextIteration(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= target)
                {
                    array[i] = 1;
                }
                else
                {
                    array[i]++;
                }
            }
        }

        private int CalculateChecksum(List<int> arr)
        {
            int checksum = 0;
            for (int i = 0; i < arr.Count; i++)
                checksum ^= arr[i];

            return checksum;
        }

        private bool IsAllowed(IDictionary<int, int> allowed, IDictionary<int, int> used, int intentValue)
        {
            if (!used.TryGetValue(intentValue, out _))
            {
                used[intentValue] = 0;
            }

            return allowed[intentValue] > used[intentValue];
        }
    }
}
