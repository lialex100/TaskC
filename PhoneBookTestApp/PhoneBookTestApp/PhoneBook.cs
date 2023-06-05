using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        public void AddPerson(Person newPerson)
        {
            try
            {
                using (var dbConn = DatabaseUtil.GetConnection())
                {
                    SQLiteCommand command = new SQLiteCommand(
                         "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES(" +
                         "'" + newPerson.Name +
                         "','" + newPerson.PhoneNumber +
                         "','" + newPerson.Address + "')", dbConn);

                    command.ExecuteNonQuery();
                    dbConn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //I assume find one person and match all char
        public Person FindPerson(string firstName, string lastName)
        {
            Person person = null;

            using (var dbConn = DatabaseUtil.GetConnection())
            {
                SQLiteCommand command = new SQLiteCommand(
                     "SELECT NAME, PHONENUMBER, ADDRESS FROM PHONEBOOK " +
                     "WHERE NAME ='" + firstName +" "+ lastName + "' "+
                     "LIMIT 1", dbConn);

                SQLiteDataReader sqReader = command.ExecuteReader();
                try
                {
                    while (sqReader.Read())
                    {
                        person = new Person()
                        {
                            Name = sqReader.GetString(0),
                            PhoneNumber = sqReader.GetString(1),
                            Address = sqReader.GetString(2),
                        };
                    }
                }
                finally
                {
                    sqReader.Close();
                }
                dbConn.Close();
            }

            return person;
        }
        public IEnumerable<Person> FindAllPersons()
        {
            var personList = new List<Person>();


            using (var dbConn = DatabaseUtil.GetConnection())
            {
                SQLiteCommand command = new SQLiteCommand(
                     "SELECT NAME, PHONENUMBER, ADDRESS FROM PHONEBOOK", dbConn);

                SQLiteDataReader sqReader = command.ExecuteReader();
                try
                {
                    while (sqReader.Read())
                    {
                        personList.Add(new Person()
                        {
                            Name = sqReader.GetString(0),
                            PhoneNumber = sqReader.GetString(1),
                            Address = sqReader.GetString(2),
                        });
                    }
                }
                finally
                {
                    sqReader.Close();
                }
                dbConn.Close();
            }

            return personList;
        }

        public void PrintPerson(IEnumerable<Person> list)
        {
            foreach (var person in list)
            {
                Console.Out.WriteLine(String.Format("{0}\t{1}\t{2}", person.Name, person.PhoneNumber, person.Address));
            }
        }
        public void PrintPerson(Person person)
        {
            Console.Out.WriteLine(String.Format("{0}\t{1}\t{2}", person.Name, person.PhoneNumber, person.Address));
        }
    }
}