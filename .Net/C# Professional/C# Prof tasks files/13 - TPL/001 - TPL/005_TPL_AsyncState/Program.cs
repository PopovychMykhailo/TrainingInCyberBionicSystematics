using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        static void MyTask(object arg)
        {
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(25);
                Console.Write(arg as string);
            }
        }

        static void Main()
        {
            // Второй аргумент конструктора Task - ".", 
            // попадет в качестве аргумента метода MyTask
            Action<object> myTask = MyTask;
            Task task = new Task(myTask, ".");
            task.Start();

            Thread.Sleep(500);

            // Для того чтобы AsyncState был равен не null, требуется использовть 
            // конструктор Task(Action<object> action, object state);
            // Второй аргумент конструктора Task - ".", 
            // попадет в качестве значения свойства AsyncState
            Console.WriteLine("\n[{0}]", task.AsyncState as string);

            // Delay
            Console.ReadKey();
        }
    }
}
