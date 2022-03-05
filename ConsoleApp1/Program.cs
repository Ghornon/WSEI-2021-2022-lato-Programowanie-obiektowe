using System;

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

                Console.WriteLine(a + b);
                Console.WriteLine(a - b);
                Console.WriteLine(a * b);
                Console.WriteLine(a / b);

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
