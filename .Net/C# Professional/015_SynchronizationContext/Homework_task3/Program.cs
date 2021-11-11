using System;
using System.Threading;
using System.Threading.Tasks;



namespace Homework_task3
{
    /* Technical task
    
        Создайте приложение по шаблону Console Application. Возьмите предыдущий пример (Задание 2), не
        убирая/не изменяя контекст синхронизации выполните продолжение оператора await в контексте
        рабочего потока пула потоков.
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

            Task<int> task = new Task<int>(() =>
            {
                Thread.Sleep(1000);

                Console.WriteLine($"\t\tTask working in [thread ID {Thread.CurrentThread.ManagedThreadId}, name \"{Thread.CurrentThread.Name}\", isThreadPool {Thread.CurrentThread.IsThreadPoolThread}");

                int result = 1;
                for (int i = 0; i < number; i++)
                    result *= result++;

                return result;
            });
            task.Start();

            // Pass the continuation code to ThreadPool
            await task.ContinueWith((Task<int> task_) => 
            { 
                ThreadPool.QueueUserWorkItem(callBack:
                    new WaitCallback((object state) =>
                    {
                        Console.WriteLine($"\tMethodAsync finished in [thread ID {Thread.CurrentThread.ManagedThreadId}, name \"{Thread.CurrentThread.Name}\", isThreadPool {Thread.CurrentThread.IsThreadPoolThread}]");
                    })); 
            });
        }
    }
}
