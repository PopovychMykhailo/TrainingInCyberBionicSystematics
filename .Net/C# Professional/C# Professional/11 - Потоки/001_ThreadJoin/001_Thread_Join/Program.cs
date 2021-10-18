using System;
using System.Text;
using System.Threading;

namespace ThreadSample
{
    class Program
    {
        // Метод выполяняющийся во Вторичном потоке.
        static void Function()
        {
            Console.WriteLine("ID Вторичного потока: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < 160; i++ )
            {                
                Thread.Sleep(20);
                Console.Write(".");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Вторичный поток завершился.");
        }

        static void Main() // Метод Main - выполняется в первичном потоке.
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("ID Первичного потока: {0}", Thread.CurrentThread.GetHashCode());

            // Создание нового потока
            Thread thread = new Thread(new ThreadStart(Function));
            thread.Start();
            
            // Ожидание первичным потоком, завершения работы вторичного потока.
            thread.Join(); //TODO Снять или установить комментарий.

            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < 160; i++)
            {                
                Thread.Sleep(20);
                Console.Write("-");
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nПервичный поток завершился.");

            // Delay
            Console.ReadKey();
        }
    }
}
