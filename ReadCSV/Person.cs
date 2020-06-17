
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadCSV
{
	public class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Address { get; set; }

		public string PhoneNumber { get; set; }

		public List<Frequency> SortPeople(List<Person> people)
		{
			var namesAndSurnames = new List<string>();
			var frequencies = new List<Frequency>();

			foreach (var person in people)
			{
				namesAndSurnames.Add(person.FirstName);
				namesAndSurnames.Add(person.LastName);
			}

			foreach (var name in namesAndSurnames.Distinct())
			{
				frequencies.Add(new Frequency()
				{
					Name = name,
					Count = namesAndSurnames.Where(n => n == name).Count()
				});

			}

			return frequencies.OrderByDescending(c => c.Count).ThenBy(x => x.Name).ToList();
		}

		public bool WriteNamesToTextFile(List<Frequency> frequencies)
		{
			bool success;

			try
			{
				using (TextWriter textWriter = new StreamWriter("SavedListOfNames.txt"))
				{
					var frequenciesString = new List<string>();

					foreach (var frequency in frequencies)
					{
						frequenciesString.Add(frequency.Name + ", " + frequency.Count);
					}

					foreach (var text in frequenciesString)
					{
						textWriter.WriteLine(text);
					}
				}

				success = true;
			}
			catch (System.Exception)
			{
				success = false;
			}

			return success;
		}

		public List<Frequency> SortAddresses(List<Person> people)
		{
			var addressesList = new List<Address>();
			var frequencies = new List<Frequency>();

			foreach (var person in people)
			{
				addressesList.Add(new Address
				{
					StreetNumber = person.Address.Split(" ")[0],
					StreetName = person.Address.Substring(person.Address.IndexOf(' ') + 1)
				});
			}

			foreach (var address in addressesList.OrderBy(a => a.StreetName).Distinct())
			{
				frequencies.Add(new Frequency()
				{
					Name = address.StreetNumber + " " + address.StreetName
				});

			}

			return frequencies;
		}

		public bool WriteAddressesToTextFile(List<Frequency> frequencies)
		{
			bool success;

			try
			{

				using (TextWriter textWriter = new StreamWriter("SavedListOfAddresses.txt"))
				{
					var frequenciesString = new List<string>();

					foreach (var frequency in frequencies)
					{
						frequenciesString.Add(frequency.Name);
					}

					foreach (var text in frequenciesString)
					{
						textWriter.WriteLine(text);
					}

				}
				success = true;
			}
			catch (System.Exception)
			{
				success = false;
			}

			return success;
		}
	}
}
