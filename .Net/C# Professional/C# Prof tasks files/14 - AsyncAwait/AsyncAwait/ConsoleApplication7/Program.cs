using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace AsyncAwait
{
    class MyClass
    {
        int Operation()
        {
            Console.WriteLine("Операция выполняется в потоке ThreadID {0}",
                Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(2000);
            return 2 + 2;
        }

        public void OperationAsync()
        {
            Task<int> task = Task<int>.Factory.StartNew(Operation);
            TaskAwaiter<int> awaiter = task.GetAwaiter();
            Action continuation = () => Console.WriteLine("\nРезультат: {0}\n", awaiter.GetResult());
            awaiter.OnCompleted(continuation);
        }
    }
    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
            my.OperationAsync();

            Console.WriteLine("Первичный поток завершил работу. ThreadID {0}",
                Thread.CurrentThread.ManagedThreadId);

            // Delay
            Console.ReadKey();
        }
    }
}
