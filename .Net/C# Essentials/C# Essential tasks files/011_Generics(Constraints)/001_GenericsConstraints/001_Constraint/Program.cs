using System;

// Ограничения параметров типа.

namespace GenericsConstraints
{
    // where T : class  -   Аргумент типа должен иметь ссылочный тип, это также распространяется на тип любого класса, интерфейса, делегата или массива.
    class MyClass1<T> where T : class
    {
        public T variable;
    }

    // where T : struct  -  Аргумент типа должен иметь тип значения. Допускается указание любого типа значения, кроме Nullable.
    class MyClass2<T> where T : struct
    {
        public T variable;
    }

    class Program
    {
        static void Main()
        {
            MyClass1<string> instance1 = new MyClass1<string>();
            //MyClass1<int> instance1 = new MyClass1<int>();                // Ошибка.    int - структурный тип.

            MyClass2<int> instance2 = new MyClass2<int>();
            //MyClass2<string> instance2 = new MyClass2<string>();          // Ошибка.    string - ссылочный тип.

            // Delay.
            Console.ReadKey();
        }
    }
}
