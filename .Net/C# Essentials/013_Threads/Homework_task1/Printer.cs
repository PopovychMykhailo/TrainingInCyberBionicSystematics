using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_task1
{
    // Print a symbol in the console
    static class Printer
    {
        // Object to block threads
        static object blockTread = new();

        public static int ConsoleHeight
        {
            get => Console.BufferHeight;
        }
        public static int ConsoleWidth
        {
            get => Console.BufferWidth;
        }

        // Write the characters of the specified color in the console by coordinates
        public static void WriteAt(char symbol, ConsoleColor color, int x, int y)
        {
            try
            {
                if (x < ConsoleWidth && y < ConsoleHeight)
                {
                    try
                    {
                        Monitor.Enter(blockTread);
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = color;
                        Console.Write(symbol);
                        //Console.ResetColor();
                        Console.SetCursorPosition(0, 0);
                    }
                    finally
                    {
                        Monitor.Exit(blockTread);
                    }
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    }
}
