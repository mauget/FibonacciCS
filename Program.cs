﻿using System;
using System.Collections.Generic;

namespace Fibonacci
{
    // ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
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