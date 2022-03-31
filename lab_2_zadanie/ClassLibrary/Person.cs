using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Person : IThing
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

        public virtual void Print(string prefix)
        {
            Console.WriteLine($"{prefix}{Name} ({Age} y.o.)");
        }
    }

    public class Buyer : Person
    {
        protected List<Product> products = new List<Product>();

        public Buyer(string name, int age) : base(name, age) { }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(int index)
        {
            products.RemoveAt(index);
        }

        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix} Buyer: {Name} ({Age} y.o.)");

            if (products.Count > 0)
            {
                Console.WriteLine($"{prefix}\t-- Products: --");
                foreach (var item in products)
                    item.Print($"{prefix}\t\t");
            }
        }
    }

    public class Seller : Person
    {
        public Seller(string name, int age) : base(name, age) { }

        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix} Seller: {Name} ({Age} y.o.)");
        }
    }

}
