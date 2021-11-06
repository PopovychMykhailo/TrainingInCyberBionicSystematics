using System;
using System.Threading;

namespace Homework_task3
{
    /* Technical task
    
        Создайте приложение, которое может быть запущено только в одном экземпляре (используя
        именованный Mutex).
    */



    class Program
    {
        static Mutex mutex = new(false, "MyMutex");

        static void Main()
        {
            // If another instance has our mutex
            if (mutex.WaitOne(0) == false)
            {
                Console.WriteLine("Only 1 instance of the program can work at a time");
                return;
            }


            // Do our work...
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Working iteration {i}...");
                Thread.Sleep(1000);
            }

            // Release mutex for another process
            mutex.ReleaseMutex();
        }
    }
}
