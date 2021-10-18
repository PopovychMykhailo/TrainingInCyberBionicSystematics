using System;
using System.Text;
using System.Threading;

// Критическая секция (critical section).

// lock - это сокращенное использование System.Threading.Monitor.
// Monitor.Enter(this) - блокирует блок кода так, что его может использовать только текущий поток. 
// Все остальные потоки ждут пока текущий поток, закончит работу и вызовет Monitor.Exit(this).

namespace CriticalSection
{
    class MyClass
    {
        object block = new object();

        public void Method()
        {
            int hash = Thread.CurrentThread.GetHashCode();

            Monitor.Enter(block); // Закомментировать.

            for (int counter = 0; counter < 10; counter++)
            {
                Console.WriteLine($"Поток # {hash}: шаг {counter}");
                Thread.Sleep(100);
            }
            Console.WriteLine(new string('-', 20));

            Monitor.Exit(block);  // Закомментировать.
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.SetWindowSize(80, 40);

            MyClass instance = new MyClass();

            for (int i = 0; i < 3; i++)
            {
                new Thread(instance.Method).Start();
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
