using System;
using System.Text;
using System.Threading;

namespace EventSlim
{
    class Program
    {
        // Аргумент:
        // false - установка в несигнальное состояние.
        static ManualResetEventSlim manual = new ManualResetEventSlim(false);

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            new Thread(Function1).Start();
            new Thread(Function2).Start();

            Thread.Sleep(500);  // Дадим время запуститься вторичным потокам.

            Console.WriteLine("Нажмите на любую клавишу для перевода ManualResetEventSlim в сигнальное состояние.\n");
            Console.ReadKey();
            manual.Set(); // Посылает сигнал всем потокам.

            // Delay
            Console.ReadKey();
        }

        static void Function1()
        {
            Console.WriteLine("Поток 1 запущен и ожидает сигнала.");
            manual.Wait(); // Остановка выполнения вторичного потока 1.
            Console.WriteLine("Поток 1 завершается.");
        }

        static void Function2()
        {
            Console.WriteLine("Поток 2 запущен и ожидает сигнала.");
            manual.Wait(); // Остановка выполнения вторичного потока 2.
            Console.WriteLine("Поток 2 завершается.");
        }
    }
}