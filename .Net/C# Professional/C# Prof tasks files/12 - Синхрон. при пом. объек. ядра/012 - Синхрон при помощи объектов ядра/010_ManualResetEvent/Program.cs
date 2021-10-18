using System;
using System.Text;
using System.Threading;

// ManualResetEvent - Уведомляет один или более ожидающих потоков о том, что произошло событие.

namespace ManualResetEventNs
{
    class Program
    {
        // Аргумент:
        // false - установка в несигнальное состояние.
        static ManualResetEvent manual = new ManualResetEvent(false);

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            new Thread(Function1).Start();
            new Thread(Function2).Start();

            Thread.Sleep(500);  // Дадим время запуститься вторичным потокам.

            Console.WriteLine("Нажмите на любую клавишу для перевода ManualResetEvent в сигнальное состояние.\n");
            Console.ReadKey();
            manual.Set(); // Посылает сигнал всем потокам.

            // Delay
            Console.ReadKey();
        }

        static void Function1()
        {
            Console.WriteLine("Поток 1 запущен и ожидает сигнала.");
            manual.WaitOne(); // Остановка выполнения вторичного потока 1.
            Console.WriteLine("Поток 1 завершается.");
        }

        static void Function2()
        {
            Console.WriteLine("Поток 2 запущен и ожидает сигнала.");
            manual.WaitOne(); // Остановка выполнения вторичного потока 2.
            Console.WriteLine("Поток 2 завершается.");
        }
    }
}
