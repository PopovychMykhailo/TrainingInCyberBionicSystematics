using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
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

        public async void OperationAsync()
        {
            // Id потока совпадает с Id первичного потока. Это значит, что
            // данный метод начинает выполняться в контексте первичного потока.
            Console.WriteLine("OperationAsync (Part I) ThreadID {0}\n", Thread.CurrentThread.ManagedThreadId);

            Task task = new Task(Operation);
            task.Start();
            await task;

            // Id потока совпадает с Id вторичного потока. Это значит, что
            // данный метод заканчивает выполняться в контексте вторичного потока.
            Console.WriteLine("\nOperationAsync (Part II) ThreadID {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Main ThreadID {0}\n", Thread.CurrentThread.ManagedThreadId);
            MyClass my = new MyClass();
            my.OperationAsync();

            // Delay
            Console.ReadKey();
        }
    }
}
