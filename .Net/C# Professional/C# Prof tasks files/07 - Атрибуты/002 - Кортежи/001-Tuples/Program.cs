using System;
using System.Text;

namespace _001_Tuples
{
    /*
      Кортежи (tuples) , доступны в C# 7.0 и более поздних версиях. 
      Кортежи предоставляют краткий синтаксис для группирования нескольких элементов данных в упрощенную структуру данных.
      Типы кортежей являются структурными типами (value type), а элементы кортежа — публичными полями.
     */

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Создание кортежа

            (int, string) t1 = (3, "Hello World!");

            Console.WriteLine($"Кортеж со значениями {t1.Item1} и {t1.Item2}.");
            Console.WriteLine($"ToString для кортежа: {t1}.");
            Console.WriteLine($"Тип кортежа: {t1.GetType()}.");

            Console.WriteLine(new string('-', Console.WindowWidth));
            
            // Именованый кортеж

            var person = (Name: "Jim", Age: 27);
            Console.WriteLine($"Кортеж со значениями {person.Name} и {person.Age}.");

            (string Name, int Age) anotherPerson = ("Michael", 32);
            Console.WriteLine($"Кортеж со значениями {anotherPerson.Name} и {anotherPerson.Age}.");

            Console.WriteLine(new string('-', Console.WindowWidth));

        }
    }
}
