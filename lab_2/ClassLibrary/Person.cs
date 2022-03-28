using System;

namespace ClassLibrary
{
    public class Person : IEquatable<Person>
    {
        private string name;
        private int age;
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Person otherFraction = obj as Person;
            if (otherFraction == null)
                return false;
            else
                return Equals(otherFraction);
        }
        public bool Equals(Person other)
        {
            if (other == null)
                return false;

            if (Name == other.Name && Age == other.Age)
                return true;
            else
                return false;
        }

        public override int GetHashCode() => HashCode.Combine(Name, Age);

        public override string ToString() => base.ToString();
    }
}
