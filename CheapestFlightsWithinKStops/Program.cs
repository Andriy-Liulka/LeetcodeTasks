using CheapestFlightsWithinKStops.DistanceCalculation;

namespace CheapestFlightsWithinKStops;

//https://leetcode.com/problems/cheapest-flights-within-k-stops/description/?envType=daily-question&envId=2024-02-23
public class Program 
{ 
    public static void Main(string[] args)
    {
        var solution = new Solution();

        var result = solution.FindCheapestPrice(
            n: 4,
            flights: new int[][]
            {
                new []{ 0,1,100 },
                new []{ 1,2,100 },
                new []{ 2,0,100 },
                new []{ 1,3,600 },
                new []{ 2,3,200 }
            },
            src: 0,
            dst: 3,
            k: 1
            );

        Console.WriteLine(result);
    }
}

public class Solution
{

    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        var citiesCount = n;
        var maxStops = k;

        var calculator = new DistanceCalculator();

        var calculationResult = calculator.Calculate(flights, src, dst, citiesCount, maxStops);

        var result = calculationResult.IsPathExists ? calculationResult.Partitions.Sum() : -1;

        return result;
    }


}




