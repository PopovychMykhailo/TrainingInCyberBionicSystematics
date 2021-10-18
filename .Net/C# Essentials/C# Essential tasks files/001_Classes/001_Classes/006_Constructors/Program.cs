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

            // Применяем конструктор по умолчанию.
            Point pointA = new Point();
            Console.WriteLine($"pointA.X = {pointA.X} pointA.Y = {pointA.Y}");

            Console.WriteLine(new string('-', 30));

            // Применяем конструктор с параметрами.
            Point pointB = new Point(100, 200);
            Console.WriteLine($"pointB.X = {pointB.X} pointB.Y = {pointB.Y}");

            // Delay.
            Console.ReadKey();
        }
    }
}
