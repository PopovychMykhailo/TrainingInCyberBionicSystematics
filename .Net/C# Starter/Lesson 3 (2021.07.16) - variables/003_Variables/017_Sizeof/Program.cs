using System;
using System.Text;

// Оператор sizeof - позволяет получить размер значения в байтах для указанного типа.
// Оператор sizeof можно применять только к типам: 
// byte, sbyte, short, ushort, int, uint, long, ulong, float, double, decimal, char, bool.
// Возвращаемые оператором sizeof значения имеют тип int.

namespace Sizeof
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            int doubleSize = sizeof(double);
            Console.WriteLine($"Размер типа double: {doubleSize} байт.");

            Console.WriteLine($"Размер типа int: {sizeof(int)} байт.");
            Console.WriteLine($"Размер типа bool: {sizeof(bool)} байт.");
            Console.WriteLine($"Размер типа long: {sizeof(long)} байт.");
            Console.WriteLine($"Размер типа short: {sizeof(short)} байт.");

            // Delay.
            Console.ReadKey();
        }
    }
}
