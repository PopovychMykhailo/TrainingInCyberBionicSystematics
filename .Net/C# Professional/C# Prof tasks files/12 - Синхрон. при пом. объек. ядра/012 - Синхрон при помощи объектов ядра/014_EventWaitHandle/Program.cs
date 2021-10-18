using System;
using System.Text;
using System.Threading;

// Для тестирования данного примера, запустить несколько экземпляров данного приложения.

namespace GlobalEventNs
{
    class Program
    {
        static EventWaitHandle handle = null;

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Аргументы:
            // 1. false - несигнальное состояние.
            // 2. EventResetMode.ManualReset - тип события.
            // 3. [GlobalEvent::GUID] - имя объекта синхронизации в OS.
            //    Если объект ядра с именем [GlobalEvent::GUID] уже существует будет получена ссылка на него.

            handle = new EventWaitHandle(false, EventResetMode.ManualReset, "GlobalEvent::GUID");

            Thread thread = new Thread(Function) { IsBackground = true};
            thread.Start();

            Console.WriteLine("Нажмите любую клавишу для начала работы.");
            Console.ReadKey();

            // Все приложения, которые используют событие с именем [GlobalEvent::GUID], 
            // получат оповещение о переходе в сигнальное состояние.
            handle.Set();

            // Delay
            Console.ReadKey();
        }

        static void Function()
        {
            handle.WaitOne(); // Приостановка работы потока.

            while (true)
            {
                Console.WriteLine("Hello world!");
                Thread.Sleep(300);
            }
        }
    }
}
