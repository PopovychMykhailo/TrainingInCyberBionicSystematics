using System;
using System.Text;
using System.Threading;

// Есть два варианта работы потоков Foreground и Background
// Foreground - Будет работать после завершения работы первичного потока.
// Background - Завершает работу вместе с первичным потоком.

namespace ForeGround
{
    class Program
    {
        static void Procedure()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
                Console.Write(".");
            }
            Console.WriteLine("\nЗавершение вторичного потока.");
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            var thread = new Thread(Procedure);

            Console.WriteLine(thread.IsBackground);

            // IsBackground - устанавливает поток как фоновый. Не ждем завершения вторичного потока в данном случае.
            // По умолчанию - thread.IsBackground = false; 

            //thread.IsBackground = true; // Закомментировать.
            thread.Start();
      
            Thread.Sleep(500);

            Console.WriteLine("\nЗавершение главного потока.");
        }
    }
}
