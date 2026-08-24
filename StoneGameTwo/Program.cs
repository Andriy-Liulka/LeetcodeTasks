//https://leetcode.com/problems/stone-game-ii/description/?envType=daily-question&envId=2026-08-09

namespace StoneGameTwo;

public class Solution {
    public int StoneGameII(int[] piles)
    {
        int M = 1;
        int X = 1;
        int minXJump = 1;

        int startPileIndex = 0;

        bool isAliceTurn = true;
        int alliceScore = 0;

        while (startPileIndex <= piles.Length)
        {
            int maxXJump = 2 * M;

            int currentPlayerOptimalJump = minXJump;
            int minFutureOpponentScore = 0;
            int optimalScore = 0;
            for (int i = minXJump; i <= maxXJump; i++)
            {
                if (startPileIndex + i > piles.Length)
                {
                    break;
                }
                int score = CalculateScope(piles, startPileIndex, i);
                //To ensure we do not receive index out of range exception
                int nextMaxOpponentJump = (i * 2) > (piles.Length - startPileIndex - i) ? (piles.Length - startPileIndex - i) : (i * 2);

                int futureMaxOpponentScore = 0;
                if (nextMaxOpponentJump > 0)
                {
                    futureMaxOpponentScore = CalculateScope(piles, startPileIndex + i, nextMaxOpponentJump);
                }

                if (minFutureOpponentScore == 0)
                {
                    minFutureOpponentScore = futureMaxOpponentScore;
                    optimalScore = score;
                    currentPlayerOptimalJump = i;
                }

                if (futureMaxOpponentScore < minFutureOpponentScore)
                {
                    minFutureOpponentScore = futureMaxOpponentScore;
                    optimalScore = score;
                    currentPlayerOptimalJump = i;
                }
            }

            if (isAliceTurn)
            {
                alliceScore += optimalScore;
            }

            startPileIndex += currentPlayerOptimalJump;

            isAliceTurn = !isAliceTurn;
            X = currentPlayerOptimalJump;
            M = Math.Max(M, X);
        }

        return alliceScore;
    }

    private static int CalculateScope(int[] piles, int startPileIndex, int jump)
    {
        int score = 0;
        for (int i = startPileIndex; i < startPileIndex + jump; i++)
        {
            score += piles[i];
        }
        return score;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solution = new AIJavaRewrittenSolution();

        //Console.WriteLine(solution.StoneGameII([1,2,3,4,5,100]));
        //Console.WriteLine(solution.StoneGameII([2,7,9,4,4]));
        //Console.WriteLine(solution.StoneGameII([1,5,7,9,9]));
        //Console.WriteLine(solution.StoneGameII([8,6,9,1,7,9]));
        //Console.WriteLine(solution.StoneGameII([77,12,64,35,28,4,87,21,20]));
        Console.WriteLine(solution.StoneGameII([8270,7145,575,5156,5126,2905,8793,7817,5532,5726,7071,7730,5200,5369,5763,7148,8287,9449,7567,4850,1385,2135,1737,9511,8065,7063,8023,7729,7084,8407]));
        Console.WriteLine();
        var solution2 = new MyKnownSolution();
        Console.WriteLine(solution2.StoneGameII([8270,7145,575,5156,5126,2905,8793,7817,5532,5726,7071,7730,5200,5369,5763,7148,8287,9449,7567,4850,1385,2135,1737,9511,8065,7063,8023,7729,7084,8407]));
    }
}