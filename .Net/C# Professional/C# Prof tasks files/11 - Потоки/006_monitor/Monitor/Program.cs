using System;
using System.Text;
using System.Threading;

namespace monitor
{
    class Program
    {
        // Объект для блокировки.
        static object block = new object();

        // Счетчик потоков.
        static int counter;
        static Random random = new Random();

        // Выполняется в отдельном потоке.
        private static void Function()
        {
            try
            {
                Monitor.Enter(block); // Начало блокировки. lock(block){
                counter++;
            }
            finally
            {
                Monitor.Exit(block);  // Конец блокировки. }
            }

            int wait = random.Next(1000, 12000);
            Thread.Sleep(wait);

            try
            {
                Monitor.Enter(block); // Начало блокировки.
                counter--;
            }
            finally
            {
                Monitor.Exit(block);  // Конец блокировки.
            }
        }

        // Мониторинг количества запущеных потоков.
        static void Report()
        {
            while (true)
            {
                int count;

                try
                {
                    Monitor.Enter(block); // Начало блокировки.
                    count = counter;
                }
                finally
                {
                    Monitor.Exit(block);  // Конец блокировки.
                }

                Console.WriteLine("{0} потоков активно", count);
                Thread.Sleep(100);
            }
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            var reporter = new Thread(Report) { IsBackground = true };
            reporter.Start();

            var threads = new Thread[150];

            for (uint i = 0; i < 150; ++i)
            {
                threads[i] = new Thread(Function);
                threads[i].Start();
            }

            Thread.Sleep(15000);
        }
    }
}
