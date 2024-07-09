using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace DeepCloneMethods;

[Serializable]
public sealed class Agency
{
    public List<Employee> Staff { get; set; }
    public string Name { get; set; }
	public string Address { get; set; }

	public void Obfuscate()
	{
		Name += Guid.NewGuid().ToString();
		Address += Guid.NewGuid().ToString();

		var randomizer = new Random();

		foreach (var employee in Staff)
		{
			employee.Age += randomizer.Next();
			employee.FirstName += Guid.NewGuid().ToString();
			employee.LastName += Guid.NewGuid().ToString();
			employee.Salary += randomizer.Next();
		}
	}

	public Agency Clone()
	{
		return (Agency)this.MemberwiseClone();
	}
}
[Serializable]
public sealed class Employee
{
    public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }
    public decimal Salary { get; set; }

    public Employee(){	}
    public Employee(string firstName, string lastName, int age, decimal salary)
	{
		FirstName = firstName;
		LastName = lastName;
		Age = age;
		Salary = salary;
	}
}

public static class Clonner
{
	public static TEntity BinaryClone<TEntity>(this TEntity obj)
	{
		TEntity result = default(TEntity);

		using (MemoryStream memoryStream = new MemoryStream())
		{
			var formatter = new BinaryFormatter();
			formatter.Serialize(memoryStream, obj);
			memoryStream.Seek(0, SeekOrigin.Begin);
			result = (TEntity)formatter.Deserialize(memoryStream)!;
		}
		return result;
	}

	public static TEntity BsonClone<TEntity>(this TEntity obj)
	{
		var result = default(TEntity);

		var writerMemoryStream = new MemoryStream();
		using (BsonWriter writer = new BsonWriter(writerMemoryStream))
		{
			var serializer = new JsonSerializer();
			serializer.Serialize(writer, obj);

			var readerMemoryStream = new MemoryStream(writerMemoryStream.ToArray());
			using (BsonReader reader = new BsonReader(readerMemoryStream))
			{
				result = serializer.Deserialize<TEntity>(reader);
			}

		}

		return result;
	}

	public static TEntity JsonClone<TEntity>(this TEntity obj)
	{
		var serializedObj = JsonConvert.SerializeObject(obj);

		var result = JsonConvert.DeserializeObject<TEntity>(serializedObj);

		return result;
	}

	public static TEntity XmlClone<TEntity>(this TEntity obj)
	{
		var result = default(TEntity);

		XmlSerializer xmlSerializer = new XmlSerializer(typeof(TEntity));

		using (StringWriter stringWriter = new StringWriter())
		using (XmlWriter writer = XmlWriter.Create(stringWriter))
		{
			xmlSerializer.Serialize(writer, obj);
			var xmlString = stringWriter.ToString();
			using (TextReader textReader = new StringReader(xmlString))
			{
				result = (TEntity)xmlSerializer.Deserialize(textReader)!;
			}
		}
		return result;
	}
}