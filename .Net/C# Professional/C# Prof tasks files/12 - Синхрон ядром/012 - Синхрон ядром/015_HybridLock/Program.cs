using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace SimpleLock
{
    class Program
    {
        static readonly HybridLock block = new HybridLock();

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Thread[] threads = { new Thread(Function), new Thread(Function), new Thread(Function), new Thread(Function) };

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Name = i.ToString(CultureInfo.InvariantCulture);
                threads[i].Start();
            }

            // Delay.
            Thread.Sleep(1000);
        }

        static void Function()
        {

            block.Enter();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Поток {0} выполнил операцию.", Thread.CurrentThread.Name);
            }
            block.Leave();


        }
    }

    class HybridLock : IDisposable
    {
        private int count; // для использования примитивной конструкцией пользовательского режима.
        private readonly AutoResetEvent auto = new AutoResetEvent(false);

        public void Enter()
        {
            if (Interlocked.Increment(ref count) == 1)
                return;
            // else if (count > 1)

            auto.WaitOne();
        }

        public void Leave()
        {
            if (Interlocked.Decrement(ref count) == 0)
                return;

            auto.Set();
        }

        public void Dispose()
        {
            auto.Dispose();
        }
    }
}
