using System;
using System.Text;
using System.Threading;

// Критическая секция (critical section).

// lock - блокирует блок кода так, что в каждый отдельный момент времени, этот блок кода
// сможет использовать только один поток. Все остальные потоки ждут пока текущий поток, закончит работу.

namespace CriticalSection
{
    class MyClass
    {
        object block = new object();

        public void Method()
        {
            int hash = Thread.CurrentThread.GetHashCode();

            lock (block) // Закомментировать lock.
            {
                for (int counter = 0; counter < 10; counter++)
                {
                    Console.WriteLine($"Поток # {hash}: шаг {counter}");
                    Thread.Sleep(100);
                }
                Console.WriteLine(new string('-', 20));                
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

                Thread.Sleep(500);

                // Delay.
                Console.ReadKey();
            }
        }
    }
}