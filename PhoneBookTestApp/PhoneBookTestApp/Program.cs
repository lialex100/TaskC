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
        private PhoneBook phonebook = new PhoneBook();
        static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.initializeDatabase();
                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */

                // TODO: print the phone book out to System.out
                // TODO: find Cynthia Smith and print out just her entry
                // TODO: insert the new person objects into the database

            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
