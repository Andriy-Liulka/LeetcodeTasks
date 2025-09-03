//https://leetcode.com/problems/restore-ip-addresses/description/

using System.Text;

public class Startup
{
    public static void Main(string[] args)
    {
        var result1 = new Solution().RestoreIpAddresses("25525514");
        var result2 = new Solution().RestoreIpAddresses("25525514111");
        var result3 = new Solution().RestoreIpAddresses("25525511135");
        var result4 = new Solution().RestoreIpAddresses("0000");
        var result5 = new Solution().RestoreIpAddresses("101023");
        var result6 = new Solution().RestoreIpAddresses("192168@11");
        var result7 = new Solution().RestoreIpAddresses("010010");
    }
}

public class Solution 
{
    public IList<string> RestoreIpAddresses(string s)
    {
        var strLength = s.Length;
        if (strLength < 4 || strLength > 12)
        {
            return [];
        }

        List<int[]> possibleDistributions = new List<int[]>(s.Length * 2);
        ResearchCase(ref possibleDistributions, new int[4] { 1, 1, 1, s.Length-3 },0);

        var result = new List<string>();
        foreach (var distribution in possibleDistributions)
        {
            var stringBuilder = new StringBuilder();
            int charsPassed = 0;
            bool isTerminated = false;
            for (int i = 0; i < distribution.Length; i++)
            {
                var numberStr = s.Substring(charsPassed, distribution[i]);
                
                bool isNumber = Int32.TryParse(numberStr, out int intValue);
                if (!isNumber)
                {
                    return [];
                }
                else if (numberStr[0] == '0' && intValue > 0)
                {
                    isTerminated = true;
                    break;
                }
                else if (numberStr[0] == '0' && intValue == 0 && numberStr.Length > 1)
                {
                    isTerminated = true;
                    break;
                }
                else if (intValue > 255)
                {
                    isTerminated = true;
                    break;
                }


                stringBuilder.Append(numberStr);
                charsPassed += numberStr.Length;
                if (i < distribution.Length - 1)
                {
                    stringBuilder.Append('.');
                }
                
            }

            if (!isTerminated)
            {
                result.Add(stringBuilder.ToString());
            }
        }
        
        return result;
    }

    private void ResearchCase(ref List<int[]> possibleDistributions, int[] previousCase, int startPosition)
    {
        var previousCaseCopyArr = new int[previousCase.Length];
        Array.Copy(previousCase, previousCaseCopyArr, previousCase.Length);
        
        if (startPosition >= 2)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (i != 1)
                {
                    previousCaseCopyArr[startPosition]++;
                    previousCaseCopyArr[^1]--;
                }

                if (previousCaseCopyArr[^1] < 1 || previousCaseCopyArr[^1] > 3)
                {
                    continue;
                }
                
                var copyArray = new int[previousCaseCopyArr.Length];
                Array.Copy(previousCaseCopyArr, copyArray, previousCaseCopyArr.Length);
                possibleDistributions.Add(copyArray);
            }
            return;
        }
        
        for (int i = 1; i <= 3; i++)
        {
            if (i != 1)
            {
                previousCaseCopyArr[startPosition]++;
                previousCaseCopyArr[^1]--;
            }
            
            var arrayCopyInRecursion = new int[previousCaseCopyArr.Length];
            Array.Copy(previousCaseCopyArr, arrayCopyInRecursion, previousCaseCopyArr.Length);
            ResearchCase(ref possibleDistributions, arrayCopyInRecursion, startPosition+1);
        }
    }
}