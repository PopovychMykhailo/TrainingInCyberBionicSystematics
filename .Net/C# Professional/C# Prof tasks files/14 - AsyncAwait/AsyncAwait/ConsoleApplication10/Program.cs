using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class MyClass
    {
        public void Operation()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Основная задача");
        }

        public async Task OperationAsync()
        {
            // return указывать не нужно, т.к. await сформирует return (неявно) самостоятельно.
            await Task.Factory.StartNew(Operation);
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
            Task task = my.OperationAsync();

            task.ContinueWith(t => Console.WriteLine("\nПродолжение задачи."));

            // Delay
            Console.ReadKey();
        }
    }
}
