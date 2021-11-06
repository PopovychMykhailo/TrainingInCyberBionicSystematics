using System;
using System.IO;
using System.Threading;

namespace Classwork_task1
{
    /* Technical task
    
        Создайте Semaphore, осуществляющий контроль доступа к ресурсу из нескольких потоков.
        Организуйте упорядоченный вывод информации о получении доступа в специальный *.log
        файл.
    */



    class Program
    {
        static Semaphore semaphore;


        static void Main()
        {
            semaphore = new Semaphore(1, 1, "MyThreadsPool");   // Only 1 thread works at a time

            // Create threads that will access the file
            for (int i = 1; i <= 10; i++)
                new Thread(Method).Start(parameter: i);

        }

        static void Method(object threadNumber)
        {
            semaphore.WaitOne();    // "Check" the pool for free slots for work
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Thread {threadNumber} starts working.");


            StreamReader streamReader = new(File.Open("text.txt", FileMode.Open, FileAccess.Read, FileShare.None));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"File has:  {streamReader.ReadLine()}");
            Thread.Sleep(300);      // Go to sleep mode to check if another thread does not have access to the file
            streamReader.Close();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Thread {threadNumber} has finished work.\n");
            semaphore.Release();    // "Clear" our thread from the pool
        }
    }
}
