using System;
using System.Text;
using System.Threading;

// Альтернативные операции VolatileWrite() и VolatileRead() ключевому слову volatile.

namespace VolatileSample2
{
    class Program
    {
        static int stop;

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Thread thread = new Thread(Function);
            thread.Start();

            Thread.Sleep(2000);

            Thread.VolatileWrite(ref stop, 1); // stop = 1;
            Console.WriteLine("Main: ожидание завершения вторичного потока.");
            thread.Join();
        }

        private static void Function()
        {
            int x = 0;

            while (Thread.VolatileRead(ref stop) != 1)
            {
                x++;
            }

            Console.WriteLine("Function: поток остановлен при x = {0}.", x);
        }
    }
}
