using System;

// Перечисления.

// Перечисление - это набор именованных констант, которые хранят числовые значения.
// Перечисление определяет именованные константы, каждой из которых соответствует числовое значение.
// Все перечисления в C# происходят от единого Базового класса System.Enum

namespace Enums
{
    // При компиляции - компилятор подставляет вместо имен,
    // установленные им в соответствие числовые значения. [имя] = [число]
    // По умолчанию типом данных констант перечисления будет int.
    // Можно использовать любой целый тип данных C# (byte, sbyte, short, ushort, int, uint, long, ulong)

    enum EnumType : byte // Явно указываем использовать тип byte.
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine(EnumType.One);
            Console.WriteLine((byte)EnumType.One);

            EnumType digit = EnumType.Zero;            
            Console.WriteLine(digit);
            Console.WriteLine((byte)digit);
            
            // Delay.
            Console.ReadKey();
        }
    }
}
