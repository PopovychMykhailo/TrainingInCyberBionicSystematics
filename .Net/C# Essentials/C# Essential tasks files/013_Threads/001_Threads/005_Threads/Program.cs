using System;
using System.Threading;

// Потоки. Анонимные методы.

namespace Threads
{
    class Program
    {
        static void Main()
        {
            int counter = 0;

            // ThreadStart
            Thread thread = new Thread(delegate() { Console.WriteLine($"1. counter = {++counter}"); });
            thread.Start();

            Thread.Sleep(100);
            Console.WriteLine($"2. counter = {counter}");

            // ParameterizedThreadStart
            thread = new Thread((object argument) => { Console.WriteLine($"3. counter = {(int)argument}"); });
            thread.Start(counter);

            // Delay.
            Console.ReadKey();
        }
    }
}
