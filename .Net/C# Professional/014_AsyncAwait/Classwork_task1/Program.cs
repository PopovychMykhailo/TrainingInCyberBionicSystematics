using System;
using System.Threading;
using System.Threading.Tasks;

namespace Classwork_task1
{
    /* Technical task
    
        Переделайте дополнительное задание из урока №11 с использованием конструкции async-await.
    */

    class Program
    {
        static int counter = 0;
        static object block = 0; // block - був int, а треба щоб був ссилочного типу: object
        static AutoResetEvent autoResetEvent = new(false);

        static async void Function()
        {
            autoResetEvent.WaitOne();   // Wait for this task to get an event to work on

            Action action = () =>
            {
                Console.WriteLine($"Function start work in thread {Thread.CurrentThread.ManagedThreadId}");

                for (int i = 0; i < 50; ++i)
                {
                    // Устанавливается блокировка каждый (50!) раз в новый object (boxing).
                    Monitor.Enter((object)block); // boxing создает новый объект (50! объектов).

                    // Выполнение некоторой работы потоком ...
                    Console.Write($"{++counter} ");
                    Thread.Sleep(10);

                    // Попытка снять блокировку с объекта который не является объектом блокировки.
                    Monitor.Exit((object)block); // boxing создает абсолютно новый объект.
                }

                Console.WriteLine($"\nFunction finished work in thread {Thread.CurrentThread.ManagedThreadId}");
            };
            Task task = Task.Factory.StartNew(action);
            await task;

            autoResetEvent.Set();       // Pass the event to the next task
        }

        static void Main()
        {
            Console.WriteLine($"MAIN start work in thread {Thread.CurrentThread.ManagedThreadId}");

            Task[] tasks = { new Task(Function), new Task(Function), new Task(Function) };

            // Start everyone task
            foreach(Task task in tasks)
                task.Start();
            autoResetEvent.Set();   // Start the process

            Task.WaitAll(tasks);
            // Because the last task returns the main thread at startup, and Task.WaitAll () frees our thread - so wait for the event
            autoResetEvent.WaitOne();   

            Console.WriteLine($"\nMAIN finished work in thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
