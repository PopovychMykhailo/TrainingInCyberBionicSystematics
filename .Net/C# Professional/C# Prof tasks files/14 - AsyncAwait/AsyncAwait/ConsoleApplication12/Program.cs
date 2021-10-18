using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class MyClass
    {
        int Operation()
        {
            Thread.Sleep(2000);
            return 2 + 2;
        }

        public async Task<int> OperationAsync()
        {
            //int result = await Task<int>.Factory.StartNew(Operation);
            //return result;

            return await Task<int>.Factory.StartNew(Operation); 
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
            Task<int> task = my.OperationAsync();

            task.ContinueWith(t => Console.WriteLine("Результат : {0}", t.Result));

            // Delay
            Console.ReadKey();
        }
    }
}
