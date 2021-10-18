using System;
using System.Threading;
using System.Threading.Tasks;

// Создание экземпляра задачи с использованием фабрики задач
// [применение класса TaskFactory для создания и запуска задачи].

namespace TPL
{
    class Program
    {
        static void MyTask()
        {
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(20);
                Console.Write(".");
            }
        }

        static void Main()
        {
            // Вариант 1.
            Task task = Task.Factory.StartNew(MyTask);
            // При запуске задачи через TaskFactory, вызов метода Start() не требуется.
            //task.Start();

            // Вариант 2.
            //TaskFactory factory = new TaskFactory();
            //Task task = factory.StartNew(MyTask);

            // Delay
            Console.ReadKey();
        }
    }
}
