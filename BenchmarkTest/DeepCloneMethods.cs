using BenchmarkDotNet.Attributes;
using DeepCloneMethods;

namespace BenchmarkTest;

[MemoryDiagnoser]
[RankColumn]
public class DeepCloneMethods
{
	internal List<Agency> TestingObject;
	internal int ArraySize;

	[Params(1, 2, 3, 4, 5)]
    public int Case { get; set; }
	public int Iterations { get; set; }

	[IterationSetup]
	public void Setup()
	{
		TestingObject = Case switch
		{
			1 => PrivateImplementator.GetOne(),
			2 => PrivateImplementator.GetTen(),
			3 => PrivateImplementator.GetHundred(),
			4 => PrivateImplementator.GetThousand(),
			5 => PrivateImplementator.GetTenThousands(),
			_ => new List<Agency>()
		};

		Iterations = Case switch
		{
			1 => 1,
			2 => 10,
			3 => 100,
			4 => 1000,
			5 => 10000,
			_ => 0
		};

	}

	[Benchmark]
	public void MemberwiseCloneTest()
	{
		for (int i = 0; i < Iterations; i++)
		{
			var clone = TestingObject[i].Clone();
		}
	}

	[Benchmark]
	public void BinaryCloneTest()
	{
		for (int i = 0; i < Iterations; i++)
		{
			var clone = TestingObject[i].BinaryClone();
		}
	}

	[Benchmark]
	public void BsonCloneTest()
	{
		for (int i = 0; i < Iterations; i++)
		{
			var clone = TestingObject[i].BsonClone();
		}
	}

	[Benchmark]
	public void JsonCloneTest()
	{
		for (int i = 0; i < Iterations; i++)
		{
			var clone = TestingObject[i].JsonClone();
		}
	}

	[Benchmark]
	public void XmlCloneTest()
	{
		for (int i = 0; i < Iterations; i++)
		{
			var clone = TestingObject[i].XmlClone();
		}
	}
}

class PrivateImplementator
{
	public static Agency TestInstance = new Agency
	{
		Name = "Andrii",
		Address = "Sheptytskoho street 4 5 8 dada",
		Staff = new List<Employee>
				{
					new Employee("John", "Doe", 30, 60000),
					new Employee("Jane", "Smith", 28, 55000),
					new Employee("Michael", "Johnson", 35, 70000),
					new Employee("Emily", "Brown", 26, 52000),
					new Employee("David", "Lee", 32, 62000),
					new Employee("Sarah", "Wilson", 29, 58000),
					new Employee("Matthew", "Martinez", 31, 65000),
					new Employee("Emma", "Taylor", 27, 53000),
					new Employee("Daniel", "Anderson", 34, 69000),
					new Employee("Olivia", "Jones", 25, 51000),
					new Employee("James", "Brown", 33, 67000),
					new Employee("Sophia", "Miller", 28, 55000),
					new Employee("Liam", "Davis", 29, 58000),
					new Employee("Ava", "Garcia", 32, 62000),
					new Employee("William", "Harris", 30, 60000),
					new Employee("Mia", "Clark", 27, 53000),
					new Employee("Benjamin", "White", 33, 67000),
					new Employee("Ethan", "Thomas", 31, 65000),
					new Employee("Isabella", "Lewis", 25, 51000),
					new Employee("Alexander", "Taylor", 34, 69000)
				}
	};
	public static List<Agency> GetOne()
	{
		return new List<Agency>
		{
			TestInstance
		};
	}
	public static List<Agency> GetTen()
	{
		var list = new List<Agency>();

		for (int i = 0; i < 10; i++)
		{
			list.Add(TestInstance.BinaryClone());
		}

		return list;
	}

	public static List<Agency> GetHundred()
	{
		var list = new List<Agency>();

		for (int i = 0; i < 100; i++)
		{
			list.Add(TestInstance.BinaryClone());
		}

		return list;
	}

	public static List<Agency> GetThousand()
	{
		var list = new List<Agency>();

		for (int i = 0; i < 1000; i++)
		{
			list.Add(TestInstance.BinaryClone());
		}

		return list;
	}

	public static List<Agency> GetTenThousands()
	{
		var list = new List<Agency>();

		for (int i = 0; i < 10000; i++)
		{
			list.Add(TestInstance.BinaryClone());
		}

		return list;
	}
}
