using System;
using System.Text;

// Перечисления. Форматированный вывод элементов перечисления

namespace Enums
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            EnumType digit = EnumType.Ten;

            Console.WriteLine("Число {0}", digit.ToString());

            // Enum.Format() - Позволяет производить более точное форматирование за счет указания флага, 
            // а также получать имена элементов перечисления по их числовым значениям

            // Вывод в 16-ричном формате. Флаг "x" - hex (16-ричный формат) 
            Console.WriteLine("Hex значение {0}", Enum.Format(typeof(EnumType), EnumType.Ten, "x"));

            // Вывод в 10-тичном формате. Флаг "D" - dec (10-тичный формат)
            Console.WriteLine("Dec значение {0}", Enum.Format(typeof(EnumType), digit, "D"));

            // Вывод в строковом формате. Флаг "G" - str (Строковой формат)
            Console.WriteLine("Str значение {0}", Enum.Format(typeof(EnumType), 10, "G"));

            // Delay.
            Console.ReadKey();
        }
    }
}
