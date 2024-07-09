using System.Diagnostics.CodeAnalysis;

namespace JoinResultsFromTwoRequests;

public class Program
{
	public static async Task Main(string[] args)
	{
		var repository = new ResultReturner();

		var videoStorageTask1 = repository.GetVideos1Async();
		var videoStorageTask2 = repository.GetVideos2Async();

		videoStorageTask1.Start();
		videoStorageTask2.Start();

		var taskResultSet = await Task.WhenAll(videoStorageTask1, videoStorageTask2);

		var filteredResult = taskResultSet.SelectMany(x => x).DistinctBy(x => x.Id);

		var filteredResult2 = taskResultSet.SelectMany(x => x).ToHashSet(new Comparer());

		Console.Read();
	}

}

public class Video 
{
    public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }

	public Video(int id, string name, string description)
	{
		Id = id;
		Name = name;
		Description = description;
	}
}

public class Comparer : IEqualityComparer<Video>
{
	public bool Equals(Video? x, Video? y)
	{
		return x!.Id.Equals(y!.Id);
	}

	public int GetHashCode([DisallowNull] Video obj)
	{
		return obj.Id.GetHashCode();
	}
}


public class ResultReturner 
{ 
	public  Task<IEnumerable<Video>> GetVideos1Async()
	{
		return  new Task<IEnumerable<Video>>(() => new List<Video>
		{
			new Video(1,"Titanic","melodrama"),
			new Video(2,"Vilzivul","Horror"),
			new Video(3,"ALadin","Adventures"),
		});
	}
	public  Task<IEnumerable<Video>> GetVideos2Async()
	{
		return  new Task<IEnumerable<Video>>(() => new List<Video>
		{
			new Video(1,"Titanic","melodrama"),
			new Video(8,"valencia","Horror"),
			new Video(9,"ALamambar","Adventures"),
		});
	}
}
