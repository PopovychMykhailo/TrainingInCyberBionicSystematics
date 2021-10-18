using System;

// Динамические типы данных. (Нестатические поля)

namespace Dynamic
{
    class Program
    {
        dynamic field = 1, field2 = "Hello", field3 = true;

        static void Main()
        {
            dynamic instance = new Program();

            Console.WriteLine(instance.field);

            instance.field = "Hello world!";

            Console.WriteLine(instance.field);

            instance.field = DateTime.Now;

            Console.WriteLine(instance.field);

            // Delay.
            Console.ReadKey();
        }
    }
}
