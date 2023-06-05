using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.initializeDatabase();
                /* create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */

                // print the phone book out to System.out
                PhoneBook phoneBook = new PhoneBook();
                var pl = phoneBook.FindAllPersons();
                phoneBook.PrintPerson(pl);
                

                //find Cynthia Smith and print out just her entry
                PrintTidy();
                var p = phoneBook.FindPerson("Cynthia", "Smith");

                if(p != null)
                {
                    phoneBook.PrintPerson(p);
                }

                // insert the new person objects into the database
                Person person = new Person()
                {
                    Name = "TName",
                    Address = "Taddress",
                    PhoneNumber = "T0001"
                };
                phoneBook.AddPerson(person);

                // print phone book 
                PrintTidy();
                pl = phoneBook.FindAllPersons();
                phoneBook.PrintPerson(pl);


            }
            finally
            {
                DatabaseUtil.CleanUp();
            }

            System.Console.ReadKey();
        }

        private static void PrintTidy()
        {
            System.Console.WriteLine("-----------------------");
        }
    }
}
