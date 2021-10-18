using System;
using System.Text;

// Поиск элемента перечисления по имени константы.

namespace Enums
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Находим элемент перечисления по имени константы.
            object element = Enum.Parse(typeof(EnumType), "Infinite");
            EnumType number = (EnumType)element;

            Console.WriteLine("Значение константы {0}: {1}", number, (byte)number);

            // Enum.IsDefined() - Позволяет определить, является ли символьная строка элементом перечисления? 
            bool flag = Enum.IsDefined(typeof(EnumType), "one");

            if (flag == true)
                Console.WriteLine("Да, перечисление содержит элемент с таким именем.");
            else
                Console.WriteLine("Нет, перечисление не содержит элемент с таким именем.");

            // Delay.
            Console.ReadKey();
        }
    }
}
