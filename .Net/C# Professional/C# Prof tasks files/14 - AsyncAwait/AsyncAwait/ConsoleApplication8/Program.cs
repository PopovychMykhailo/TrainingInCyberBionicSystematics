using System;
using System.Threading;
using System.Threading.Tasks;

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

        
        // async указывает, что метод является асинхронным.
        public async void OperationAsync()
        {
            Task<int> task = Task<int>.Factory.StartNew(Operation);

            // await - ожидание завершения работы асинхронной задачи.
            Console.WriteLine("\nРезультат: {0}\n", await task);

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
