using System;
using System.Runtime.InteropServices;
using System.Text;

// dynamic - замер производительности.

namespace Dynamic
{
    class MyСlass
    {
        public void DoWork()
        {
            Console.Write("Выполняется работа... ");
        }
    }

    class Program
    {
        [DllImport("kernel32.dll")]
        // API функция QueryPerformanceCounter считает временные интервалы по тактам процессора.
        private static extern int QueryPerformanceCounter(out Int64 count);

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Вызвать DoWork один раз статически, чтобы выполнилась JIT-компиляция. 
            MyСlass instance = new MyСlass();

            instance.DoWork();

            dynamic cast = instance;

            for (int i = 0; i < 10; ++i) 
            {
                Int64 start, end;
                QueryPerformanceCounter(out start);

                cast.DoWork(); // Запускает JIT как первый раз.

                QueryPerformanceCounter(out end);

                Console.WriteLine("Тиков: {0}", end - start);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
