using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_task2
{
    /* Technical task
    
        + Создайте приложение по шаблону Console Application. 
        + Создайте свой контекст синхронизации и переопределите метод Post. 
        * Метод Post должен выполнять полученный делегат в контексте потока (экземпляр класса Thread). 
        + Дайте потоку, созданному для выполнения делегата в методе Post, имя.
        + Установите в начале работы метода Main созданный контекст синхронизации. 
        + Создайте асинхронный метод, который в контексте задачи считает факториал числа через цикл. 
        + Используйте оператор await для ожидания завершения этой задачи. 
        + До и после оператора await выведите на экран консоли в каком id потока (ManagedThreadId) выполняется эта часть, 
            имя у потока (Name) и является ли поток потоком из пула (IsThreadPoolThread).
    */



    public static class Program
    {
        public static void Main()
        {
            SynchronizationContext.SetSynchronizationContext(new ConsoleSynchronizationContext());
            Console.WriteLine($"Main start in [thread ID {Thread.CurrentThread.ManagedThreadId}, name \"{Thread.CurrentThread.Name}\", isThreadPool {Thread.CurrentThread.IsThreadPoolThread}]");

            MethodAsync(5);

            Console.WriteLine($"Main finished in [thread ID {Thread.CurrentThread.ManagedThreadId}, name \"{Thread.CurrentThread.Name}\", isThreadPool {Thread.CurrentThread.IsThreadPoolThread}]");

            Console.ReadKey();
        }


        public static async void MethodAsync(int number)
        {
            Console.WriteLine($"\tMethodAsync start in [thread ID {Thread.CurrentThread.ManagedThreadId}, name \"{Thread.CurrentThread.Name}\", isThreadPool {Thread.CurrentThread.IsThreadPoolThread}]");


            Task<int> task = new Task<int>( () => 
            {
                Thread.Sleep(1000);

                Console.WriteLine($"\t\tTask working in [thread ID {Thread.CurrentThread.ManagedThreadId}, name \"{Thread.CurrentThread.Name}\", isThreadPool {Thread.CurrentThread.IsThreadPoolThread}]");

                int result = 1;
                for (int i = 0; i < number; i++)
                    result *= result++;

                return result;
            });
            task.Start();
            await task;

            Console.WriteLine($"\tMethodAsync finished in [thread ID {Thread.CurrentThread.ManagedThreadId}, name \"{Thread.CurrentThread.Name}\", isThreadPool {Thread.CurrentThread.IsThreadPoolThread}]");
        }
    }
}