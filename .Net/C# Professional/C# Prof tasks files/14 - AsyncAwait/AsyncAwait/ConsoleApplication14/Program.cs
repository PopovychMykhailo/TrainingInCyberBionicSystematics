using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class MyClass
    {
        double Operation(object argument)
        {
            Thread.Sleep(2000);
            return (double)argument * (double)argument;
        }

        public async Task<double> OperationAsync(double argument)
        {
            return await Task<double>.Factory.StartNew(Operation, argument);
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
            Task<double> task = my.OperationAsync(3);

            task.ContinueWith(t => Console.WriteLine("Результат : {0}", t.Result));

            // Delay
            Console.ReadKey();
        }
    }
}
