using System;
using System.Text;
using System.Threading;

namespace ThreadSampleMul
{
    class Program
    {
        // Общая переменная счетчик
        //[ThreadStatic] //TODO Снять комментарий // Использование TLS.
        public static int counter;

        // Рекурсивный запуск потоков
        public static void Method()
        {
            if (counter < 100)
            {
                counter++; // Увеличение счетчика вызваных методов
                Console.WriteLine(counter + " - СТАРТ --- " + Thread.CurrentThread.GetHashCode());

                Thread thread = new Thread(Method);
                thread.Start();
                thread.Join(); // Закомментировать             
            }

            Console.WriteLine("Поток {0} завершился.", Thread.CurrentThread.GetHashCode());
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Thread thread = new Thread(Method);
            thread.Start();
            thread.Join();

            Console.WriteLine("Первичный поток завершил работу.");

            // Delay
            Console.ReadKey();
        }
    }
}
