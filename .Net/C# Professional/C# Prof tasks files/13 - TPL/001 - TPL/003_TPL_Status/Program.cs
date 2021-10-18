using System;
using System.Threading;
using System.Threading.Tasks;

// TaskStatus - статусы задачи.

namespace TPL
{
    class Program
    {
        static void MyTask()
        {
            Thread.Sleep(3000);
        }

        static void Main()
        {
            Task task = new Task(MyTask);
            Console.WriteLine("1. " + task.Status); // Задача не запущена.

            task.Start();
            Console.WriteLine("2. " + task.Status); // Задача в процессе запуска.

            Thread.Sleep(1000);
            Console.WriteLine("3. " + task.Status); // Задача выполняется.

            Thread.Sleep(3000);
            Console.WriteLine("4. " + task.Status); // Задача завершилась.

            // Delay
            Console.ReadKey();
        }
    }
}
