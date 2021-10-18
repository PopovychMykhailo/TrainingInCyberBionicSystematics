using System;
using System.Text;
using System.Threading;

namespace Event
{
    class Program
    {
        // false - установка несигнального состояния.
        static ManualResetEvent manual = new ManualResetEvent(false);

        static void Function()
        {
            Console.WriteLine("Запущен поток {0}", Thread.CurrentThread.Name);

            for (int i = 0; i < 80; i++)
            {
                Console.Write(".");
                Thread.Sleep(20);
            }

            Console.WriteLine("Завершен поток {0}", Thread.CurrentThread.Name);

            manual.Set(); // Посылает сигнал первичному потоку - [продолжиться].
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Thread thread = new Thread(Function) { Name = "1" }; // 1-й ПОТОК.
            thread.Start();

            Console.WriteLine("Приостановка выполнения первичного потока.");
            manual.WaitOne();

            Console.WriteLine("Первичный поток возобновил работу.");

            manual.Reset(); // Установка несигнального состояния [ManualResetEvent(false)].

            thread = new Thread(Function) { Name = "2" }; // 2-й ПОТОК.
            thread.Start();

            Console.WriteLine("Приостановка выполнения первичного потока.");
            manual.WaitOne();

            Console.WriteLine("Первичный поток возобновил и завершил работу.");

            // Delay
            Console.ReadKey();
        }
    }
}