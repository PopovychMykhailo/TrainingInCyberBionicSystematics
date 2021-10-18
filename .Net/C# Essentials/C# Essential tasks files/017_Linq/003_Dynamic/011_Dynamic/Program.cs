using System;

// Динамические типы данных. (Наследование)

namespace Dynamic
{
    class Base
    {
        public dynamic field;

        public dynamic Method()
        {
            return this.field;
        }
    }

    class Derived : Base
    {

    }

    class Program
    {        
        static void Main()
        {
            dynamic instance = new Derived();

            // Динамические поля должны быть проинициализированны перед использованием.
            instance.field = "Hello";

            Console.WriteLine(instance.Method());

            // Delay.
            Console.ReadKey();
        }
    }
}
