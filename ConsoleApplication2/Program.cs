using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Write a program, which creates an array of 100 Tasks, runs them and wait all of them are not finished.
///  Each Task should iterate from 1 to 1000 and print into the console the following string: “Task #0 – {iteration number}”.
/// </summary>
namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                int j = i;
                var task = Task.Run(() => Iterate(j));
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            Console.ReadKey();
        }

        private static void Iterate(int num)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Task #{num} – {i}");
            };
        }
    }
}
