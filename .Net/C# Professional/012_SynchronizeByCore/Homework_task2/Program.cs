using System;
using System.Threading;

namespace Homework_task2
{
    /* Technical task
    
        Преобразуйте пример событийной блокировки таким образом, чтобы вместо ручной обработки
        использовалась автоматическая.
    */



    class Program
    {
        // Аргумент:
        // false - установка в несигнальное состояние.
        static ManualResetEvent manualEvent = new ManualResetEvent(false);

        static void Main()
        {
            Thread thread = new Thread(Function);
            thread.Start();
            Thread.Sleep(500);      // Дадим время запуститься вторичному потоку.

            Console.WriteLine("Нажмите на любую клавишу для перевода AutoResetEvent в сигнальное состояние.\n");
            Console.ReadKey();
            manualEvent.Set();      // Продолжение выполнения вторичного потока.
            //manualEvent.Reset();    // Set false state to the event

            Console.WriteLine("Нажмите на любую клавишу для перевода AutoResetEvent в сигнальное состояние.\n");
            Console.ReadKey();
            manualEvent.Set();      // Продолжение выполнения вторичного потока.
            manualEvent.Reset();    // Set false state to the event

            // Delay
            Console.ReadKey();
        }

        static void Function()
        {
            Console.WriteLine("Красный свет");
            manualEvent.WaitOne(); // Остановка выполнения вторичного потока.

            Console.WriteLine("Желтый");
            manualEvent.WaitOne(); // Остановка выполнения вторичного потока.

            Console.WriteLine("Зеленый");
        }
    }
}
