using MineralSearchingProgram.Calculation;
using MineralSearchingProgram.Station;
using System.Linq;

namespace MineralSearchingProgram;

internal class Engine
{
	private Coordinate _result;

    private readonly SearchingStationFactory _searchingStationFactory;
	private readonly MeteorFactory _meteorFactory;

	public Engine()
	{
		_searchingStationFactory = new SearchingStationFactory();
		_meteorFactory = new MeteorFactory();

	}
    public Engine Launch()
	{
		var asteroid = _meteorFactory.Generate();
		var asteroidCoordinates = asteroid.GetCoordinates();

		/*
		//var station = _searchingStationFactory.Generate();
		var station = _searchingStationFactory.GenerateWithCoordinates(0,0,0);
		var distance = station.GetDistanceToMeteor(asteroidCoordinates);
		station.CalculateSurfaceCoordinates();

		//var station2 = _searchingStationFactory.Generate();
		var station2 = _searchingStationFactory.GenerateWithCoordinates(100,100,100);
		var distance2 = station2.GetDistanceToMeteor(asteroidCoordinates);
		station2.CalculateSurfaceCoordinates();

		//var station3 = _searchingStationFactory.Generate();
		var station3 = _searchingStationFactory.GenerateWithCoordinates(100, 0, 0);
		var distance3 = station3.GetDistanceToMeteor(asteroidCoordinates);
		station3.CalculateSurfaceCoordinates();

		//var station4 = _searchingStationFactory.Generate();
		var station4 = _searchingStationFactory.GenerateWithCoordinates(100, 100, 0);
		var distance4 = station4.GetDistanceToMeteor(asteroidCoordinates);
		station4.CalculateSurfaceCoordinates();

		var collonPoint = station.SurfaceCoordinates.Select(x => $"{x.X}|{x.Y}|{x.Z}")
			   .Intersect(station2.SurfaceCoordinates.Select(x => $"{x.X}|{x.Y}|{x.Z}"))
			   .Intersect(station3.SurfaceCoordinates.Select(x => $"{x.X}|{x.Y}|{x.Z}"))
			   .Intersect(station4.SurfaceCoordinates.Select(x => $"{x.X}|{x.Y}|{x.Z}"))
			   ;

		var collonPoint2 = station.SurfaceCoordinates.Intersect(station2.SurfaceCoordinates,new CorrdinatesEqualityComparer());

		var collonPoint3 = station.SurfaceCoordinates.IntersectBy(station2.SurfaceCoordinates.Select(x => $"{x.X}|{x.Y}|{x.Z}"), x => $"{x.X}|{x.Y}|{x.Z}");
		*/

		IEnumerable<Coordinate> meteorPossibleCoordinates = Enumerable.Empty<Coordinate>();
		IList<SearchingStation> stations = new List<SearchingStation>();
		Queue<SearchingStation> adjustedStations = new Queue<SearchingStation>();

		adjustedStations.Enqueue(_searchingStationFactory.GenerateWithCoordinates(0, 0, 0));
		adjustedStations.Enqueue(_searchingStationFactory.GenerateWithCoordinates(1000, 1000, 1000));
		//adjustedStations.Enqueue(_searchingStationFactory.GenerateWithCoordinates(1000, 0, 0));

		while (meteorPossibleCoordinates.Count() != 1)
		{
			/*
			SearchingStation station = default(SearchingStation);

			if (adjustedStations.Count > 0)
			{
				station = adjustedStations.Dequeue();
			}
			else
			{
				station = _searchingStationFactory.Generate();
			}

			_ = station.GetDistanceToMeteor(asteroidCoordinates);
			station.CalculateSurfaceCoordinates();

			if (stations.Count == 0)
			{
				meteorPossibleCoordinates = station.SurfaceCoordinates;
				stations.Add(station);
				continue;
			}
			stations.Add(station);
			meteorPossibleCoordinates = meteorPossibleCoordinates.Intersect(station.SurfaceCoordinates, new CorrdinatesEqualityComparer());
			*/

			//TODO rewrite to cubes
			SearchingStation station = default(SearchingStation);

			if (adjustedStations.Count > 0)
			{
				station = adjustedStations.Dequeue();
			}
			else
			{
				station = _searchingStationFactory.Generate();
			}

			_ = station.GetDistanceToMeteor(asteroidCoordinates);
			station.CalculateSurfaceCoordinates();

			if (stations.Count == 0)
			{
				meteorPossibleCoordinates = station.SurfaceCoordinates;
				stations.Add(station);
				continue;
			}
			stations.Add(station);
			meteorPossibleCoordinates = meteorPossibleCoordinates.Intersect(station.SurfaceCoordinates, new CorrdinatesEqualityComparer());
		}

		var stationsCound = stations.Count;
		var result = meteorPossibleCoordinates.ToList();

        Console.WriteLine($"Asteroid: {asteroidCoordinates.X} {asteroidCoordinates.Y} {asteroidCoordinates.Z}");
		Console.WriteLine($"Station: {result.First().X} {result.First().Y} {result.First().Z}");
		Console.WriteLine($"Stations number: {stationsCound}");

		return this;
	}

	public Coordinate GetResult()
	{
		return _result;
	}
}
