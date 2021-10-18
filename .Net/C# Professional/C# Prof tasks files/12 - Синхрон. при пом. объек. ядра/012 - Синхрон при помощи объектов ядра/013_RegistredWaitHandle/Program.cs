using System;
using System.Text;
using System.Threading;

// Блокировка потоков которые находятся в контексте пула потоков [ThreadPool].

namespace RegistredWaitHandleNs
{
    class Program
    {
        static void Function(object state, bool timedOut)
        {
            Console.WriteLine("Signal");
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            AutoResetEvent auto = new AutoResetEvent(false);
            WaitOrTimerCallback callback = new WaitOrTimerCallback(Function);

            // Аргументы:
            // 1. auto - от кого ждать сингнал.
            // 2. callback - что выполнять.
            // 3. null - 1-й аргумент Callback метода.
            // 4. 2000 - интервал между вызовами Callback метода.
            // 5. true - вызвать Callback метод один раз. false - вызывать Callback метод с интервалом.

            RegisteredWaitHandle handle = ThreadPool.RegisterWaitForSingleObject(auto, callback, null, 2000, false);
            //RegisteredWaitHandle handle = ThreadPool.RegisterWaitForSingleObject(auto, callback, null, Timeout.Infinite, true);

            Console.WriteLine("S - сигнал, Q - выход");

            while (true)
            {
                string operation = Console.ReadKey(true).KeyChar.ToString().ToUpper();

                if (operation == "S")
                {
                    auto.Set();
                }
                if (operation == "Q")
                {
                    handle.Unregister(auto);
                    break;
                }
            }

            // Delay
            Console.ReadKey();
        }
    }
}
