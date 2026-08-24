namespace StoneGameTwo;

class AIJavaRewrittenSolution
{
    public int StoneGameII(int[] piles)
    {
        int n = piles.Length;
        // Store the suffix sum of all array elements.
        int[] suffixSum = new int[n];
        Array.Copy(piles, suffixSum, n);

        for (int i = n - 2; i >= 0; i--)
        {
            suffixSum[i] += suffixSum[i + 1];
        }

        return MaxStones(suffixSum, 1, 0, new int[n, n]);
    }

    private int MaxStones(
        int[] suffixSum,
        int maxTillNow,
        int currIndex,
        int[,] memo
    )
    {
        // If currIndex + 2*maxTillNow lies outside the array, pick all remaining stones.
        if (currIndex + 2 * maxTillNow >= suffixSum.Length)
        {
            return suffixSum[currIndex];
        }

        if (memo[currIndex, maxTillNow] > 0)
        {
            return memo[currIndex, maxTillNow];
        }

        int res = int.MaxValue;
        // Find the minimum value res for the next move possible.
        for (int i = 1; i <= 2 * maxTillNow; i++)
        {
            res = Math.Min(
                res,
                MaxStones(
                    suffixSum,
                    Math.Max(i, maxTillNow),
                    currIndex + i,
                    memo
                )
            );
        }

        // Memoize the difference of suffixSum[currIndex] and res. This denotes the maximum
        // stones that can be picked.
        memo[currIndex, maxTillNow] = suffixSum[currIndex] - res;
        return memo[currIndex, maxTillNow];
    }
}