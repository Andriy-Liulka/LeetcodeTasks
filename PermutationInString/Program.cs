namespace PermutationInString;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution3_TheMostOptimal();
        Console.WriteLine(sln.CheckInclusion("ab", "eidbaooo"));             //true
        // Console.WriteLine(sln.CheckInclusion("ab", "eidboaoo"));             //false
        // Console.WriteLine(sln.CheckInclusion("eed", "eeededgfd"));           //true
        // Console.WriteLine(sln.CheckInclusion("ksdj", "thgydksdjtnfjdjr"));   //true
        // Console.WriteLine(sln.CheckInclusion("skjd", "thgydksdjtnfjdjr"));   //true
        // Console.WriteLine(sln.CheckInclusion("drj", "thgydksdjtnfjdjr"));    //true
        // Console.WriteLine(sln.CheckInclusion("ksdy", "thgydksdjtnfjdjr"));   //true
        // Console.WriteLine(sln.CheckInclusion("gyutgh", "thgydksdjtnfjdjr")); //false
    }
}

public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;
        int[] snapshot = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
        HashSet<int> allCharacters = new HashSet<int>(26);
        foreach (char symbol in s1)
        {
            allCharacters.Add(symbol);
            snapshot[symbol - 'a'] += 1;
        }
        Queue<int> usedLocations = new Queue<int>();
        for (int i = 0; i < s2.Length; i++)
        {
            if (!allCharacters.Contains(s2[i]))
            {
                while (usedLocations.TryDequeue(out int firstLocation))
                    snapshot[firstLocation] += 1;
                continue;
            }
            int currentIndex = s2[i] - 'a';
            if (snapshot[currentIndex] > 0)
            {
                usedLocations.Enqueue(currentIndex);
                snapshot[currentIndex] -= 1;
                if (usedLocations.Count == s1.Length)
                    return true;
            }
            else if (usedLocations.TryDequeue(out int firstLocation))
            {
                snapshot[firstLocation] += 1;
                i--;
            }
        }
        return false;
    }
}

public class Solution2
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;
        Span<int> snapshot = stackalloc int[26];
        HashSet<int> allCharacters = new HashSet<int>(s1.Length);
        foreach (char symbol in s1)
        {
            allCharacters.Add(symbol);
            snapshot[symbol - 'a']++;
        }
        Queue<int> usedLocations = new Queue<int>();
        for (int i = 0; i < s2.Length; i++)
        {
            if (!allCharacters.Contains(s2[i]))
            {
                while (usedLocations.TryDequeue(out int firstLocation))
                    snapshot[firstLocation]++;
                continue;
            }
            if (snapshot[s2[i] - 'a'] > 0)
            {
                usedLocations.Enqueue(s2[i] - 'a');
                snapshot[s2[i] - 'a']--;
                if (usedLocations.Count == s1.Length)
                    return true;
            }
            else if (usedLocations.TryDequeue(out int firstLocation))
            {
                snapshot[firstLocation]++;
                i--;
            }
        }
        return false;
    }
}

public class Solution3_TheMostOptimal
{
    public bool CheckInclusion(string s1, string s2)
    {
        var n1 = s1.Length;
        var n2 = s2.Length;
        if (n1 > n2)
            return false;
        Span<int> cnt = stackalloc int[26];
        for (var i = 0; i < n1; i++)
        {
            cnt[s1[i] - 'a']++;
            cnt[s2[i] - 'a']--;
        }
        var diff = 0;
        for (var i = 0; i < 26; i++)
        {
            if (cnt[i] != 0)
                diff++;
        }
        for (var i = n1; i < n2; i++)
        {
            if (diff == 0)
                return true;

            var a = s2[i] - 'a';
            var b = s2[i - n1] - 'a';
            if (a == b)
                continue;

            if (cnt[a] == 0)
                diff++;
            cnt[a]--;

            if (cnt[a] == 0)
                diff--;

            if (cnt[b] == 0)
                diff++;

            cnt[b]++;
            if (cnt[b] == 0)
                diff--;
        }
        return diff == 0;
    }
}