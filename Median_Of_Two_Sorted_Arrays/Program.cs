//Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

//The overall run time complexity should be O(log (m+n)).
//Example 1:

//Input: nums1 = [1, 3], nums2 = [2]
//Output: 2.00000
//Explanation: merged array = [1, 2, 3] and median is 2.

//Example 2:

//Input: nums1 = [1, 2], nums2 = [3, 4]
//Output: 2.50000
//Explanation: merged array = [1, 2, 3, 4] and median is (2 + 3) / 2 = 2.5.

using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Median_Of_Two_Sorted_Arrays;
internal class Program
{

    static void Main(string[] args)
    {
        var timer = new Stopwatch();
        var executor = new Solution();
        int numerator = default;
        double result = default;

        Console.WriteLine(nameof(executor.FindMedianSortedArrays1));

        timer.Start();
        result = executor.FindMedianSortedArrays1(
            new int[] { 1, 2 },
            new int[] { 3, 4 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays1(
            new int[] { 1, 3 },
            new int[] { 2 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays1(
            new int[] { 1, 2, 5, 4, 8, 1, 5, 4, 5, 4 },
            new int[] { 3, 4, 4, 7, 5, 4, 5, 1 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays1(
            new int[] { 0, 0, 0, 0, 0 },
            new int[] { -1, 0, 0, 0, 0, 0, 1 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays1(
            new int[] { 1, 3 },
            new int[] { 2, 7 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        Console.WriteLine(nameof(executor.FindMedianSortedArrays2));
        numerator = 0;

        timer.Restart();
        result = executor.FindMedianSortedArrays2(
            new int[] { 1, 2 },
            new int[] { 3, 4 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays2(
            new int[] { 1, 3 },
            new int[] { 2 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays2(
            new int[] { 1, 2, 5, 4, 8, 1, 5, 4, 5, 4 },
            new int[] { 3, 4, 4, 7, 5, 4, 5, 1 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays2(
            new int[] { 0, 0, 0, 0, 0 },
            new int[] { -1, 0, 0, 0, 0, 0, 1 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays2(
            new int[] { 1, 3 },
            new int[] { 2, 7 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        Console.WriteLine(nameof(executor.FindMedianSortedArrays3));
        numerator = 0;

        timer.Restart();
        result = executor.FindMedianSortedArrays3(
            new int[] { 1, 2 },
            new int[] { 3, 4 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays3(
            new int[] { 1, 3 },
            new int[] { 2 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays3(
            new int[] { 1, 2, 5, 4, 8, 1, 5, 4, 5, 4 },
            new int[] { 3, 4, 4, 7, 5, 4, 5, 1 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays3(
            new int[] { 0, 0, 0, 0, 0 },
            new int[] { -1, 0, 0, 0, 0, 0, 1 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays3(
            new int[] { 1, 3 },
            new int[] { 2, 7 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        Console.WriteLine(nameof(executor.FindMedianSortedArrays4));
        numerator = 0;

        //Exception

        timer.Restart();
        result = executor.FindMedianSortedArrays4(
            new int[0],
            new int[] { 2, 3 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        //exception

        timer.Restart();
        result = executor.FindMedianSortedArrays4(
            new int[] { 1, 2 },
            new int[] { 3, 4 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays4(
            new int[] { 1, 3 },
            new int[] { 2 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays4(
            new int[] { 1, 2, 5, 4, 8, 1, 5, 4, 5, 4 },
            new int[] { 3, 4, 4, 7, 5, 4, 5, 1 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays4(
            new int[] { 0, 0, 0, 0, 0 },
            new int[] { -1, 0, 0, 0, 0, 0, 1 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");

        timer.Restart();
        result = executor.FindMedianSortedArrays4(
            new int[] { 1, 3 },
            new int[] { 2, 7 });
        timer.Stop();
        Console.WriteLine($"{++numerator} result-> {result} {timer.Elapsed}");
    }
}
public class Solution
{
    public double FindMedianSortedArrays1(int[] nums1, int[] nums2)
    {
        //Way 1
        var sortedArray = nums1.ToList().Concat(nums2.ToList()).ToArray();
        var totalArrayCount = nums1.Length + nums2.Length;
        Array.Sort(sortedArray);

        //return (double)sortedArray.ToList().Sum() / (double)sortedArray.Count();
        return totalArrayCount % 2 == 0
            ? (double)(sortedArray[(totalArrayCount / 2) - 1] + (double)sortedArray[totalArrayCount / 2]) / (double)2
            : (double)sortedArray[(int)(Math.Floor((decimal)totalArrayCount / (decimal)2))];
    }

    public double FindMedianSortedArrays2(int[] nums1, int[] nums2)
    {
        //Way 2
        var totalLenght = nums1.Length + nums2.Length;
        var totalArray = new int[totalLenght];
        int i = 0;
        for (i = 0; i < totalLenght; i++)
        {
            if (i < nums1.Length)
            {
                totalArray[Array.IndexOf(totalArray, 0)] = nums1[i];
                //totalArray[i] = nums1[i];
                Array.Sort(totalArray);
            }
            else
            {
                //totalArray[i] = nums2[i - nums1.Length];
                totalArray[Array.IndexOf(totalArray, 0)] = nums2[i - nums1.Length];
                Array.Sort(totalArray);
            }
        }
        return totalLenght % 2 == 0
            ? (double)(totalArray[(totalLenght / 2) - 1] + (double)totalArray[totalLenght / 2]) / (double)2
            : (double)totalArray[(int)(Math.Floor((decimal)totalLenght / (decimal)2))];
    }

    public double FindMedianSortedArrays3(int[] nums1, int[] nums2)
    {
        //Way 3
        var A = nums1;
        var B = nums2;
        var l1 = nums1.Length;
        var l2 = nums2.Length;

        //Step 1
        if (l2 < l1)
        {
            A = nums2;
            B = nums1;
        }

        //Step 2
        var total = l1 + l2;
        var half = total / 2;

        var ALen = A.Length;
        var BLen = B.Length;

        var l = 0;
        var r = ALen - 1;

        while (true)
        {
            var mid = l + r < 0 ? -1 : (l + r) / 2;
            var j = half - (mid + 1) - 1;

            var aLeft = mid >= 0 ? A[mid] : int.MinValue;
            var aRight = mid + 1 < ALen ? A[mid + 1] : int.MaxValue;
            var bLeft = j >= 0 ? B[j] : int.MinValue;
            var bRight = j + 1 < BLen ? B[j + 1] : int.MaxValue;

            if (aLeft <= bRight && bLeft <= aRight)
            {
                //odd
                if (total % 2 != 0)
                {
                    return Math.Min(aRight, bRight);
                }
                //even
                else
                {
                    return (double)(Math.Min(aRight, bRight) + Math.Max(aLeft, bLeft)) / 2;
                }
            }
            else if (aLeft > bRight)
            {
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }
    }

    public double FindMedianSortedArrays4(int[] nums1, int[] nums2)
    {
        //Way 4
        int num1Length = nums1.Length;
        int num2Length = nums2.Length;
        int totalLength = num1Length + num2Length;
        int[] totalArray = new int[totalLength];

        int medianA = 0;
        int medianB = 0;
        bool totalLenghtIsEven = totalLength % 2 == 0;

        bool medianA_Elem_Taken = false;
        bool medianB_Elem_Taken = false;

        int medianA_Elem = 0;
        int medianB_Elem = 0;

        if (totalLenghtIsEven)
        {
            medianA = (totalLength / 2) - 1;
            medianB = totalLength / 2;
        }
        else
        {
            medianA = (int)(totalLength / 2);
        }
        int nums1_I = 0;
        int nums2_I = 0;

        for (int i = 0; i < totalLength; i++)
        {
            if (nums1_I == num1Length)
            {
                totalArray[i] = nums2[nums2_I];
                nums2_I++;
            }
            else if (nums2_I == num2Length)
            {
                totalArray[i] = nums1[nums1_I];
                nums1_I++;
            }
            else if (nums1[nums1_I] < nums2[nums2_I])
            {
                totalArray[i] = nums1[nums1_I];
                nums1_I++;
            }
            else
            {
                totalArray[i] = nums2[nums2_I];
                nums2_I++;
            }

            if (totalLenghtIsEven)
            {
                if (i == medianA)
                {
                    medianA_Elem = totalArray[i];
                    medianA_Elem_Taken = true;
                }
                else if (i == medianB)
                {
                    medianB_Elem = totalArray[i];
                    medianB_Elem_Taken = true;
                }
                if (medianA_Elem_Taken && medianB_Elem_Taken)
                {
                    return ((double)medianA_Elem + (double)medianB_Elem) / (double)2;
                }
            }
            else
            {
                if (i == medianA)
                {
                    return totalArray[i];
                }
            }
        }
        return default;
    }
}

