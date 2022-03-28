using System;
using System.Linq;

namespace ClassLibrary
{
    public class Classroom
    {
        private string name;
        private Person[] persons;
        public string Name { get => name; set => name = value; }

        public Classroom(string name, Person[] persons)
        {
            Name = name;
            this.persons = persons;
        }

        public override string ToString()
        {
            string result = $"Classroom: {Name}\r\n\r\n";

            foreach(var person in persons)
            {
                result += person.ToString() + "\r\n\r\n";
            }

            return result;
        }
    }
}
