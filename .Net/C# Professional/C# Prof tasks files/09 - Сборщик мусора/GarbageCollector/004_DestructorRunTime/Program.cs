using System;
using System.Threading;

namespace DestructorRunTime
{
    class MyClass
    {
        // Время жизни деструктора ограничено 
        // (индивидуально для разных конфигураций систем).
        ~ MyClass()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
            GC.Collect();
            //Console.ReadKey();
        }
    }
}
