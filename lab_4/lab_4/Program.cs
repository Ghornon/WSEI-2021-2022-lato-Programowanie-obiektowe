using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_4
{
    class Program
    {
        static void Main(string[] args)
        {

            var a = new FileReader("C:\\aaa");
            var b = new FileCounter(a.FilesList, a.DirsList);

            Console.WriteLine(b.ToString());

            Console.WriteLine($"\r\n\tBy types:\r\n{b.GetHeadline()}");
  
            IEnumerable<Counter> byTypes = b.GetNodesByType();

            foreach (var counter in byTypes)
            {
                Console.WriteLine(counter.ToString());
            }

            Console.WriteLine($"\r\n\tBy extensions:\r\n{b.GetHeadline()}");

            IEnumerable<Counter> byExtension = b.GetNodesByExtension();

            foreach (var counter in byExtension)
            {
                Console.WriteLine(counter.ToString());
            }

            Console.WriteLine($"\r\n\tBy size:\r\n{b.GetHeadline()}");

            IEnumerable<Counter> bySize = b.GetNodesBySize();

            foreach (var counter in bySize)
            {
                Console.WriteLine(counter.ToString());
            }

            Console.WriteLine($"\r\n\tOrdered by name:\r\n\t\t\t\t[size]\t\t[path]");

            IEnumerable<File> orderedByName = a.FilesList.OrderBy(file => file.Name);

            foreach (var file in orderedByName)
            {
                Console.WriteLine($"\t\t{file.Name}\t\t{file.SizeWithSuffix}\t\t{file.Path}");
            }

            Console.WriteLine($"\r\n\tOrdered by sizes (from biggest):\r\n\t\t\t\t[size]\t\t[path]");

            IEnumerable<File> orderedBySize= a.FilesList.OrderByDescending(file => file.Size);

            foreach (var file in orderedBySize)
            {
                Console.WriteLine($"\t\t{file.Name}\t\t{file.SizeWithSuffix}\t\t{file.Path}");
            }

        }
    }
}
