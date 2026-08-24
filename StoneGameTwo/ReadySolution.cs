namespace StoneGameTwo;

class ReadySolution {

    public int StoneGameII(int[] piles) {
        int[] suffixSum = new int[piles.Length];
        int sum = 0;
        for (int i = 1; i <= piles.Length; i++)
        {
            sum += piles[^i];
            suffixSum[piles.Length - i] = sum;
        }

        return MaxStones(suffixSum, 1, 0, new int[piles.Length, piles.Length]);
    }

    private int MaxStones(
        int[] suffixSum,
        int maxTillNow,
        int currIndex,
        int[,] memo
    ) {
        // If currIndex + 2*maxTillNow lies outside the array, pick all remaining stones.
        if (currIndex + 2 * maxTillNow >= suffixSum.Length) {
            return suffixSum[currIndex];
        }
        if (memo[currIndex,maxTillNow] > 0) return memo[currIndex,maxTillNow];
        int res = Int16.MaxValue;
        // Find the minimum value res for the next move possible.
        for (int i = 1; i <= 2 * maxTillNow; i++) {
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
        // Memoize the difference of suffixSum[p] and res. This denotes the maximum
        // stones that can be picked.
        memo[currIndex,maxTillNow] = suffixSum[currIndex] - res;
        return memo[currIndex,maxTillNow];
    }
}