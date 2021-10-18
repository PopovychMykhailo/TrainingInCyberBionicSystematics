using System;

// dynamic и приведение.

namespace Dynamic
{
    class SomeClass
    {
    }

    class Program
    {
        static void Main()
        {
            // К динамику можно привести все типы.
            dynamic d1 = 42;				// неявное упаковывающие преобразование
            dynamic d2 = new SomeClass();	// неявное преобразование ссылки
            dynamic d3 = d2;				// неявное преобразование идентичности
            dynamic d4 = new object();		// неявное преобразование ссылки

            // Чуть сложнее тут:
            dynamic obj = new SomeClass();
            var someClass = (SomeClass)obj;

            // Что произойдет?
         //   string str = (String)obj;
            SomeClass someClass1 = obj;

            // Delay.
            Console.ReadKey();
        }
    }
}
