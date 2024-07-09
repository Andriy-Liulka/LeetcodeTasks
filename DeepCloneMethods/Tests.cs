using Xunit;

namespace DeepCloneMethods;

public class Tests
{
    internal readonly Agency TestingObject;
    public Tests()
    {
		TestingObject = new Agency 
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
	}

	[Fact]
	public void MemberwiseCloneTest()
	{
		var clone = TestingObject.Clone();

		clone.Obfuscate();

		Assert.NotEqual(TestingObject.Name, clone.Name);
		Assert.NotEqual(TestingObject.Address, clone.Address);

		for (int i = 0; i < TestingObject.Staff.Count; i++)
		{
			Assert.NotEqual(TestingObject.Staff[i].FirstName, clone.Staff[i].FirstName);
			Assert.NotEqual(TestingObject.Staff[i].LastName, clone.Staff[i].LastName);
			Assert.NotEqual(TestingObject.Staff[i].Age, clone.Staff[i].Age);
			Assert.NotEqual(TestingObject.Staff[i].Salary, clone.Staff[i].Salary);
		}
	}

	[Fact]
	public void BinaryCloneTest()
	{
		var clone = TestingObject.BinaryClone();

		clone.Obfuscate();

		Assert.NotEqual(TestingObject.Name, clone.Name);
		Assert.NotEqual(TestingObject.Address, clone.Address);

		for (int i = 0; i < TestingObject.Staff.Count; i++)
		{
			Assert.NotEqual(TestingObject.Staff[i].FirstName, clone.Staff[i].FirstName);
			Assert.NotEqual(TestingObject.Staff[i].LastName, clone.Staff[i].LastName);
			Assert.NotEqual(TestingObject.Staff[i].Age, clone.Staff[i].Age);
			Assert.NotEqual(TestingObject.Staff[i].Salary, clone.Staff[i].Salary);
		}
	}

	[Fact]
	public void BsonCloneTest()
	{
		var clone = TestingObject.BsonClone();

		clone.Obfuscate();

		Assert.NotEqual(TestingObject.Name, clone.Name);
		Assert.NotEqual(TestingObject.Address, clone.Address);

		for (int i = 0; i < TestingObject.Staff.Count; i++)
		{
			Assert.NotEqual(TestingObject.Staff[i].FirstName, clone.Staff[i].FirstName);
			Assert.NotEqual(TestingObject.Staff[i].LastName, clone.Staff[i].LastName);
			Assert.NotEqual(TestingObject.Staff[i].Age, clone.Staff[i].Age);
			Assert.NotEqual(TestingObject.Staff[i].Salary, clone.Staff[i].Salary);
		}
	}

	[Fact]
	public void JsonCloneTest()
	{
		var clone = TestingObject.JsonClone();

		clone.Obfuscate();

		Assert.NotEqual(TestingObject.Name, clone.Name);
		Assert.NotEqual(TestingObject.Address, clone.Address);

		for (int i = 0; i < TestingObject.Staff.Count; i++)
		{
			Assert.NotEqual(TestingObject.Staff[i].FirstName, clone.Staff[i].FirstName);
			Assert.NotEqual(TestingObject.Staff[i].LastName, clone.Staff[i].LastName);
			Assert.NotEqual(TestingObject.Staff[i].Age, clone.Staff[i].Age);
			Assert.NotEqual(TestingObject.Staff[i].Salary, clone.Staff[i].Salary);
		}
	}

	[Fact]
	public void XmlCloneTest()
	{
		var clone = TestingObject.XmlClone();

		clone.Obfuscate();

		Assert.NotEqual(TestingObject.Name, clone.Name);
		Assert.NotEqual(TestingObject.Address, clone.Address);

		for (int i = 0; i < TestingObject.Staff.Count; i++)
		{
			Assert.NotEqual(TestingObject.Staff[i].FirstName, clone.Staff[i].FirstName);
			Assert.NotEqual(TestingObject.Staff[i].LastName, clone.Staff[i].LastName);
			Assert.NotEqual(TestingObject.Staff[i].Age, clone.Staff[i].Age);
			Assert.NotEqual(TestingObject.Staff[i].Salary, clone.Staff[i].Salary);
		}
	}
}
