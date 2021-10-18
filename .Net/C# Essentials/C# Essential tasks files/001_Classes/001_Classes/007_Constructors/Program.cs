using System;
using System.Text;

// Конструкторы.

// ВАЖНО: 
// Если вы создали пользовательский конструктор (принимающий аргументы),
// то конструктор по умолчанию, автоматически создаваться НЕ БУДЕТ, его придется создать явно.

namespace Classes
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Применяем конструктор по умолчанию.  
            //Point pointA = new Point();                                              //  Снять 
            //Console.WriteLine($"pointA.X = {pointA.X} pointA.Y = {pointA.Y}");       //  комментарий 

            Console.WriteLine(new string('-', 30));

            // Применяем конструктор с параметрами.
            Point pointB = new Point(100, 200);
            Console.WriteLine($"pointB.X = {pointB.X} pointB.Y = {pointB.Y}");

            // Delay.
            Console.ReadKey();
        }
    }
}
