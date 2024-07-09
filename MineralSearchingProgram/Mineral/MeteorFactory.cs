using MineralSearchingProgram.Station;
using MineralSearchingProgram.Constants;

namespace MineralSearchingProgram;

internal class MeteorFactory
{
	private readonly Random _randomiser;
	public MeteorFactory()
	{
		_randomiser = new Random();
	}
	public Meteor Generate()
	{
		var x = _randomiser.Next(ConstantValues.MinMapSize, ConstantValues.MaxMapSize + 1);
		var y = _randomiser.Next(ConstantValues.MinMapSize, ConstantValues.MaxMapSize + 1);
		var z = _randomiser.Next(ConstantValues.MinMapSize, ConstantValues.MaxMapSize + 1);

		return new Meteor(x, y, z);
	}
}
