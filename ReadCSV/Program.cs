using System;
using System.Collections.Generic;
using System.IO;

namespace ReadCSV
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\NamesAndAddresses.csv";

			Console.WriteLine("Reading CSV contents and writing to text files...");

			using (var reader = new StreamReader(File.OpenRead(filePath)))
			{
				var person = new Person();
				var address = new Address();

				var people = new List<Person>();
				var addresses = new List<Address>();

				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(';');

					people.Add(new Person()
					{
						FirstName = values[0].Split(" ")[0],
						LastName = values[0].Split(" ")[1]
					});

					addresses.Add(new Address()
					{
						StreetName = values[1]
					});

				}

				var peopleFrequencies = person.SortPeople(people);
				person.WriteToTextFile(peopleFrequencies);

				var addressFrequencies = address.SortAddresses(addresses);
				address.WriteToTextFile(addressFrequencies);

				reader.Close();

				Console.WriteLine("Done!!!");
				Console.ReadKey();
			}
		}
	}
}
