using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Использование лямбда-выражения в качестве задачи.

namespace TPL
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Основной поток запущен.");

            // Использование лямбда-оператора для определения задачи.
            Task task = Task.Factory.StartNew(new Action(() =>
                {
                    for (int i = 0; i < 80; i++)
                    {
                        Thread.Sleep(20);
                        Console.Write(".");
                    }
                }));

            // Ожидание завершения задачи.
            task.Wait();

            // Освобождение задачи. 
            task.Dispose();

            Console.WriteLine("Основной поток завершен.");

            // Delay
            Console.ReadKey();
        }
    }
}
