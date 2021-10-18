using System;
using System.Threading;

// Рекурсивное запирание.

namespace MutexSample
{    
    class Program
    {
        static Mutex mutex = new Mutex();

        public static void Method1()
        {
            mutex.WaitOne();
            Console.WriteLine("Method1 Start " + Thread.CurrentThread.ManagedThreadId);
            Method2();
            mutex.ReleaseMutex();
            Console.WriteLine("Method1 Finish " + Thread.CurrentThread.ManagedThreadId);
        }

        public static void Method2()
        {
            mutex.WaitOne();
            Console.WriteLine("Method2 Start " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000); // ...
            mutex.ReleaseMutex();
            Console.WriteLine("Method2 Finish " + Thread.CurrentThread.ManagedThreadId);
        }

        static void Main()
        {
            Thread thread = new Thread(Method1);
            thread.Start();
            thread.Join();

            // Delay
            Console.ReadKey();
        }
    }
}
