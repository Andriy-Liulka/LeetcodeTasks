using MineralSearchingProgram.Calculation;

namespace MineralSearchingProgram;

internal class Meteor
{
	private int X { get; set; }
	private int Y { get; set; }
	private int Z { get; set; }

	public Meteor(int x, int y, int z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public Coordinate GetCoordinates()
	{
		return new Coordinate(X, Y, Z);
	}
}
