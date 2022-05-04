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


            //IEnumerable<File> files = from file in a.FilesList where file.Type == FileTypes.image select file;
            List<Counter> byTypes = new List<Counter>();

            byTypes.Add(new Counter("images", a.FilesList));

            Console.WriteLine(b.ToString());

            foreach(var counter in byTypes)
            {
                Console.WriteLine(counter.ToString());
            }
        }
    }
}
