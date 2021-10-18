using System;
using System.Threading;

namespace Classwork_task1
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Напишите программу, в которой метод будет вызываться рекурсивно.
        Каждый новый вызов метода выполняется в отдельном потоке.
    */


    class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart method = new ParameterizedThreadStart(Method);
            Thread thread = new Thread(method);
            thread.Start(1);
        }

        static void Method(object sequenceNumber)
        {
            Console.WriteLine($"Sequence number: {sequenceNumber}");

            ParameterizedThreadStart method = new ParameterizedThreadStart(Method);
            Thread thread = new Thread(method);
            thread.Start((int)sequenceNumber + 1);

            //while (true)
            //{
            //    //Console.WriteLine($"while tread: {sequenceNumber}");
            //}

            Console.WriteLine("End thread");
        }
    }
}
