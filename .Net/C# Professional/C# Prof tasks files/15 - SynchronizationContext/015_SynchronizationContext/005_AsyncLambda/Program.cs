using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncVoidLambda
{
    internal class Program
    {
        private static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Action action = async () =>
            {
                Console.WriteLine($"#1 Код до await выполнился в потоке {Thread.CurrentThread.ManagedThreadId}");
                await Task.Run(() => Console.WriteLine($"#1 Задача выполнилась"));
                //throw new Exception("Ошибка в лямбда выражении #1!");
                Console.WriteLine($"#1 Код после await выполнился в потоке {Thread.CurrentThread.ManagedThreadId}");
            };

            Func<Task> func = async () =>
            {
                Console.WriteLine($"#2 Код до await выполнился в потоке {Thread.CurrentThread.ManagedThreadId}");
                await Task.Run(() => Console.WriteLine($"#2 Задача выполнилась"));
                //throw new Exception("Ошибка в лямбда выражении #2!");
                Console.WriteLine($"#2 Код после await выполнился в потоке {Thread.CurrentThread.ManagedThreadId}");
            };

            action.Invoke(); // Can't await void!
            await func.Invoke();

            Console.ReadKey();
        }
    }
}
