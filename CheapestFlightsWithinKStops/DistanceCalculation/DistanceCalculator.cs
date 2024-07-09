using CheapestFlightsWithinKStops.DistanceCalculation.Models;
using CheapestFlightsWithinKStops.Graph;

namespace CheapestFlightsWithinKStops.DistanceCalculation;
public class DistanceCalculator
{
    public DistanceCalculationResult Calculate(
        int[][] flights,
        int source,
        int destination,
        int citiesCount,
        int maxStops
        )
    {
        var distanceCalculator = new DistanceCalculatorHelper();

        IDictionary<int, Top> topsArray = distanceCalculator.ToTopsDistionary(flights);

        //Engine must be here
        Top sourceTop = topsArray.Single(x => x.Key == source).Value;


        //TODO create Dictionary to store date like hash value - GraphPath


        while (true)
        {

        }

        return null;
    }
}




