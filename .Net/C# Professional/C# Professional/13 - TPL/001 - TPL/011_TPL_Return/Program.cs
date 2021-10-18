using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Возвращение значения из задачи.

namespace TPL
{
    struct Context
    {
        public int a;
        public int b;
    }

    class Program
    {
        // Метод который будет возвращать результат.
        static int Sum(object arg)
        {
            int a = ((Context)arg).a;
            int b = ((Context)arg).b;

            Thread.Sleep(2000);

            return a + b;
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Основной поток запущен.");

            Context context;
            context.a = 2;
            context.b = 3;

            Task<int> task;

            // 1 вариант
            task = new Task<int>(Sum, context);
            task.Start();

            // 2 вариант
            //TaskFactory<int> factory = new TaskFactory<int>();
            //task = factory.StartNew(Sum, context);

            // 3 вариант
            //task = Task<int>.Factory.StartNew(Sum, context);

            Console.WriteLine("Результат выполнения задачи Sum = " + task.Result);

            Console.WriteLine("Основной поток завершен.");

            // Delay
            Console.ReadKey();
        }
    }
}
