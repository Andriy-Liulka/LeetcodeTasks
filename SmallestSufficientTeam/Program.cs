namespace SmallestSufficientTeam_Hard;

internal class Program
{
	static void Main(string[] args)
	{
		//new Solution().SmallestSufficientTeam(
		//    new string[3] { "java", "nodejs", "reactjs" },
		//    new List<IList<string>>
		//    {
		//        new List<string>{ "dotnet" },
		//        new List<string>{ "java" },
		//        new List<string>{ "nodejs", "javascript" },
		//        new List<string>{ "nodejs", "reactjs" }
		//    });

		//var result1 = new Solution().SmallestSufficientTeam(
		//	new string[6] { "algorithms", "math", "java", "reactjs", "csharp", "aws" },
		//	new List<IList<string>>
		//	{
		//		new List<string>{ "algorithms","math","java" },
		//		new List<string>{ "algorithms","math","reactjs" },
		//		new List<string>{ "java","csharp","aws" },
		//		new List<string>{ "reactjs","csharp" },
		//		new List<string>{ "csharp","math" },
		//		new List<string>{ "aws", "java" }
		//	});

		var result2 = new Solution().SmallestSufficientTeam(
			new string[4] { "uhppib", "mgdipkgt", "vaostwmycy", "bjwxnfbbubpnd" },
			new List<IList<string>>
			{
						new List<string>(1){ "vaostwmycy" },
						new List<string>(1){ "mgdipkgt" },
						new List<string>(1){ "bjwxnfbbubpnd" },
						new List<string>(0),
						new List<string>(1){ "uhppib" }
			});

		Console.WriteLine("Result");
		result2.ToList().ForEach(x => Console.Write($"{x} "));


	}
}

public class Worker
{
        public int Index { get; set; }
        public IList<string> Skills { get; set; }
        public Worker(int Index, IList<string> Skills)
	{
		this.Index = Index;
		this.Skills = Skills;
	}
	public Worker Clone()
	{
		var list = this.Skills;
		var index = this.Index;
		return new Worker(index, list);
	}
}

public record Team(int Index, int skillsNumber);
public class Solution
{
	public static IList<IList<Worker>> Teams = new List<IList<Worker>>();
	public static string[] Req_Skills = Array.Empty<string>();
	public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people)
	{
		var allPossibleTeams = new List<IList<int>>();

		var workers = people.Select(x => new Worker(people.IndexOf(x), x)).ToList();

		Req_Skills = req_skills;

		RecursionMethod(req_skills.ToList(), workers, new List<Worker>());

		return Teams.Last().Select(x => x.Index).ToArray();
	}

	public void RecursionMethod(IList<string> skills, IList<Worker> people, IList<Worker> previousTeammates)
	{
		var theBestTeamCapacity = Teams.OrderBy(x => x.Count).FirstOrDefault()?.Count;

		if (theBestTeamCapacity is not null && previousTeammates.Count >= theBestTeamCapacity)
		{
			return;
		}

		var currentTeam = previousTeammates.Clone();


		for (int i = 0; i < people.Count; i++)
		{
			if (!CanJoin(skills, people[i]))
			{
				continue;
			}
			IList<string> lastSkills = skills;
			IList<string> remainedSkills = skills.Except(people[i].Skills).ToList();
			currentTeam.Add(people[i]);

			if (Suits(Req_Skills, currentTeam.SelectMany(x => x.Skills).ToList()))
			{
				if (!Exists(currentTeam))
					Teams.Add(currentTeam.Clone());
			}
			else
			{
				RecursionMethod(remainedSkills, people.AllExceptOfWithIndex(people[i].Index), currentTeam);
			}
			currentTeam.Remove(people[i]);
			remainedSkills = lastSkills;
		}
	}

	public bool Suits(IList<string> req_skills, IList<string> offered_skills)
		 => req_skills.Intersect(offered_skills).Count() == req_skills.Count;

	public bool CanJoin(IList<string> req_skills, Worker worker)
		=> req_skills.Except(worker.Skills).Count() != req_skills.Count;

	public bool Exists(IList<Worker> team)
		=> Teams.Any(x => x.Select(x => x.Index).Except(team.Select(y => y.Index)).Count() == 0);

}
public static class Extensions
{
	public static IList<Worker> AllExceptOfWithIndex(this IList<Worker> workers, int index)
		 => workers.Where(x => x.Index != index).ToList();

	public static IList<Worker> Clone(this IList<Worker> workers)
	{
		return workers.Select(x => x.Clone()).ToList();
	}

}