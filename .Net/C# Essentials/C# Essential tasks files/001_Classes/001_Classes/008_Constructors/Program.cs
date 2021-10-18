using System;
using System.Text;

// Конструкторы.

namespace Classes
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            Point point = new Point("A");
            Console.WriteLine($"{point.Name}.X = {point.X}, {point.Name}.Y = {point.Y}");

            // Delay.
            Console.ReadKey();
        }
    }
}
