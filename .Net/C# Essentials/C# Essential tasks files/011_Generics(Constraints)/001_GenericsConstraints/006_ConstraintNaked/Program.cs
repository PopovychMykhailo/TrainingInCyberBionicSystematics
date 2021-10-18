using System;

// Ограничения параметров типа - "naked"

namespace GenericsConstraints
{
    // Аргумент типа, предоставляемый в качестве T, должен совпадать с аргументом, предоставляемым в качестве U, или быть производным от него.
    // Это называется ограничением типа "Naked".

    class MyClass<T, R, U> where T : U
    {
    }

    class Program
    {
        static void Main()
        {
            MyClass<int, Object, Object> my1 = new MyClass<int, Object, Object>();

            MyClass<string, Object, string> my2 = new MyClass<string, Object, string>();

            // Не совпадают первый и третий аргументы типов - T и U (string и int).
            //MyClass<string, Object, int> my2 = new MyClass<string, Object, int>();  // ОШИБКА!  

            // Delay.
            Console.ReadKey();
        }
    }
}
