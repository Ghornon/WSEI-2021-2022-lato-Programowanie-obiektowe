using System;

namespace ClassLibrary
{
    public class Shop
    {
        private string name;
        private Person[] people;
        private Product[] products;

        public string Name { get => name; set => name = value; }
        public Shop(string name, Person[] people, Product[] products)
        {
            Name = name;
            this.people = people;
            this.products = products;
        }
        public void Print(string prefix = "\t")
        {
            Console.WriteLine($"Shop: {Name}\r\n-- People: --");
            foreach(var item in people)
                item.Print("\t");

            Console.WriteLine("-- Products: --");
            foreach (var item in products)
                item.Print("\t");
        }
    }
}
