using CheapestFlightsWithinKStops.Graph;

namespace CheapestFlightsWithinKStops.DistanceCalculation;

public static class InputIndexIndicator
{
    public const int FromIndex = 0;
    public const int ToIndex = 1;
    public const int PriceIndex = 2;
}

public class DistanceCalculatorHelper
{
    public IDictionary<int, Top> ToTopsDistionary(int[][] flights)
    {
        var groupedFlightsByFrom = flights.GroupBy(keySel => keySel[InputIndexIndicator.FromIndex]);
        var groupedFlightsByTo = flights.GroupBy(keySel => keySel[InputIndexIndicator.ToIndex]);

        var allFrom = flights.Select(x => x[InputIndexIndicator.FromIndex]);
        var allTo = flights.Select(x => x[InputIndexIndicator.ToIndex]);

        var uniqueTops = new HashSet<int>(allFrom);
        uniqueTops.UnionWith(allTo);

        var distionaryTops = uniqueTops.ToDictionary(key => key, elem => new Top
        {
            TopValue = elem,

            OutputEdges = groupedFlightsByFrom
                .FirstOrDefault(x => x.Key == elem)?
                .Select(x => new OutputEdge { To_Top = x[InputIndexIndicator.ToIndex], Price = x[InputIndexIndicator.PriceIndex] })
                .ToArray() ?? Array.Empty<OutputEdge>(),

            InputEdges = groupedFlightsByTo
                .FirstOrDefault(x => x.Key == elem)?
                .Select(x => new InputEdge { From_Top = x[InputIndexIndicator.FromIndex], Price = x[InputIndexIndicator.PriceIndex] })
                .ToArray() ?? Array.Empty<InputEdge>(),
        });
        return distionaryTops;
    }
}
