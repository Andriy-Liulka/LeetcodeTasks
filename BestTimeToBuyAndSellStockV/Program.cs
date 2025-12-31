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

        Calculate(precalculatedSet, 0,k, ref maxEarned, 0, new HashSet<(int, int)>());
        
        return maxEarned;
    }

    private void Calculate(
        int[][] precalculatedSet, 
        int transactionNumber, 
        int maxTransactionCount, 
        ref int maxEarned,
        int transactionSum,
        HashSet<(int,int)> visitedSections)
    {
        if (transactionNumber >= maxTransactionCount)
        {
            if (transactionSum > maxEarned)
            {
                maxEarned = transactionSum;
            }
            return;
        }

        // if (visitedSections.Min() > 1 || precalculatedSet.Length - visitedSections.Max() > 2)
        // {
        // }
        // else
        // {
        //     for (int i = 0; i < visitedSections.Count; i++)
        //     {
        //         
        //     }
        // }

        
        for (int i = 0; i < precalculatedSet.Length; i++)
        {
            for (int j = 0; j < precalculatedSet[i].Length; j++)
            {
                bool isBlocked = false;
                foreach (var visitedSection in visitedSections)
                {
                    var (visitedI, visitedJ) = visitedSection;
                    if (visitedI >= i && j <= visitedJ)
                    {
                        isBlocked = true;
                        break;
                    }
                    else if (visitedI <= i && j >= visitedJ)
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

                
                visitedSections.Add((i,j));
                Calculate(
                    precalculatedSet, 
                    transactionNumber + 1,
                    maxTransactionCount,
                    ref maxEarned,
                    transactionSum + precalculatedSet[i][j],
                    visitedSections
                    );
                visitedSections.Remove((i,j));
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var res1 = new Solution().MaximumProfit([1, 7, 9, 8, 2], 2);                   //14
        var res2 = new Solution().MaximumProfit([12, 16, 19, 19, 8, 1, 19, 13, 9], 3); //36
        var res3 = new Solution().MaximumProfit([3,8,9,6,4], 2);                       //10
        var res4 = new Solution().MaximumProfit([5,8], 1);                             //3
        var res5 = new Solution().MaximumProfit([1,10], 1);                            //9
        var res6 = new Solution().MaximumProfit([2,3,2,3,2,3,2,3], 4);                 //4
        var res47 = new Solution().MaximumProfit([6,11,1,5,3,15,8], 3);                 //22
        
        
    }
}