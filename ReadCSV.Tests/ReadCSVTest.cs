using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace ReadCSV.Tests
{
	[TestClass]
	public class ReadCSVTest
	{

		public List<Person> people = new List<Person>() {
				new Person()
				{
					FirstName = "Thabo",
					LastName = "Magana"
				},
					new Person()
				{
					FirstName = "Eric",
					LastName = "Sithole"
				},
				new Person()
				{
					FirstName = "Thabo",
					LastName = "Sithole"
				},
				new Person()
				{
					FirstName = "John",
					LastName = "Doe"
				},
			};

		public List<Address> addresses = new List<Address>() {
				new Address()
				{
					StreetName = "Vermullen Street"
				},
				new Address()
				{
					StreetName = "Madiba Street"
				},
				new Address()
				{
				StreetName = "Koranna Ave"
				},
				new Address()
				{
					StreetName = "Madiba Street"
				},
				new Address()
				{
					StreetName = "Madiba Street"
				},
				new Address()
				{
				StreetName = "Koranna Ave"
				},
			};


		[TestMethod]
		public void Sort_People_FirstNames_And_LastNames_Based_On_Frequency()
		{
			//Arrange
			var person = new Person();

			//Act
			var frequencies = person.SortPeople(people);
			var nameAtFirstPosition = frequencies.First().Name;
			var nameAtLatPosition = frequencies.Last().Name;

			//Assert
			Assert.AreEqual("Sithole", nameAtFirstPosition);
			Assert.AreEqual("Magana", nameAtLatPosition);
		}

		[TestMethod]
		public void Sort_Addresses_Based_On_Frequency()
		{
			//Arrange
			var address = new Address();

			//Act
			var frequencies = address.SortAddresses(addresses);
			var nameAtFirstPosition = frequencies.First().Name;
			var nameAtLatPosition = frequencies.Last().Name;

			//Assert
			Assert.AreEqual("Madiba Street", nameAtFirstPosition);
			Assert.AreEqual("Vermullen Street", nameAtLatPosition);
		}


		[TestMethod]
		public void Write_To_TextFile_Addressses()
		{
			//Arrange
			var address = new Address();

			//Act
			var frequencies = address.SortAddresses(addresses);

			//Assert
			try
			{
				address.WriteToTextFile(frequencies);
				Assert.IsTrue(true);
			}
			catch
			{
				Assert.IsTrue(false);
			}

		}

		[TestMethod]
		public void Write_To_TextFile_Names_And_Surnames()
		{
			//Arrange
			var person = new Person();

			//Act
			var frequencies = person.SortPeople(people);

			//Assert
			try
			{
				person.WriteToTextFile(frequencies);
				Assert.IsTrue(true);
			}
			catch
			{
				Assert.IsTrue(false);
			}
		}

	}
}
