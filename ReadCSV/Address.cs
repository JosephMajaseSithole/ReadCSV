
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadCSV
{
	public class Address
	{
		public string StreetName { get; set; }

		public List<Frequency> SortAddresses(List<Address> addresses)
		{
			var addressesList = new List<string>();
			var frequencies = new List<Frequency>();

			foreach (var address in addresses)
			{
				addressesList.Add(address.StreetName);
			}

			foreach (var streetName in addressesList.Distinct())
			{
				frequencies.Add(new Frequency()
				{
					Name = streetName,
					Count = addresses.Where(n => n.StreetName == streetName).Count()
				});

			}

			return frequencies.OrderByDescending(c => c.Count).ThenBy(x => x.Name).ToList();
		}

		public void WriteToTextFile(List<Frequency> frequencies)
		{
			var frequenciesString = new List<string>();

			foreach (var frequency in frequencies)
			{
				frequenciesString.Add(frequency.Count + ", " + frequency.Name);
			}

			using (TextWriter textWriter = new StreamWriter("SavedListOfAddresses.txt"))
			{
				foreach (var text in frequenciesString)
				{
					textWriter.WriteLine(text);
				}
			}
		}
	}
}
