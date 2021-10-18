using System;
using System.Threading;

// Критическая секция (critical section).

namespace CriticalSection
{
    class Program
    {
        static object locker = new object();

        static void WriteSecond()
        {
            for (int i = 0; i < 20; i++)
            {
                lock (locker)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(new string(' ', 10) + "Secondary");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(100);
                }
            }
        }

        static void Main()
        {
            Console.SetWindowSize(80, 45);

            ThreadStart writeSecond = new ThreadStart(WriteSecond);
            Thread thread = new Thread(writeSecond);
            thread.Start();
          
            for (int i = 0; i < 20; i++)
            {
                lock (locker)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Primary");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(100);
                }
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
