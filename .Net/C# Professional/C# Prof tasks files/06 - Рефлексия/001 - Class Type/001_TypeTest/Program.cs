using System;
using System.Text;

// Рефлексия. Пример получения экземпляра Type.

namespace TypeTest
{
    class MyClass
    {
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            MyClass my = new MyClass();
            Type type;

            /* Способы получения экземрляра класса Type. */

            // 1.
            type = my.GetType();
            Console.WriteLine("1й способ: " + type);

            // 2.
            // Полное квалифицированое имя типа в строковом представлении.
            type = Type.GetType("TypeTest.MyClass");
            Console.WriteLine("2й способ: " + type);

            // 3.
            type = typeof(MyClass);
            Console.WriteLine("3й способ: " + type);

            // Delay.
            Console.ReadKey();
        }
    }
}
