using NUnit.Framework;
using PhoneBookTestApp;
using System;
using System.Linq;

namespace PhoneBookTestAppTests
{
    [TestFixture]
    public class PhoneBookTest
    {
        // private DatabaseUtil dbU;

        [SetUp]
        public void SetUp()
        {
            DatabaseUtil.initializeDatabase();
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseUtil.CleanUp();
        }

        [Test]
        public  void addPerson()
        {
            PhoneBook phoneBook = new PhoneBook();
            Person person = new Person()
            {
                Name = "TName",
                Address = "Taddress",
                PhoneNumber = "T0001"
            };

            phoneBook.AddPerson(person);
        }

        [Test]
        public void findPerson()
        {
            PhoneBook phoneBook = new PhoneBook();
            var list = phoneBook.FindAllPersons();

            Assert.That(list.Count(), Is.GreaterThan(3));

        }
    }
}