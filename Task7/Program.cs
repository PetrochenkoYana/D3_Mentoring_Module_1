using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*a. Continuation task should be executed regardless of the result of the parent task.

b. Continuation task should be executed when the parent task finished without success.

c. Continuation task should be executed when the parent task would be finished with fail and parent task thread should be reused for continuation

d. Continuation task should be executed outside of the thread pool when the parent task would be cancelled*/
namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskA = Task.Run(() =>
            {
                Console.WriteLine("TaskA");
                return "A";
            }).ContinueWith(t => Continuation(t.Result));

            var taskB = Task.Run(() =>
            {
                Console.WriteLine("TaskB");
                throw new Exception("FAIL");
            }).ContinueWith(t => Continuation("Fail task"), TaskContinuationOptions.OnlyOnFaulted);
         

            var taskC = Task.Run(() =>
            {
                Console.WriteLine("TaskB");
            }).ContinueWith(t => Continuation("not Failed task"), TaskContinuationOptions.OnlyOnFaulted);
           

            var task = Task.Run(() =>
            {
                Console.WriteLine("TaskB");
                throw new Exception("FAIL");
            });
            Task.Factory.ContinueWhenAny(new [] { task} , (t) => Continuation("not Failed task"), TaskContinuationOptions.OnlyOnFaulted);
            Console.ReadKey();
        }

        public static void Continuation(string task)
        {
            Console.WriteLine($"Continuation performed for {task}");
        }
    }
}
