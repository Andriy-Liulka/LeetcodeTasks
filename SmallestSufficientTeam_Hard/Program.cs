using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace SmallestSufficientTeam_Hard
{
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

            new Solution().SmallestSufficientTeam(
                new string[6] { "algorithms", "math", "java", "reactjs", "csharp", "aws" },
                new List<IList<string>>
                {
                    new List<string>{"algorithms","math","java" },
                    new List<string>{ "algorithms","math","reactjs" },
                    new List<string>{ "java","csharp","aws" },
                    new List<string>{ "reactjs","csharp" },
                    new List<string>{ "csharp","math" },
                    new List<string>{ "aws", "java" }
                });
        }
    }

    //public class Worker
    //{
    //    public int Index { get; set; }
    //    public IList<string> Skills { get; set; }
    //    public override bool Equals(object obj)
    //        => (obj as Worker)!.Index == this.Index;

    //    public Worker(int index, IList<string> skills)
    //    {
    //        Index = index;
    //        Skills = skills;
    //    }
    //}
    public record Worker(int Index, IList<string> Skills);

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
            #region Previous
            //var neededSkills = req_skills;
            //var skilledPeople = peopleOrderDictionary;

            //while (!Suits(req_skills, bestTeam.SelectMany(x => x.Value)))
            //{
            //    var teamSkills = bestTeam.SelectMany(x => x.Value);

            //    int index = FindTheMostMatchableElementPersonIndex(neededSkills, peopleOrderDictionary);

            //    var theMostMatchable = peopleOrderDictionary[index];

            //    bestTeam.Add(KeyValuePair.Create(index, theMostMatchable));

            //    neededSkills = neededSkills.Except(teamSkills).ToArray();

            //    skilledPeople.Remove(index);
            //}

            //bestTeam!.Select(x => x.Key).ToList().ForEach(x => Console.WriteLine(x));
            #endregion

            RecursionMethod(req_skills.ToList(), workers, new List<Worker>());

            return Array.Empty<int>();
        }

        public void RecursionMethod(IList<string> skills, IList<Worker> people, IList<Worker> previousTeammates)
        {
            var theBestTeamCapacity = Teams.OrderBy(x => x.Count).FirstOrDefault()?.Count;

            if (theBestTeamCapacity is not null && previousTeammates.Count == theBestTeamCapacity)
            {
                return;
            }

            var currentTeam = previousTeammates;
            for (int i = 0; i < people.Count; i++)
            {
                if (!CanJoin(skills, people[i]))
                {
                    continue;
                }

                skills = skills.Except(people[i].Skills).ToList();
                currentTeam.Add(people[i]);

                if (Suits(Req_Skills, currentTeam.SelectMany(x => x.Skills).ToList()))
                {
                    Teams.Add(currentTeam);
                    currentTeam.Remove(people[i]);
                }
                else
                {
                    RecursionMethod(skills, people.AllExceptOfWithIndex(people[i].Index), previousTeammates);
                }
            }
        }

        public bool Suits(IList<string> req_skills, IList<string> offered_skills)
             => req_skills.Intersect(offered_skills).Count() == req_skills.Count;

        public bool CanJoin(IList<string> req_skills, Worker worker)
            => req_skills.Except(worker.Skills).Count() != req_skills.Count;

        //public KeyValuePair<int, int> FindFirstTheMostMatchableElementPersonIndex(string[] req_skills, IList<Worker> people)
        //{
        //    KeyValuePair<int, int> maxMatchableIndexElementsCount = default;

        //    for (int i = 0; i < people.Count; i++)
        //    {
        //        var matchableElementsCount = req_skills.Intersect(people[i].Skills).Count();
        //        if (matchableElementsCount > maxMatchableIndexElementsCount.Value)
        //        {
        //            maxMatchableIndexElementsCount = KeyValuePair.Create<int, int>(people[i].Index, people[i].Skills.Count);
        //        }
        //    }
        //    return maxMatchableIndexElementsCount;
        //}

        //public List<KeyValuePair<int, int>> FindAllTheMostMatchableElementPersonIndex(string[] req_skills, IList<Worker> people)
        //{
        //    KeyValuePair<int, int> maxMatchableIndexElementsCount = FindFirstTheMostMatchableElementPersonIndex(req_skills, people);
        //    var listOfTheMostMatchablePeople = new List<KeyValuePair<int, int>>();

        //    for (int i = 0; i < people.Count; i++)
        //    {
        //        var matchableElementsCount = req_skills.Intersect(people[i].Skills).Count();
        //        if (matchableElementsCount == maxMatchableIndexElementsCount.Value)
        //        {
        //            listOfTheMostMatchablePeople.Add(KeyValuePair.Create<int, int>(i, matchableElementsCount));
        //        }
        //    }
        //    return listOfTheMostMatchablePeople;
        //}

        //public int[] GetTheBestTeam(List<IList<int>> teams)
        //    => teams.OrderBy(x => x.Count).First().ToArray();

    }
    public static class Extensions
    {
        public static IList<Worker> AllExceptOfWithIndex(this IList<Worker> workers, int index)
             => workers.Where(x => x.Index != index).ToList();

    }
}