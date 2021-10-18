using System;
using System.Threading;

namespace Race
{
    class CarBody
    {
        private int left;
        private int top;

        public CarBody(int left, int top)
        {
            this.left = left;
            this.top = top;

            // Draw();
        }

        public void Draw()
        {
            Thread th1 = new Thread(DrawWheels);  // Отрисовка колес.
            th1.Start();
            Thread.Sleep(10);
            Thread th2 = new Thread(DrawCarBody); // Отрисовка кузова.            
            th2.Start();
        }

        private void DrawCarBody()
        {
            Console.SetCursorPosition(left, top);
            Console.BackgroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" ");
                }
                top++;
                Console.SetCursorPosition(left, top);
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void DrawWheels()
        {
            Console.BackgroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(left - 1, top + 1);
            Console.Write(" ");
            Console.SetCursorPosition(left - 1, top + 2);
            Console.Write(" ");

            Console.SetCursorPosition(left - 1, top + 7);
            Console.Write(" ");
            Console.SetCursorPosition(left - 1, top + 8);
            Console.Write(" ");

            Console.SetCursorPosition(left + 10, top + 1);
            Console.Write(" ");
            Console.SetCursorPosition(left + 10, top + 2);
            Console.Write(" ");

            Console.SetCursorPosition(left + 10, top + 7);
            Console.Write(" ");
            Console.SetCursorPosition(left + 10, top + 8);
            Console.Write(" ");

            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
