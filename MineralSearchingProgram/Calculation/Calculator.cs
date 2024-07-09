namespace MineralSearchingProgram.Calculation;

public static class Calculator
{
	public static double CalculateDistance(Coordinate from, Coordinate to)
	{
		return Math.Sqrt(Math.Pow((from.X - to.X), 2) + Math.Pow((from.Y - to.Y), 2) + Math.Pow((from.Z - to.Z), 2));
	}
}
