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
                var b = new Fraction(1, 3);
                var c = new Fraction(2, 5);

                Console.WriteLine(a + b);
                Console.WriteLine(a - b);
                Console.WriteLine(a * b);
                Console.WriteLine(a / b);

                List<Fraction> fractions = new List<Fraction>();
                fractions.Add(a);
                fractions.Add(b);
                fractions.Add(c);

                Fraction test = new Fraction(1, 3);
                if (fractions.Contains(test))
                    Console.WriteLine(test);
                else
                    Console.WriteLine("Fraction not found.");
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
