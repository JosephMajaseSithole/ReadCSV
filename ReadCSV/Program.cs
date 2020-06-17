using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadCSV
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Data.csv";

			Console.WriteLine("Reading CSV contents and writing to text files...");

			using (var reader = new StreamReader(File.OpenRead(filePath)))
			{
				var person = new Person();
				var people = new List<Person>();

				while (!reader.EndOfStream)
				{

					var line = reader.ReadLine();
					var values = line.Split(',');

					people.Add(new Person()
					{
						FirstName = values[0],
						LastName = values[1],
						Address = values[2],
						PhoneNumber = values[3]
					});
				}

				people = people.Skip(1).ToList();

				var peopleFrequencies = person.SortPeople(people);
				var addressesFrequencies = person.SortAddresses(people);

				person.WriteNamesToTextFile(peopleFrequencies);
				person.WriteAddressesToTextFile(addressesFrequencies);

				reader.Close();

				Console.WriteLine("Done!!!");
				Console.ReadKey();
			}
		}
	}
}
