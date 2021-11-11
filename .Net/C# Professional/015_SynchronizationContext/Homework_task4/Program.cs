using System;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_task4
{
    /* Technical task
    
        + Создайте приложение по шаблону Console Application. 
        + Создайте контекст синхронизации, который сможет обрабатывать ошибки, возникшие в асинхронных методах с возвращаемым типом void.
        + Установите созданный контекст синхронизации и проверьте вызовом асинхронного метода с типом void, обрабатывается ли ваша ошибка в контексте. 
        + Уберите установку контекста синхронизации. 
        + Сделайте выводы на счет использования асинхронных методов с типом void. 
    */


    /* Conclusion:
        
        If we used SynchronizationContext:
            Asynchronous void methods generate an exception in SynchronizationContext.Post (), so we have to write there try-catch

        If we NOT used SynchronizationContext:
            We cannot catch exceptions in main from asynchronous methods :(
            There are two ways out:
                1. Used SynchronizationContext.
               Or
                2. Create an asynchronous method\Task that will wait for an exception from the required method.
     */


    internal class Program
    {
        static void Main(string[] args)
        {
            //SynchronizationContext.SetSynchronizationContext(new ConsoleSynchronizationContext());
            Console.WriteLine($"Main start in [thread ID {Thread.CurrentThread.ManagedThreadId}, name \"{Thread.CurrentThread.Name}\", isThreadPool {Thread.CurrentThread.IsThreadPoolThread}]");

            try
            {
                MethodAsync(-4);
                //MethodAsync(4);
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Main: Exception: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine($"Main finished in [thread ID {Thread.CurrentThread.ManagedThreadId}, name \"{Thread.CurrentThread.Name}\", isThreadPool {Thread.CurrentThread.IsThreadPoolThread}]");

            Console.ReadKey();
        }

        public static async void MethodAsync(int number)
        {
            Console.WriteLine($"\tMethodAsync start in [thread ID {Thread.CurrentThread.ManagedThreadId}, name \"{Thread.CurrentThread.Name}\", isThreadPool {Thread.CurrentThread.IsThreadPoolThread}]");

            throw new Exception("Exception1 from MethodAsync");  // This exception will not be caught in main :(
            
            try
            {
                await Task.Run(new Action(() =>
            {
                Thread.Sleep(1000);

                Console.WriteLine($"\t\tTask working in [thread ID {Thread.CurrentThread.ManagedThreadId}, name \"{Thread.CurrentThread.Name}\", isThreadPool {Thread.CurrentThread.IsThreadPoolThread}]");

                if (number < 0)
                    throw new Exception($"{nameof(MethodAsync)}: The number cannot be less than zero");

                int result = 1;
                for (int i = 1; i <= number; i++)
                    result *= i;

                Console.WriteLine($"\t\tResult: {result}");
            }));
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"MethodAsync: Exception: {ex.Message}");
                Console.ResetColor();
            }

            throw new Exception("Exception2 from MethodAsync");  // This exception will not be caught in main :(

            Console.WriteLine($"\tMethodAsync finished in [thread ID {Thread.CurrentThread.ManagedThreadId}, name \"{Thread.CurrentThread.Name}\", isThreadPool {Thread.CurrentThread.IsThreadPoolThread}]");
        }
    }
}
