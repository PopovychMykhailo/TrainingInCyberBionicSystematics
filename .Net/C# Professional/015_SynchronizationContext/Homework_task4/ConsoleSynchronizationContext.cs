using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_task4
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
            try
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"Post выполнился (для метода {func.Method}");
                Console.ResetColor();

                func.Invoke(state);
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
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
