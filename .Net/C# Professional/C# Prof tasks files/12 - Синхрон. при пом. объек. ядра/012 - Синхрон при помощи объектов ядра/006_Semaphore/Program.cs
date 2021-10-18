using System;
using System.Text;
using System.Threading;

// Класс Semaphore - используется для управления доступом к пулу ресурсов. 
// Потоки занимают слот семафора, вызывая метод WaitOne() 
// и освобождают занятый слот вызовом метода Release().

namespace MyNamespace
{
    public class Program
    {
        static Semaphore pool;

        static void Function(object number)
        {
            pool.WaitOne();

            Console.WriteLine("Поток {0} занял слот семафора.", number);
            Thread.Sleep(2000);
            Console.WriteLine("Поток {0} -----> освободил слот.", number);

            pool.Release();
        }

        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            /*
               Аргументы:
               1. [сколько человек пускать на мост]
                  Задаем количество слотов для использования в данный момент 
                  (не более максимального клоличества задаваемого вторым аргументом).
               2. [сколько человек выдержит мост - запас прочности]
                  Задаем максимальное количество слотов для данного семафора.
               3. [имя моста - Дворцовый мост]
                  Имя семафора в операционной системе.
            */
            pool = new Semaphore(2, 4, "MySemafore");

            //pool.Release(2); // Сброс семафора - разрешить 4.

            for (int i = 1; i <= 8; i++)
            {
                new Thread(Function).Start(i);
                //Thread.Sleep(500);  // Потоки из разных процессов успеют стать в очередь вперемешку.
            }

            // Delay
            Console.ReadKey();
        }
    }
}

