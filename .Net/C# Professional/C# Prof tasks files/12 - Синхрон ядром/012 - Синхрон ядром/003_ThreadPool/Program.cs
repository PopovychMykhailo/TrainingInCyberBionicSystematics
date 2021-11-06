using System;
using System.Text;
using System.Threading;

// Пул потоков - ThreadPool.

namespace ThreadPoolNs
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Начало работы программы");
            Report();

            // Запуск Task1 в потоке входящем в пул потоков
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task1));
            Report();

            // Запуск Task2 в потоке входящем в пул потоков
            ThreadPool.QueueUserWorkItem(Task2);
            Report();

            Thread.Sleep(3000);
            Console.WriteLine("Завершение работы программы");
            Report();

            // Delay
            Console.ReadKey();
        }

        static void Task1(Object state)
        {
            Thread.CurrentThread.Name = "1";
            Console.WriteLine("Запущен поток {0}\n", Thread.CurrentThread.Name);
            Thread.Sleep(2000);
            Console.WriteLine("Поток {0} завершил работу\n", Thread.CurrentThread.Name);
        }

        static void Task2(Object state)
        {
            Thread.CurrentThread.Name = "2";
            Console.WriteLine("Запущен поток {0}\n", Thread.CurrentThread.Name);
            Thread.Sleep(500);
            Console.WriteLine("Поток {0} завершил работу\n", Thread.CurrentThread.Name);
        }


        static void Report()
        {            
            Thread.Sleep(200);
            int availableWorkThreads, availableIOThreads, maxWorkThreads, maxIOThreads;
            ThreadPool.GetAvailableThreads(out availableWorkThreads, out availableIOThreads);
            ThreadPool.GetMaxThreads(out maxWorkThreads, out maxIOThreads);

            Console.WriteLine("Доступно рабочих потоков в пуле     :{0} из {1}", availableWorkThreads, maxWorkThreads);
            Console.WriteLine("Доступно потоков ввода-вывода в пуле:{0} из {1}\n", availableIOThreads, maxIOThreads);
        }
    }
}
