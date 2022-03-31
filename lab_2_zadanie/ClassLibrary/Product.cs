using System;

namespace ClassLibrary
{
    public class Product : IThing
    {
        private string name;
        public string Name { get => name; set => name = value; }

        public Product(string name)
        {
            Name = name;
        }
        public virtual void Print(string prefix)
        {
            Console.WriteLine($"{prefix}{Name}");
        }
    }

    public class Fruit : Product
    {
        private int count;
        public int Count { get => count; set => count = value; }

        public Fruit(string name, int count) : base(name)
        {
            Count = count;
        }

        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix}{Name} ({Count} fruits)");
        }
    }
    public class Meat : Product
    {
        private double weight;
        public double Weight { get => weight; set => weight = value; }

        public Meat(string name, double weight) : base(name)
        {
            Weight = weight;
        }

        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix}{Name} ({Weight} kg)");
        }
    }
}
