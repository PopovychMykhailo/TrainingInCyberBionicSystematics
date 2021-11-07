using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_task2
{
    /* Technical task
        
        Создайте два метода, которые будут выполняться в рамках параллельных задач. Организуйте
        вызов этих методов при помощи Invoke таким образом, чтобы основной поток программы
        (метод Main) не остановил свое выполнение.
    */


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main working in thread {Thread.CurrentThread.ManagedThreadId}");


            // The lambda function for invoke tasks in parallel and not stopping the main thread
            Action runActions = () =>
            {
                Parallel.Invoke(Task1, Task2);
            };

            // Start performing all the necessary tasks
            Task tasks = Task.Factory.StartNew(runActions);


            Thread.Sleep(50);   // A small delay to start printing characters correctly
            for (int i = 0; i < 50; i++)
            {
                Console.Write("! ");
                Thread.Sleep(100);
            }

            Console.WriteLine($"\nMain finished work in thread {Thread.CurrentThread.ManagedThreadId}");
        }

        static void Task1()
        {
            Random random = new();
            int countTimes = random.Next(10, 50);

            Console.WriteLine($"Task1 working in thread {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < countTimes; i++)
            {
                Console.Write("+ ");
                Thread.Sleep(100);
            }

            Console.WriteLine($"\nTask finished in thread {Thread.CurrentThread.ManagedThreadId}");
            //return countTimes;
        }

        static void Task2()
        {
            Random random = new();
            int countTimes = random.Next(10, 50);

            Console.WriteLine($"Task2 working in thread {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < countTimes; i++)
            {
                Console.Write("- ");
                Thread.Sleep(100);
            }

            Console.WriteLine($"\nTask finished in thread {Thread.CurrentThread.ManagedThreadId}");
            //return countTimes;
        }
    }
}
