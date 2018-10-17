using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*Write a program which creates two threads and a shared collection: the first one should add 10 elements
 *  into the collection and the second should print all elements in the collection after each adding.
 *   Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.*/
namespace Task6
{
    class Program
    {
        public static List<int> List = new List<int>();
        private static object mySet = new object();
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();
            list.onAdd += (sender, eventArgs) =>
            {
                Console.WriteLine($"task {eventArgs.index}");
                foreach (var e in list)
                {
                    Console.WriteLine(e);
                }
            };

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            Console.ReadKey();
        }
    }
}
