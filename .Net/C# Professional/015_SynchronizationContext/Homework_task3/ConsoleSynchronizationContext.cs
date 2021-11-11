using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_task3
{
    internal class ConsoleSynchronizationContext : SynchronizationContext
    {
        static int counterFunc = 0;

        public override void OperationStarted()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Операция начата");
            Console.ResetColor();
        }

        public override void OperationCompleted()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Операция завершена");
            Console.ResetColor();
        }

        public override void Post(SendOrPostCallback func, object? state)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Post выполнился");
                Console.ResetColor();

                Thread thread = new Thread(new ParameterizedThreadStart(func)) { Name = $"ContextSync_thread_{counterFunc}" };
                thread.Start(state);

            }, null);
        }

        public override void Send(SendOrPostCallback d, object? state)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Send выполнился");
            Console.ResetColor();
        }
    }
}
