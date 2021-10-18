using System;
using System.Threading;

namespace monitor
{
    class Program
    {
        static object block = new object();
        static int counter;
        static Random random = new Random();

        private static void Function()
        {
            lock (block)
            {
                counter++;
            }

            int time = random.Next(1000, 12000);
            Thread.Sleep(time);

            lock (block)
            {
                counter--;
            }
        }

        private static void Report()
        {
            while (true)
            {
                int count;

                lock (block)
                {
                    count = counter;
                }

                Console.WriteLine("{0} потоков активно", count);
                Thread.Sleep(100);
            }
        }

        static void Main()
        {
            Thread reporter = new Thread(Report) { IsBackground = true };
            reporter.Start();

            Thread[] threads = new Thread[150];

            for (uint i = 0; i < 150; ++i)
            {
                threads[i] = new Thread(Function);
                threads[i].Start();
            }

            // Delay
            Console.ReadKey();
        }
    }
}
