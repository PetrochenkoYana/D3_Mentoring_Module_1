using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Write a program, which creates a chain of four Tasks.
///  First Task – creates an array of 10 random integer.
///  Second Task – multiplies this array with another random integer. Third Task – sorts this array by ascending.
///  Fourth Task – calculates the average value. All this tasks should print the values to console
/// </summary>
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Run(() => RandomArray(4))
                .ContinueWith(t => MultipleArray(t.Result))
                .ContinueWith(t =>
                {
                    var sorted = t.Result.OrderBy(k => k);
                    Console.WriteLine("Task 3 : sorted array");
                    foreach (var v in sorted)
                    {
                        Console.WriteLine(v);
                    }
                    return sorted;
                })
                .ContinueWith(t =>
                {
                    Console.WriteLine($"Task 4 : average {t.Result.Average()}");
                });
            Console.ReadKey();
        }

        private static int[] RandomArray(int number)
        {
            var random = new Random();
            var arr = new int[number];
            Console.WriteLine("Task 1 : array ");
            for (int i = 0; i < number; i++)
            {
                arr[i] = random.Next(10);
                Console.WriteLine(arr[i]);
            }
            return arr;
        }

        private static int[] MultipleArray(int[] arr)
        {
            var random = new Random();
            var rendomValue = random.Next(10);
            Console.WriteLine("Task 2 : multipled array ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] * rendomValue;
                Console.WriteLine(arr[i]);
            }
            return arr;
        }

    }
}