using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// WaitAll() - Ожидает завершения выполнения всех указанных объектов Task.
// WaitAny() - Ожидает завершения выполнения любого из указанных объектов Task.

namespace TPL
{
    class Program
    {
        static void MyTask1()
        {
            Console.WriteLine("MyTask: CurrentId " + Task.CurrentId + " запущен.");
            Thread.Sleep(2000);
            Console.WriteLine("MyTask: CurrentId " + Task.CurrentId + " завершен.");
        }
        static void MyTask2()
        {
            Console.WriteLine("MyTask: CurrentId " + Task.CurrentId + " запущен.");
            Thread.Sleep(3000);
            Console.WriteLine("MyTask: CurrentId " + Task.CurrentId + " завершен.");
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Основной поток запущен.");

            Task task1 = new Task(MyTask1);
            Task task2 = new Task(MyTask2);

            task1.Start();
            task2.Start();

            Console.WriteLine("Id задачи task1: " + task1.Id);
            Console.WriteLine("Id задачи task2: " + task2.Id);

            Task.WaitAll(task1, task2);
            //Task.WaitAny(task1, task2);

            Console.WriteLine("Основной поток завершен.");

            // Delay
            Console.ReadKey();
        }
    }
}
