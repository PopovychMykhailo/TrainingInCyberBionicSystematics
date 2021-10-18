using System;
using System.Text;
using System.Threading;

// Interlocked - Предоставляет атомарные операции для переменных, общедоступных нескольким потокам.

namespace InterLocked
{
    class Program
    {
        // Счетчик запущеных потоков
        static long counter;
        static object block = new object();

        static void Procedure()
        {
            // Увеличение счетчика

            for (int i = 0; i < 1000000; i++)
            {
                //counter++;

                Interlocked.Increment(ref counter);
                
                //lock (block)
                //{
                //    counter++;
                //}
            }
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Ожидаемое значение счетчика = 10000000");

            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; ++i)
                (threads[i] = new Thread(Procedure)).Start();

            for (int i = 0; i < 10; ++i)
                threads[i].Join();

            Console.WriteLine("Реальное значение счетчика  = {0}", counter);

            // Delay
            Console.ReadKey();
        }
    }
}
