using System;

// Ограничения параметров типа

namespace GenericsConstraints
{
    class Base { }
    class Derived : Base { }

    // where T : Base -  Аргумент типа должен являться или быть производным от указанного базового класса.
    class MyClass<T> where T : Base
    {
    }
    
    class Program
    {
        static void Main()
        {
            MyClass<Base> mc1 = new MyClass<Base>();

            MyClass<Derived> mc2 = new MyClass<Derived>();

            //MyClass<string> mc3 = new MyClass<string>();     // Ошибка.

            // Delay.
            Console.ReadKey();
        }
    }
}
