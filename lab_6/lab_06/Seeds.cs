using System;
using System.Collections.Generic;

namespace lab_06
{
    internal class Seeds
    {
        public List<User> users = new List<User>();

        public Seeds()
        {
            this.Create();

            /*BinnaryFormater.Serialize(users);*/
        }

        public void Create()
        {
            users.Add(new User(
                  "Joe Doe",
                  "ADMIN",
                  32,
                  null,
                  new DateTime(2008, 5, 1, 8, 30, 52),
                  null
            ));

            users.Add(new User(
                  "Jan Kowalski",
                  "MODERATOR",
                  22,
                  null,
                  new DateTime(2021, 5, 1, 8, 31, 52),
                  new DateTime(2022, 2, 1, 8, 31, 52)
            ));

            users.Add(new User(
                  "Kaja Krawczyk",
                  "TEACHER",
                  26,
                  null,
                  new DateTime(2021, 7, 8, 8, 12, 12),
                  null
            ));

            users.Add(new User(
                  "Faustyna Kwiatkowska",
                  "TEACHER",
                  55,
                  null,
                  new DateTime(2022, 5, 7, 11, 31, 52),
                  null
            ));

            users.Add(new User(
                  "Łucja Przybylska",
                  "STUDENT",
                  18,
                  null,
                  new DateTime(2021, 5, 1, 8, 31, 52),
                  new DateTime(2022, 2, 1, 8, 31, 52)
            ));

            users.Add(new User(
                  "Bogda Górska",
                  "STUDENT",
                  19,
                  null,
                  new DateTime(2021, 5, 1, 8, 31, 52),
                  new DateTime(2022, 2, 1, 8, 31, 52)
            ));

            users.Add(new User(
                  "Florencja Laskowska",
                  "STUDENT",
                  20,
                  null,
                  new DateTime(2021, 5, 1, 8, 31, 52),
                  new DateTime(2022, 2, 1, 8, 31, 52)
            ));

            users.Add(new User(
                  "Martyna Sikorska",
                  "STUDENT",
                  21,
                  new int[] { 3, 4, 5 },
                  new DateTime(2021, 5, 1, 8, 31, 52),
                  new DateTime(2022, 2, 1, 8, 31, 52)
            ));

            users.Add(new User(
                 "Iza Laskowska",
                 "STUDENT",
                 22,
                 new int[] { 3, 3, 5 },
                 new DateTime(2021, 5, 1, 8, 31, 52),
                 new DateTime(2022, 2, 1, 8, 31, 52)
           ));

            users.Add(new User(
                  "Faustyna Zawadzka",
                  "STUDENT",
                  22,
                  new int[] { 3, 4, 5, 5 },
                  new DateTime(2021, 5, 1, 8, 31, 52),
                  new DateTime(2022, 2, 1, 8, 31, 52)
            ));

            users.Add(new User(
                  "Jowita Sadowska",
                  "STUDENT",
                  22,
                  new int[] { 2, 4, 5, 5 },
                  new DateTime(2021, 5, 1, 8, 31, 52),
                  new DateTime(2022, 2, 1, 8, 31, 52)
             ));

            users.Add(new User(
                 "Norbert Jakubowski",
                 "STUDENT",
                 22,
                 new int[] { 3, 3, 3, 3 },
                 new DateTime(2021, 5, 2, 9, 11, 52),
                 new DateTime(2022, 3, 1, 9, 11, 52)
           ));

            users.Add(new User(
                 "Ludwik Zalewski",
                 "STUDENT",
                 22,
                 new int[] { 2, 4, 2, 2 },
                 new DateTime(2021, 5, 2, 9, 11, 52),
                 new DateTime(2022, 3, 1, 9, 11, 52)
             ));

            users.Add(new User(
                "Norbert Szczepański",
                "STUDENT",
                22,
                new int[] { 3, 2, 2, 5 },
                new DateTime(2021, 5, 2, 9, 11, 52),
                new DateTime(2022, 3, 1, 9, 11, 52)
            ));

            users.Add(new User(
                "Kordian Kubiak",
                "STUDENT",
                22,
                new int[] { 3, 4, 5, 5, 5 },
                new DateTime(2021, 5, 2, 9, 11, 52),
                new DateTime(2022, 3, 1, 9, 11, 52)
            ));

            users.Add(new User(
                 "Janusz Mazurek",
                 "STUDENT",
                 22,
                 new int[] { 3, 4, 5, 5, 5 },
                 new DateTime(2021, 5, 2, 9, 11, 52),
                 new DateTime(2022, 3, 1, 9, 11, 52)
             ));

            users.Add(new User(
               "Marek Szymański",
               "STUDENT",
               22,
               new int[] { 3, 4, 5, 5, 5 },
               new DateTime(2021, 5, 2, 9, 11, 52),
               new DateTime(2022, 3, 1, 9, 11, 52)
            ));

            users.Add(new User(
               "Piotr Cieślak",
               "STUDENT",
               22,
               new int[] { 3, 4, 2, 5, 5 },
               new DateTime(2021, 5, 2, 9, 11, 52),
               new DateTime(2022, 3, 1, 9, 11, 52)
            ));

            users.Add(new User(
               "Aleks Lewandowski",
               "STUDENT",
               22,
               new int[] { 3, 4, 5, 2, 2 },
               new DateTime(2021, 5, 2, 9, 11, 52),
               new DateTime(2022, 3, 1, 9, 11, 52)
            ));

            users.Add(new User(
               "Aleksander Stępień",
               "STUDENT",
               22,
               new int[] { 3, 2, 5, 2, 2 },
               new DateTime(2021, 5, 2, 9, 11, 52),
               new DateTime(2022, 3, 1, 9, 11, 52)
            ));
        }
    }
}