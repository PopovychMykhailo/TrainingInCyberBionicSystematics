using System;

namespace Collection
{
    class Program
    {
        static void Main()
        {
            var test = new SimpleList {"one", "two", "three", "four", "five", "six", "seven", "eight"};

            test.PrintContents();

            Console.WriteLine("Удаление элементов из списка");
            test.Remove("six");
            test.Remove("eight");
            test.PrintContents();

            Console.WriteLine("Добавить элемент в конец списка");
            test.Add("nine");
            test.PrintContents();
           
            Console.WriteLine("Вставить элемент в середине списка");
            test.Insert(4, "number");
            test.PrintContents();

            Console.WriteLine("Проверка конкретных элементов в списке:");
            Console.WriteLine("Список содержит \"three\": {0}", test.Contains("three"));
            Console.WriteLine("Список содержит \"ten\"  : {0}", test.Contains("ten"));

            Console.WriteLine("\nПеречисление всех элементов в коллекции:");
            foreach (string s in test)
            {
                Console.WriteLine(s);
            }
            // Delay.
            Console.ReadKey();
        }
    }
}
