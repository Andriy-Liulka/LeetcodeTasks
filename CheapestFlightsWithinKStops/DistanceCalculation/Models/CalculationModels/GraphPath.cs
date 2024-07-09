namespace CheapestFlightsWithinKStops.DistanceCalculation.Models.CalculationModels;

public class GraphPath
{
    private int _incrementor = 1;
    public int TotalDistance { get; private set; }
    public SortedList<int, GraphStep> TopsSequence { get; private set; }
    public GraphPath()
    {
        TopsSequence = new SortedList<int, GraphStep>();
    }

    public void Add(GraphStep top)
    {
        TopsSequence.Add(_incrementor, top);
        TotalDistance = TopsSequence.Sum(x => x.Value.OutputDistanceValue);
        _incrementor++;
    }

    public GraphPath DeepClone()
    {
        return new GraphPath
        {
            _incrementor = _incrementor,
            TotalDistance = TotalDistance,
            TopsSequence = new SortedList<int, GraphStep>(TopsSequence)
        };
    }
}
