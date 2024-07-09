using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace MineralSearchingProgram.Calculation;

public class Coordinate
{
	public int X { get; set; }
	public int Y { get; set; }
	public int Z { get; set; }

	public Coordinate(int x, int y, int z)
	{
		X = x;
		Y = y;
		Z = z;
	}
}

public class CorrdinatesEqualityComparer : IEqualityComparer<Coordinate>
{
	public bool Equals(Coordinate? first, Coordinate? second)
	{
		return first!.X == second!.X && first!.Y == second!.Y && first!.Z == second!.Z;
	}

	public int GetHashCode([DisallowNull] Coordinate obj)
	{
		return obj.X.GetHashCode() + obj.Y.GetHashCode() + obj.Z.GetHashCode();
	}
}
