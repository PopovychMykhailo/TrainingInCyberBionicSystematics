using System;
using System.Text;
using System.Threading;

// Приоритеты потоков

namespace Priority
{
    class PriorityTest
    {
        public bool stop = false;

        public void Method()
        {
            Console.WriteLine("Поток {0,3} с приоритетом {1,11} начал работу",
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.Priority);

            long count = 0;

            // Буфер предсказаний переходов CPU может изменить работу исходного алгоритма.
            // Операция инкремента занимает примерно 6 тактов CPU.
            while (!stop)
                count++;

            Console.WriteLine("Поток {0,3} с приоритетом {1,11} завершился. Count = {2,13}",
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.Priority,
                count.ToString("N0"));
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

            // Дать 10 секунд на выполнение потоков
            Thread.Sleep(10000);

            Console.WriteLine("Первичный поток проснулся и втиснулся между высокоприоритетных потоков");

            // Остановка работы всех потоков
            priorityTest.stop = true;

            // Delay
            Console.ReadKey();
        }
    }
}