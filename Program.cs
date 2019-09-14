using System;
using System.Collections.Generic;

namespace Fibonacci
{
    // ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
        static IEnumerable<string> Iterator()
        {
            try
            {
                Console.WriteLine("> Before first yield");
                yield return "first";
                Console.WriteLine("> Between yields");
                yield return "second";
                Console.WriteLine("> After second yield");
            }
            finally
            {
                Console.WriteLine("> In finally block");
            }
        }

        static IEnumerable<int> Fibonacci()
        {
            int current = 0;
            int next = 1;
            while (true)
            {
                yield return current;
                int oldCurrent = current;
                current = next;
                next += oldCurrent;
            }

            // ReSharper disable once IteratorNeverReturns
        }

        static void Main()
        {
            foreach (string value in Iterator())
            {
                Console.WriteLine("Received value: {0}", value);
            }

            foreach (var value in Fibonacci())
            {
                Console.WriteLine(value);
                if (value > 90000000)
                {
                    break;
                }
            }
        }
    }
}