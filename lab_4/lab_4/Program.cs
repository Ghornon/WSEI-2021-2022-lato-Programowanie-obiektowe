using System;

namespace lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new FileReader();
            var b = new FileSorter(a.FilesList, a.DirsList);

            Console.WriteLine(b.ToString());
        }
    }
}
