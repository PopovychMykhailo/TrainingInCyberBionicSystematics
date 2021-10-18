using System;

// Перечисления.

namespace Enums
{
    // Можно использовать псевдоним для любого целого типа данных C# (byte, sbyte, short, ushort, int,
    // uint, long, ulong)

    // Можно использовать любой системный целый тип данных C# (Byte, SByte, Int16, UInt16, Int32, 
    // UInt32, Int64, UInt64)

    enum EnumType : Int32 
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
            
            // Delay.
            Console.ReadKey();
        }
    }
}
