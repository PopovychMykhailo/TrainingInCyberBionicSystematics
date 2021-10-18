using System;
using System.Threading;
using System.Threading.Tasks;

namespace _016_AsyncMain
{
    class MyClass
    {
        public void Operation()
        {
            Console.WriteLine("Operation ThreadID {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Begin");
            Thread.Sleep(2000);
            Console.WriteLine("End");
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {        
            // Id потока совпадает с Id первичного потока. Это значит, что
            // данный метод начинает выполняться в контексте первичного потока.
            Console.WriteLine("OperationAsync (Part I) ThreadID {0}\n", Thread.CurrentThread.ManagedThreadId);

            var my = new MyClass();

            Task task = new Task(my.Operation);
            task.Start();
            await task;

            // Id потока совпадает с Id вторичного потока. Это значит, что
            // данный метод заканчивает выполняться в контексте вторичного потока.
            Console.WriteLine("\nOperationAsync (Part II) ThreadID {0}", Thread.CurrentThread.ManagedThreadId);

            // Delay
            Console.ReadKey();
        }
    }
}
