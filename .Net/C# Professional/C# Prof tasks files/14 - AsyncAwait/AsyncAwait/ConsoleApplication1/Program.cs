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
            Task task = new Task(Operation);
            task.Start();
            await task;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Main ThreadID {0}", Thread.CurrentThread.ManagedThreadId);
            MyClass my = new MyClass();
            my.OperationAsync();

            // Delay
            Console.ReadKey();
        }
    }
}
