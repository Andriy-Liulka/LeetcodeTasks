//https://leetcode.com/problems/trapping-rain-water

namespace TrappingRainWater;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution3();
        //Console.WriteLine(sln.Trap([0,1,0,2,1,0,1,3,2,1,2,1]));
        //Console.WriteLine(sln.Trap([4,2,0,3,2,5]));
        //Console.WriteLine(sln.Trap([4,2,5,3,2,5]));
        //Console.WriteLine(sln.Trap([3, 1, 3, 1, 3]));
        Console.WriteLine(sln.Trap([10, 1, 3, 1, 3]));
    }
}

public class Solution {
    public int Trap(int[] height) {
        int poolStart = 0;
        int poolBottomArea = 0;
        int volume = 0;
        int poolLength = 0;
        while (poolStart < height.Length)
        {
            for(int i = 0 ; i< height.Length; i++)
            {
                if(height[i] >= poolStart && poolLength <= 0)
                {
                    poolStart = height[i];
                }
                else if(height[i] < poolStart){
                    poolLength++;
                    poolBottomArea += height[i];
                }
                else
                {
                    volume += Math.Min(poolStart, height[i]) * poolLength - poolBottomArea;
                    poolBottomArea = 0;
                    poolLength = 0;
                    poolStart = height[i];
                }
            }
        }
        return volume;
    }
}

public class Solution2
{
    public int Trap(int[] height)
    {
        int[][] locations = new int[height.Length][];
        for (int i = 0; i < height.Length; i++)
        {
            locations[i] = [height[i], i];
        }
        Array.Sort(locations, (a, b) => a[0].CompareTo(b[0]) * -1);
        HashSet<int> usedLocations = new HashSet<int>(height.Length);
        int firstIndex = 0;
        bool isFirstChoosen = false;
        int secondIndex = 0;
        int firstValue = 0;
        int secondValue = 0;
        int volume = 0;
        for (int i = 0; i < locations.Length; i++)
        {
            if (usedLocations.Contains(locations[i][1]))
            {
                continue;
            }
            if (!isFirstChoosen)
            {
                firstIndex = locations[i][1];
                firstValue = locations[i][0];
                isFirstChoosen = true;
                continue;
            }
            secondIndex = locations[i][1];
            secondValue = locations[i][0];

            int maxIndex = Math.Max(firstIndex, secondIndex);
            int minIndex = Math.Min(firstIndex, secondIndex);
            int minValue = Math.Min(firstValue, secondValue);
            int capturedVolume = 0;
            for (int j = minIndex; j <= maxIndex; j++)
            {
                capturedVolume += height[j] > minValue ? minValue : height[j];
                usedLocations.Add(j);
            }
            usedLocations.Remove(minIndex);
            usedLocations.Remove(maxIndex);
            volume += minValue * (maxIndex - minIndex + 1) - capturedVolume;
            isFirstChoosen = false;
        }

        return volume;
    }
}

class Solution3 {
    public int Trap(int[] height) {
        int left = 0;
        int right = height.Length - 1;
        int leftMax = height[left];
        int rightMax = height[right];
        int water = 0;

        while (left < right) {
            if (leftMax < rightMax) {
                left++;
                leftMax = Math.Max(leftMax, height[left]);
                water += leftMax - height[left];
            } else {
                right--;
                rightMax = Math.Max(rightMax, height[right]);
                water += rightMax - height[right];
            }
        }
        return water;
    }
}

class Solution4
{
    public int Trap(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int leftMax = height[left];
        int rightMax = height[right];
        int volume = 0;
        while (left < right)
        {
            if (leftMax > rightMax)
            {
                right--;
                rightMax = Math.Max(rightMax, height[right]);
                volume += rightMax - height[right];
            }
            else
            {
                left++;
                leftMax = Math.Max(leftMax, height[left]);
                volume += leftMax - height[left];
            }
        }

        return volume;
    }
}