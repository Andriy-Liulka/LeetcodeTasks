using MineralSearchingProgram.Constants;

namespace MineralSearchingProgram.Station;

internal class SearchingStationFactory
{
    private readonly Random _randomiser;
    public SearchingStationFactory()
    {
        _randomiser = new Random();
    }
    public SearchingStation Generate()
    {
		var x = _randomiser.Next(ConstantValues.MinMapSize, ConstantValues.MaxMapSize + 1);
		var y = _randomiser.Next(ConstantValues.MinMapSize, ConstantValues.MaxMapSize + 1);
		var z = _randomiser.Next(ConstantValues.MinMapSize, ConstantValues.MaxMapSize + 1);

		return new SearchingStation(x, y, z);
    }

	public SearchingStation GenerateWithCoordinates(int x, int y, int z)
	{
		return new SearchingStation(x, y, z);
	}
}
