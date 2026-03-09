//https://leetcode.com/problems/best-time-to-buy-and-sell-stock-v/description/

using System.Diagnostics;

namespace best_time_to_buy_and_sell_stock_v;

public class Solution {
    public long MaximumProfit(int[] prices, int k)
    {
        var precalculatedSet = new int[prices.Length][];
        for (int i = 0; i < precalculatedSet.Length; i++)
        {
            precalculatedSet[i] =  new int[i];
            for (int j = 0; j < precalculatedSet[i].Length; j++)
            {
                precalculatedSet[i][j] = Math.Abs(prices[i] - prices[j]);
            }
        }

        int maxEarned= 0;
        var dynamicCache = new Dictionary<DynamicCacheKey, HashSet<KeyCouple>>();

        Calculate(precalculatedSet, 0,k, ref maxEarned, 0, new HashSet<KeyCouple>(), dynamicCache);
        
        return maxEarned;
    }

    private void Calculate(
        int[][] precalculatedSet, 
        int transactionNumber, 
        int maxTransactionCount, 
        ref int maxEarned,
        int transactionSum,
        HashSet<KeyCouple> visitedSections,
        Dictionary<DynamicCacheKey, HashSet<KeyCouple>> dynamicCache)
    {
        if (visitedSections.Count > 0 && !dynamicCache.ContainsKey(new DynamicCacheKey(visitedSections)))
        {
            dynamicCache.Add(new DynamicCacheKey([..visitedSections]), new HashSet<KeyCouple>());
        }
        
        if (transactionNumber >= maxTransactionCount)
        {
            if (transactionSum > maxEarned)
            {
                maxEarned = transactionSum;
            }
            return;
        }

        for (int i = 0; i < precalculatedSet.Length; i++)
        {
            for (int j = 0; j < precalculatedSet[i].Length; j++)
            {
                if (dynamicCache.TryGetValue(new DynamicCacheKey(visitedSections), out var existingValue))
                {
                    if (existingValue.Contains(new KeyCouple(i, j)))
                    {
                        continue;
                    }
                }
                
                bool isBlocked = false;
                foreach (var visitedSection in visitedSections)
                {
                    var (visitedI, visitedJ) = visitedSection;
                    
                    if (visitedI >= i && j >= visitedJ)
                    {
                        isBlocked = true;
                        break;
                    }
                    else if (visitedI <= i && j <= visitedJ)
                    {
                        isBlocked = true;
                        break;
                    }
                    else if (i >= visitedI && visitedI >= j && j >= visitedJ)
                    {
                        isBlocked = true;
                        break;
                    }
                    else if (visitedI >= i && i >= visitedJ && visitedJ >= j)
                    {
                        isBlocked = true;
                        break;
                    }
                    else if(visitedI == i || visitedJ == j || visitedI == j || visitedJ == i)
                    {
                        isBlocked = true;
                        break;
                    }
                }

                if (isBlocked)
                {
                    if (transactionSum > maxEarned)
                    {
                        maxEarned = transactionSum;
                    }
                    continue;
                }

                if (dynamicCache.TryGetValue(new DynamicCacheKey(visitedSections), out var value))
                {
                    value.Add(new KeyCouple(i,j));
                }
                
                visitedSections.Add(new KeyCouple(i,j));
                Calculate(
                    precalculatedSet, 
                    transactionNumber + 1,
                    maxTransactionCount,
                    ref maxEarned,
                    transactionSum + precalculatedSet[i][j],
                    visitedSections,
                    dynamicCache
                    );
                visitedSections.Remove(new KeyCouple(i,j));
            }
        }
    }
}

public record KeyCouple(int i, int j);
public class DynamicCacheKey : IEquatable<DynamicCacheKey>
{
    public readonly HashSet<KeyCouple> _set;

    public DynamicCacheKey(HashSet<KeyCouple> set)
    {
        _set = set;
    }

    public override int GetHashCode()
    {
        var hashValueInit = 0;
        foreach (var item in _set)
        {
            hashValueInit ^= item.GetHashCode();
        }
        return hashValueInit;
    }
    
    public bool Equals(DynamicCacheKey? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return this.GetHashCode().Equals(other.GetHashCode());
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((DynamicCacheKey)obj);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        //var res1 = new Solution().MaximumProfit([1, 7, 9, 8, 2], 2);                   //14
        // var res2 = new Solution().MaximumProfit([12, 16, 19, 19, 8, 1, 19, 13, 9], 3); //36
        var res3 = new Solution().MaximumProfit([3,8,9,6,7], 2);                       //10
        // var res4 = new Solution().MaximumProfit([5,8], 1);                             //3
        // var res5 = new Solution().MaximumProfit([1,10], 1);                            //9
        // var res6 = new Solution().MaximumProfit([2,3,2,3,2,3,2,3], 4);                 //4
        // var res7 = new Solution().MaximumProfit([6,11,1,5,3,15,8], 3);                 //22
        //var res8 = new Solution().MaximumProfit([4,5,18,15,14,10,8,12,12,18,17,8,16], 6); //38
        var res9 = new Solution().MaximumProfit([1,2,3,4,5], 2); //4
        
        
    }
}

public class TimeChecker : IDisposable
{
    private readonly Stopwatch _timer = Stopwatch.StartNew();

    public TimeChecker()
    {
        _timer.Start();
    }
    public void Dispose()
    {
        _timer.Stop();
        Console.WriteLine(_timer.ElapsedMilliseconds);
    }
}