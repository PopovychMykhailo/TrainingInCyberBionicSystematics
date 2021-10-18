using System;
using System.Text;
using System.Threading;

// Приоритеты потоков (Нагруженные потоки тяжелыми вычислениями для CPU).

namespace Priority
{
    class PriorityTest
    {
        public void Method()
        {
            Console.WriteLine("Поток {0,3} с приоритетом {1,11} начал работу",
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.Priority);

            Func<double, double> fib = null;
            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;

            for (int i = 0; i < 43; ++i)
                //Console.WriteLine("{0:D2}-е число: {1}", i + 1, fib(i));
                fib(i);

            Console.WriteLine("Поток {0,3} с приоритетом {1,11} завершился.",
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.Priority);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            Console.WriteLine("Приоритет первичного потока по умолчанию: {0}",
                Thread.CurrentThread.Priority);

            PriorityTest priorityTest = new PriorityTest();

            Thread[] threads = new Thread[9];

            for (int i = 0; i < 9; i++)
                threads[i] = new Thread(priorityTest.Method);

            // Установка приоритетов потокам

            threads[0].Priority = ThreadPriority.Lowest;

            for (int i = 1; i < 9; i++)
                threads[i].Priority = ThreadPriority.Highest;

            // Запуск 1-го потока с низким приоритетом
            threads[0].Start();

            // Приостановка запуска потоков с высоким приоритетом
            Thread.Sleep(2000);

            // Запуск 8-и потоков с высоким приоритетом
            for (int i = 1; i < 9; i++)
                threads[i].Start();

            Console.WriteLine(new string('-', 80));

            // Delay
            Console.ReadKey();
        }
    }
}