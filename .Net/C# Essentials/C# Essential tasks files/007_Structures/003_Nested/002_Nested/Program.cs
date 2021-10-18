using System;

// Nested structures.

// Структуры могут содержать вложенные классы.

namespace Nested
{
    struct MyStruct
    {
        public class Nested
        {
            public void Method()
            {
                Console.WriteLine("Nested");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MyStruct.Nested instance = new MyStruct.Nested();
            instance.Method();

            // Delay.
            Console.ReadKey();
        }
    }
}
