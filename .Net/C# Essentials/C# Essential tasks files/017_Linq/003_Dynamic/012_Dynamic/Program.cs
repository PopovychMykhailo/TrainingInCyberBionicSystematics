using System;

// Динамические типы данных. 

namespace Dynamic
{
    class MyClass
    {
        
    }

    class Program
    {
        static dynamic FactoryMethod()
        {
            return new MyClass();
        }

        static void Main()
        {
            dynamic instance = FactoryMethod() as dynamic;

            if (false)
            {
                instance.Method(7);                  // Вызов метода.
                instance.field = instance.Property;  // Получение и установка значений полей и свойств.
                instance["one"] = instance[2];       // Получение и установка значений через индексаторы.
                dynamic variable = instance + 3;     // Вызов операторов.
                variable = instance(5, 7);           // Вызов делегатов.
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
