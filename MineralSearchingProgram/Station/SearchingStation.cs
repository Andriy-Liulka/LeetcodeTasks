using MineralSearchingProgram.Calculation;
using MineralSearchingProgram.Constants;

namespace MineralSearchingProgram.Station;

internal class SearchingStation
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public IList<Coordinate> SurfaceCoordinates { get; set; }
    private double Radius { get; set; }

	public SearchingStation(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
		SurfaceCoordinates = new List<Coordinate>();
	}

	public double GetDistanceToMeteor(Coordinate meteorCoordinate)
	{
		var distance = Calculator.CalculateDistance(meteorCoordinate, new Coordinate(X, Y, Z));
		Radius = distance;
		return distance;
	}
	public void CalculateSurfaceCoordinates()
    {
		for (int x = (int)(X - Radius < ConstantValues.MinMapSize ? ConstantValues.MinMapSize : X - Radius); x <= (X + Radius > ConstantValues.MaxMapSize ? ConstantValues.MaxMapSize : X + Radius); x++)
        {
			for (int y = (int)(Y - Radius < ConstantValues.MinMapSize ? ConstantValues.MinMapSize : Y - Radius); y <= (Y + Radius > ConstantValues.MaxMapSize ? ConstantValues.MaxMapSize : Y + Radius); y++)
			{
				for (int z = (int)(Z - Radius < ConstantValues.MinMapSize ? ConstantValues.MinMapSize : Z - Radius); z <= (Z + Radius > ConstantValues.MaxMapSize ? ConstantValues.MaxMapSize : Z + Radius); z++)
				{
					var calculationDistanceResult = Calculator.CalculateDistance(new Coordinate(this.X, this.Y, this.Z), new Coordinate(x, y, z));
					if (calculationDistanceResult == Radius)
					{
						SurfaceCoordinates.Add(new Coordinate(x, y, z));
					}
				}
			}
		}
    }
}
