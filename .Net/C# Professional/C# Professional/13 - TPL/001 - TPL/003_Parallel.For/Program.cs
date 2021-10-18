using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

// Сравнение последовательного и параллельного выполнения цикла for.
// Пример выполнять через (CTRL+F5).

namespace TPL
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            int[] data = new int[100_000_000];

            Stopwatch timer = new Stopwatch();

            timer.Start();

            Parallel.For(0, data.Length, i => data[i] = i); // Параллельная инициализация.

            timer.Stop();
            Console.WriteLine("Параллельная инициализация      : {0} секунд.", timer.Elapsed.TotalSeconds);
            timer.Reset();

            timer.Start();

            for (int i = 0; i < data.Length; i++)  // Последовательная инициализация.
                data[i] = i;

            timer.Stop();
            Console.WriteLine("Последовательная инициализация  : {0} секунд.\n", timer.Elapsed.TotalSeconds);
            timer.Reset();

            timer.Start();

            Parallel.For(0, data.Length, i => data[i] = i * i * i / 123); // Параллельное преобразование.

            timer.Stop();
            Console.WriteLine("Параллельное преобразование     : {0} секунд.", timer.Elapsed.TotalSeconds);
            timer.Reset();

            timer.Start();

            for (int i = 0; i < data.Length; i++) // Последовательное преобразование.
                data[i] = i * i * i / 123;

            timer.Stop();
            Console.WriteLine("Последовательное преобразование : {0} секунд.", timer.Elapsed.TotalSeconds);
            timer.Reset();

            Console.WriteLine("\nОсновной поток завершен.");
        }
    }
}
