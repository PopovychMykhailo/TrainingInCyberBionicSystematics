using System;

namespace Homework_task2
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте статический класс с методом void Print (string stroka, int color), который выводит на
        экран строку заданным цветом. Используя перечисление, создайте набор цветов, доступных
        пользователю. Ввод строки и выбор цвета предоставьте пользователю.
    */

    static class ColorTextPrinter
    {
        public enum TextColor : int
        {
            Red,
            Green,
            Blue,
            White
        }

        static public void Print(string stroka, int color)
        {
            switch (color)
            {
                case (int)TextColor.Red:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    }

                case (int)TextColor.Green:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    }
                case (int)TextColor.Blue:
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    }
                case (int)TextColor.White:
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
            }

            Console.WriteLine(stroka);
            Console.ResetColor();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ColorTextPrinter.Print("Hello world", (int)ColorTextPrinter.TextColor.Red);
            Console.WriteLine("-----------");
            ColorTextPrinter.Print("Hello world", (int)ColorTextPrinter.TextColor.Green);
            Console.WriteLine("-----------");
            ColorTextPrinter.Print("Hello world", (int)ColorTextPrinter.TextColor.Blue);
            Console.WriteLine("-----------");
            ColorTextPrinter.Print("Hello world", (int)ColorTextPrinter.TextColor.White);
            Console.WriteLine("-----------");
        }
    }
}
