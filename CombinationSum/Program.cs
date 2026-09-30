//https://leetcode.com/problems/combination-sum

namespace CombinationSum;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();
        //Show(sln.CombinationSum([2,3,6,7],7));
        //Show(sln.CombinationSum([1,2,3,4,5],7));
        Show(sln.CombinationSum([7,3,2],18));
    }

    private static void Show(IList<IList<int>> result)
    {
        Console.WriteLine("Result:");
        foreach (var item in result)
        {
            Console.Write("[" + string.Join(",", item) + "]");
        }
        Console.WriteLine();
    }
}

public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> resultSet = new List<IList<int>>(target);
        Array.Sort(candidates);
        BrowseNext(candidates.Length - 1, candidates, target, new Stack<int>(), 0, resultSet);
        return resultSet;
    }

    private static void BrowseNext(
        int index,
        int[] candidates,
        int target,
        Stack<int> elems,
        int sum,
        IList<IList<int>> resultSet)
    {
        for (int i = index; i >= 0; i--)
        {
            var newSum = sum + candidates[i];
            if (newSum > target)
            {
                if (candidates[0] + sum > target)
                    return;
                continue;
            }
            if (newSum < target)
            {
                elems.Push(candidates[i]);
                BrowseNext(i, candidates, target, elems, newSum, resultSet);
                elems.Pop();
            }
            else if (newSum == target)
            {
                elems.Push(candidates[i]);
                resultSet.Add(elems.ToList());
                elems.Pop();
            }
        }
    }
}