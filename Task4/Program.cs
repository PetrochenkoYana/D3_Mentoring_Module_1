using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*4. Write a program which recursively creates 10 threads.
Each thread should be with the same body and receive a state with integer number, decrement it,
print and pass as a state into the newly created thread. Use Thread class for this task and Join for waiting threads.

5. Write a program which recursively creates 10 threads.
Each thread should be with the same body and receive a state with integer number, decrement it,
print and pass as a state into the newly created thread.Use ThreadPool class for this task and Semaphore for waiting threads.
*/
namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateThread(10);
            CreateThreadviaThreadPool(10);
            Console.ReadKey();
        }

        private static void CreateThread(int i)
        {
            i--;
            Console.WriteLine(i);
            if (i > 0)
            {
                var thread = new Thread(() => CreateThread(i));
                thread.Start();
                thread.Join();
            }
        }

        private static void CreateThreadviaThreadPool(object i)
        {
            int j = (int)i;
            j--;
            Console.WriteLine(j);
            if (j > 0)
            {
                ThreadPool.QueueUserWorkItem(CreateThreadviaThreadPool, j);
            }
        }
    }

}
