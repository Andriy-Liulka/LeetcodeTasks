namespace StoneGameTwo;

public class MyKnownSolution
{
    public int StoneGameII(int[] piles)
    {
        int[] suffixSum = new int[piles.Length];
        int sum = 0;
        for (int i = 1; i <= piles.Length; i++)
        {
            sum += piles[^i];
            suffixSum[piles.Length - i] = sum;
        }

        return MaxValue(suffixSum, 1, 0);
    }

    int MaxValue(int[] suffixArray, int M, int currentIndex)
    {
        if (currentIndex + 2 * M >= suffixArray.Length)
        {
            return suffixArray[currentIndex];
        }

        int min = int.MaxValue;
        for (int i = 1; i <= 2 * M; i++)
        {
            int nextMax = Math.Max(i, M);
            int res = MaxValue(suffixArray, nextMax, currentIndex + i);
            min = Math.Min(min, res);
        }

        return suffixArray[currentIndex] - min;
    }
}