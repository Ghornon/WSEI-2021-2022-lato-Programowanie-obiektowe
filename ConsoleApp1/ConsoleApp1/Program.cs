using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static private List<int> numbers = new List<int>();
        static private int LastNumber = 1;
        static private Object a = new Object();
        static void Main(string[] args)
        {
            bool loop = true;

            Thread thread1 = new Thread(()=>
            {
                while (loop)
                {
                    lock (a)
                    {
                        LastNumber++;
                        AddNumber(LastNumber);
                    }
                }
                
            });

            Thread thread2 = new Thread(() =>
            {
                while (loop)
                {
                    lock (a)
                    {
                        LastNumber++;
                        AddNumber(LastNumber);
                    }
                }

            });

            Thread thread3 = new Thread(() =>
            {
                while (loop)
                {
                    lock (a)
                    {
                        LastNumber++;
                        AddNumber(LastNumber);
                    }
                }

            });

            Thread thread4 = new Thread(() =>
            {
                while (loop)
                {
                    lock (a)
                    {
                        LastNumber++;
                        AddNumber(LastNumber);
                    }
                }

            });

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            Thread.Sleep(10000);
            loop = false;

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

            Console.WriteLine("Count: " + numbers.Count);
            Console.WriteLine("First: " + numbers.First());
            Console.WriteLine("Last: " + numbers.Last());
/*            foreach (int number in numbers)
                Console.Write(number + ", ");*/
        }

        static private void AddNumber(int number)
        {
            if (IsPrimeNumber(number))
                numbers.Add(number);
        }

        static private bool IsPrimeNumber(int number)  {
            double limit = Math.Floor(Math.Sqrt(number));
            for (int i = 2; i <= limit; ++i)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }


    }
}
