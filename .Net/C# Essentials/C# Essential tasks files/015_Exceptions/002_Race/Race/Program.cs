using System;
using System.Text;

namespace Race
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Car";

            // Задается размер окна.
            Console.SetWindowSize(100, 50);

            // Задается видимость курсора.
            Console.CursorVisible = true;

            Game game = new Game();
            game.Run();

            // Delay.
            Console.ReadKey();
        }
    }
}
