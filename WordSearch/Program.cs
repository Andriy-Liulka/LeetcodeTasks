//https://leetcode.com/problems/word-search/description/
namespace WordSearch;

public static class Program
{
    public static void Main(string[] args)
    {
        char[][] board = 
        [
                ['A','B','C','E'],
                ['S','F','C','S'],
                ['A','D','E','E']];

        string word = "ABCCED";

        var isExist = new Solution().Exist(board, word);
        Console.WriteLine($"0 " +
                          $"{nameof(isExist)}: {isExist}" +
                          $" must be true");
        
        board = 
            [   ['A','B','C','E'], 
                ['S','F','C','S'],
                ['A','D','E','E']];

        word = "ABCB";

        isExist = new Solution().Exist(board, word);
        Console.WriteLine($"1 " +
                          $"{nameof(isExist)}: {isExist}" +
                          $" must be false");
        
        board = [
            ['A','B','C','E'],
            ['S','F','C','S'],
            ['A','D','E','E']];

        word = "SEE";

        isExist = new Solution().Exist(board, word);
        Console.WriteLine($"2 " +
                          $"{nameof(isExist)}: {isExist}" +
                          $" must be true");
        
        board = [
            ['A','D']];

        word = "AD";

        isExist = new Solution().Exist(board, word);
        Console.WriteLine($"3 " +
                          $"{nameof(isExist)}: {isExist}" +
                          $" must be true");
        
        board = [
            ['H']];

        word = "H";

        isExist = new Solution().Exist(board, word);
        Console.WriteLine($"4 " +
                          $"{nameof(isExist)}: {isExist}" +
                          $" must be true");
        
        board = [
            ['H'],
            ['H'],
            ['H']
        ];

        word = "HHHH";

        isExist = new Solution().Exist(board, word);
        Console.WriteLine($"5 " +
                          $"{nameof(isExist)}: {isExist}" +
                          $" must be false");
        
        board = [
            ['h'],
            ['H'],
            ['H']
        ];

        word = "HHH";

        isExist = new Solution().Exist(board, word);
        Console.WriteLine($"6 " +
                          $"{nameof(isExist)}: {isExist}" +
                          $" must be false");
        
        board = [
            ['A'],
            ['B'],
            ['C'],
            ['D'],
            ['E'],
        ];

        word = "ABCDE";

        isExist = new Solution().Exist(board, word);
        Console.WriteLine($"7 " +
                          $"{nameof(isExist)}: {isExist}" +
                          $" must be true");
        
        board = [
            ['A'],['B'],['C'],['D'],['E']
        ];

        word = "ABCDT";

        isExist = new Solution().Exist(board, word);
        Console.WriteLine($"8 " +
                          $"{nameof(isExist)}: {isExist}" +
                          $" must be false");
    }
}

public class Solution {
    public bool Exist(char[][] board, string word)
    {
        if (word.Length == 1 && board.Length == 1 && board[0].Length == 1)
        {
            return board[0][0] == word[0];
        }
        
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                bool isFinished = MoveNext(i, j, board, 0, word, [(i,j)]);
                
                if (isFinished)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool MoveNext(int i, int j, char[][] board, int currentLetterIndex, string word, HashSet<(int i, int j)> visited)
    {
        if (board[i][j] != word[currentLetterIndex])
        {
            return false;
        }
        
        if (currentLetterIndex >= word.Length - 1) // check if we are on last letter of searched word
        {
            return true;
        }
        
        var top = (i - 1, j);
        var left = (i, j - 1);
        var bottom = (i + 1, j);
        var right = (i , j + 1);

        foreach ((int, int) direction in ((int, int)[])[top, left, bottom, right])
        {
            var (potentialI, potentialJ) = direction;
            if (IsForbiddenSection(
                    heightLength: board.Length, 
                    length: board[0].Length, 
                    i: potentialI, 
                    j: potentialJ, 
                    passedPlaces: visited))
            {
                continue;
            }

            var letter = word[currentLetterIndex + 1];
            var isSearchedLetter = board[potentialI][potentialJ] == letter;

            if (isSearchedLetter)
            {
                visited.Add(direction);
                var isResultFound = MoveNext(potentialI, potentialJ, board, currentLetterIndex + 1, word, visited);
                visited.Remove(direction);

                if (isResultFound)
                {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    private bool IsForbiddenSection(int heightLength, int length, int i, int j, HashSet<(int, int)> passedPlaces)
    {
        if (i >= heightLength || i < 0)
        {
            return true;
        }
        else if(j >= length || j < 0)
        {
            return true;
        }
        else if(passedPlaces.Contains((i, j)))
        {
            return true;
        }

        return false;
    }
}

