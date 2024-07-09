namespace CheapestFlightsWithinKStops.DistanceCalculation.Models.CalculationModels;

public class GraphStep
{
    public int TopValue { get; private set; }
    public int OutputDistanceValue { get; private set; }

    public GraphStep(int topValue, int outputDistanceValue)
    {
        TopValue = topValue;
        OutputDistanceValue = outputDistanceValue;
    }
}
