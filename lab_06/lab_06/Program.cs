using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_06
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new Seeds().users;

            //1. Ilość rekordów w tablicy
            int count = users.Count(); 
            Console.WriteLine($"1. Ilość rekordów w tablicy: {count}");

            //2. Listę nazw użytkowników
            IEnumerable<string> userNameList = from user in users select user.Name;

            Console.WriteLine($"2. Listę nazw użytkowników:");

            foreach (var obj in userNameList)
            {
                Console.WriteLine("\t" + obj);
            }

            //3. Posortowanych użytkowników po nazwach
            IEnumerable<User> sortedUsersByName = from user in users orderby user.Name select user; 

            Console.WriteLine($"3. Posortowanych użytkowników po nazwach:");

            foreach (var obj in sortedUsersByName)
            {
                Console.WriteLine("\t" + obj);
            }

            //4. Listę dostępnych ról użytkowników
            IEnumerable<string> roleNameList = (from user in users select user.Role).Distinct();

            Console.WriteLine($"4. Listę dostępnych ról użytkowników");

            foreach (var obj in roleNameList)
            {
                Console.WriteLine("\t" + obj);
            }

            //5. Listy pogrupowanych użytkowników po rolach
            var groupedByRole = users.GroupBy(user => user.Role.Equals(roleNameList));

            Console.WriteLine($"5. Listy pogrupowanych użytkowników po rolach");


            foreach (var grouping in groupedByRole)
            {
                Console.WriteLine(grouping.Key);
               /* foreach (var role in grouping)
                {
                    Console.WriteLine("\t" + grouping);
                }*/
            }

        }
    }
}
