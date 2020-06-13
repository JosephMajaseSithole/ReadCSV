
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadCSV
{
	public class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

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

		public void WriteToTextFile(List<Frequency> frequencies)
		{
			var frequenciesString = new List<string>();

			foreach (var frequency in frequencies)
			{
				frequenciesString.Add(frequency.Name + ", " + frequency.Count);
			}

			using (TextWriter textWriter = new StreamWriter("SavedListOfNames.txt"))
			{
				foreach (var text in frequenciesString)
				{
					textWriter.WriteLine(text);
				}
			}
		}
	}
}
