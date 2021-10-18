using System;

// Динамические типы данных. (Анонимные типы)

namespace Dynamic
{
    class Program
    {
        static void Main()
        {
            dynamic instance = new { Name = "Alex", Age = 18 };

            Console.WriteLine(instance.Name);
            Console.WriteLine(instance.Age);

            // Delay.
            Console.ReadKey();
        }
    }
}
