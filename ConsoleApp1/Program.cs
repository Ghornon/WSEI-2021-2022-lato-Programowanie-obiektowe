using System;
using System.Collections.Generic;

namespace ConsoleApp1
{ 
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var a = new Fraction(1, 3);
                var b = new Fraction(3, 4);
                var c = new Fraction(2, 5);
                var d = new Fraction(1, 3);

                Console.WriteLine($"a + b: {a + b}");
                Console.WriteLine($"a - b: {a - b}");
                Console.WriteLine($"a * b: {a * b}");
                Console.WriteLine($"a / b: {a / b}");

                List<Fraction> fractions = new List<Fraction>();
                fractions.Add(a);
                fractions.Add(b);
                fractions.Add(c);
                fractions.Add(d);
                fractions.Add(new Fraction(2,4));
                fractions.Add(new Fraction(1, 6));

                Fraction test = new Fraction(1, 3);
                if (fractions.Contains(test))
                    Console.WriteLine($"Fraction found: {test}");
                else
                    Console.WriteLine("Fraction not found.");

                Console.Write("Sorted: ");

                fractions.Sort();

                foreach(var f in fractions)
                {
                    Console.Write($"{f}, ");
                }

                Console.WriteLine();

                Console.WriteLine($"RoundDown A: {a.RoundDown()}");

                Console.WriteLine($"RoundUp A: {a.RoundUp()}");

                Console.WriteLine($"CompareTo A to A: {a.CompareTo(a)}");
                Console.WriteLine($"CompareTo A to B: {a.CompareTo(b)}");
                Console.WriteLine($"CompareTo B to A: {b.CompareTo(a)}");
                Console.WriteLine($"CompareTo A to D: {a.CompareTo(d)}");
                Console.WriteLine($"CompareTo D to A: {d.CompareTo(a)}");
                Console.WriteLine($"CompareTo D to 1 (ArgumentException expected): {d.CompareTo(1)}"); //ArgumentException expected
                
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
