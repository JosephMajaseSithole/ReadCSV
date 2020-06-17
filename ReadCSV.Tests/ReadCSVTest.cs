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
					FirstName = "Jimmy",
					LastName = "Smith",
					Address = "102 Long Lane",
					PhoneNumber = "29384857"
				},
				new Person()
				{
					FirstName = "Clive",
					LastName = "Owen",
					Address = "65 Ambling Way",
					PhoneNumber = "31214788"
				},
				new Person()
				{
					FirstName = "James",
					LastName = "Brown",
					Address = "82 Stewart St",
					PhoneNumber = "32114566"
				},
				new Person()
				{
					FirstName = "Graham",
					LastName = "Howe",
					Address = "12 Howard St",
					PhoneNumber = "8766556"
				},
				new Person()
				{
					FirstName = "John",
					LastName = "Howe",
					Address = "78 Short Lane",
					PhoneNumber = "29384857"
				},
				new Person()
				{
					FirstName = "Clive",
					LastName = "Smith",
					Address = "49 Sutherland St",
					PhoneNumber = "31214788"
				},
				new Person()
				{
					FirstName = "James",
					LastName = "Owen",
					Address = "8 Crimson Rd",
					PhoneNumber = "32114566"
				},
				new Person()
				{
					FirstName = "Graham",
					LastName = "Brown",
					Address = "94 Roland St",
					PhoneNumber = "8766556"
				}
			};

		[TestMethod]
		public void Sort_Names_Frequency_Test()
		{
			//Arrange
			var person = new Person();

			//Act
			var frequencies = person.SortPeople(people);
			var nameAtFirstPosition = frequencies.First().Name;
			var nameAtLatPosition = frequencies.Last().Name;

			//Assert
			Assert.AreEqual("Brown", nameAtFirstPosition);
			Assert.AreEqual("John", nameAtLatPosition);
		}

		[TestMethod]
		public void Sort_Addresses_Frequency_Test()
		{
			//Arrange
			var person = new Person();

			//Act
			var frequencies = person.SortAddresses(people);
			var nameAtFirstPosition = frequencies.First().Name;
			var nameAtLatPosition = frequencies.Last().Name;

			//Assert
			Assert.AreEqual("102 Long Lane", nameAtFirstPosition);
			Assert.AreEqual("94 Roland St", nameAtLatPosition);
		}

		[TestMethod]
		public void Write_Addressses_To_TextFile_Test()
		{
			//Arrange
			var person = new Person();

			//Act
			var frequencies = person.SortAddresses(people);
			var success = person.WriteAddressesToTextFile(frequencies);

			//Assert
			Assert.IsTrue(success);
		}

		[TestMethod]
		public void Write_Names_To_TextFile_Test()
		{
			//Arrange
			var person = new Person();

			//Act
			var frequencies = person.SortPeople(people);
			var success = person.WriteNamesToTextFile(frequencies);

			//Assert
			Assert.IsTrue(success);
		}

	}
}
