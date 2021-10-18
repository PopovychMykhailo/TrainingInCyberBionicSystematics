using System;
using System.Text;

// Логический Сдвиг  (shift).

namespace Logic
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            byte operand = 0x81;              // 1000 0001    
            Console.WriteLine($"Число до сдвига: {operand:X}");

            // Логический сдвиг числа влево.

            operand = (byte)(operand << 2);   // 0000 0100
            Console.WriteLine($"Число после сдвига влево: {operand:X}");

            // Логический сдвиг числа вправо.

            operand = (byte)(operand >> 1);   // 0000 0010

            Console.WriteLine($"Число после сдвига вправо: {operand:X}");

            // Delay.
            Console.ReadKey();
        }
    }
}
