using System;
using System.Diagnostics;
using System.Threading;

namespace _012_1_ManualresetEventSlimPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            var mres = new ManualResetEventSlim(false);
            var mres2 = new ManualResetEventSlim(false);

            var mre = new ManualResetEvent(false);

            long total = 0;
            int COUNT = 5;

            for (int i = 0; i < COUNT; i++)
            {
                mres2.Reset();
                //счётчик затраченного времени
                Stopwatch sw = Stopwatch.StartNew();

                //запускаем установку в потоке пула
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    MethodSlim(mres, true);
                    //Method(mre, true);
                    mres2.Set();
                });
                //запускаем сброс в основном потоке
                MethodSlim(mres, false);
                //Method(mre, false);

                //Ждём, пока выполнится поток пула
                mres2.Wait();
                sw.Stop();

                Console.WriteLine("Pass {0}: {1} ms", i, sw.ElapsedMilliseconds);
                total += sw.ElapsedMilliseconds;
            }

            Console.WriteLine();
            Console.WriteLine("===============================");
            Console.WriteLine("Done in average=" + total / (double)COUNT);
            Console.ReadLine();
        }

        // работаем с ManualResetEventSlim
         static void MethodSlim(ManualResetEventSlim mre, bool value)
        {
            //в цикле повторяем действие достаточно большое число раз
            for (int i = 0; i < 9000000; i++)
            {
                if (value)
                {
                    mre.Set();
                }
                else
                {
                    mre.Reset();
                }
            }
        }

        // работаем с классическим ManualResetEvent
         static void Method(ManualResetEvent mre, bool value)
        {
            //в цикле повторяем действие достаточно большое число раз
            for (int i = 0; i < 9000000; i++)
            {
                if (value)
                {
                    mre.Set();
                }
                else
                {
                    mre.Reset();
                }
            }
        }
    }
}

