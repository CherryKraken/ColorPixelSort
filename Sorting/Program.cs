using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void TestSorter(ASorter<int> sorter)
        {
            // Display sorter type and number of elements
            Console.WriteLine($"{sorter.GetType().Name} object has {sorter.Length} elements");

            if (sorter.Length <= 50)
            {
                Console.WriteLine($"Before sort:\n{sorter}\n");
            }

            long startTime = Environment.TickCount;
            sorter.Sort();
            long endTime = Environment.TickCount;

            if (sorter.Length <= 50)
            {
                Console.WriteLine($"After sort:\n{sorter}\n");
            }

            Console.WriteLine($"Time elapsed: {endTime - startTime} ms");
        }

        static void SorterTest()
        {
            Console.WriteLine("Enter number of elements: ");
            string input = Console.ReadLine();
            int[] array = new int[Int32.Parse(input)];

            // Seed rand() on milliseconds
            Random rand = new Random(Environment.TickCount);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(array.Length * 100);
            }

            TestSorter(new IntegerRadixSorter(array));
        }

        static void Main(string[] args)
        {
            SorterTest();
        }
    }
}
