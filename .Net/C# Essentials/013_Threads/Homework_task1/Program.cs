using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework_task1
{

    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте программу, которая будет выводить на экран цепочки падающих символов. Длина каждой
        цепочки задается случайно. Первый символ цепочки – белый, второй символ – светло-зеленый,
        остальные символы темно-зеленые. Во время падения цепочки, на каждом шаге, все символы меняют
        свое значение. Дойдя до конца, цепочка исчезает и сверху формируется новая цепочка. Смотрите ниже
        снимок экрана, представленный как образец
    */

    /* Comment
    *   I did 2 tasks in this task - the program can show several chains in one column.
    *   You can uncomment lines 55 and 56 to check this
    */


    // Creates all chains and launches them in threads
    class Program
    {
        // Range of values to fill with random numbers
        const int minSizeChain = 3;
        const int maxSizeChain = 10;
        const int minValueForRandom = 48;
        const int maxValueForRandom = 126;

        static Program()
        {
            // Set custom size for the console
            const int consoleWidth = 120;
            const int consoleHeight = 40;

            Console.SetWindowSize(consoleWidth, consoleHeight);
            Console.BufferHeight = consoleHeight;
            Console.BufferWidth = consoleWidth;
        }

        static void Main(string[] args)
        {
            ParameterizedThreadStart workerChain = new ParameterizedThreadStart(WorkerChain);

            //new Thread(workerChain).Start(30);
            //new Thread(workerChain).Start(30);

            // Create threads to the end of the console
            for (int i = 0; i < Printer.ConsoleWidth; i++)
            {
                // Show through one
                if (i % 2 == 0)
                {
                    new Thread(workerChain).Start(i);
                    new Thread(workerChain).Start(i);     // Add another thread
                    //new Thread(workerChain).Start(i);     // Add another thread
                }
            }

        }

        // Create and cycle display one chain in the console
        static public void WorkerChain(object sequenceNumber)
        {
            Chain chain = CreateChain((int)sequenceNumber);

            while (true)
            {
                chain.Show();
                chain.NextRow();

                Thread.Sleep(chain.TimeUpdateMs);
            }
        }

        // Create a chain instance (fill with random values)
        static Chain CreateChain(int row)
        {
            Random random = new();
            Chain chain = new(random.Next(minSizeChain, maxSizeChain), row);

            // Fill the array with characters
            for (int i = 0; i < chain.Length; i++)
            {
                chain[i].Symbol = (char)random.Next(minValueForRandom, maxValueForRandom);
                chain[i].Color = ConsoleColor.DarkGreen;
            }

            chain[0].Color = ConsoleColor.White;    // The head of the chain need to be white
            chain[1].Color = ConsoleColor.Green;    // The second characters of the chain need to be green

            return chain;
        }
    }
}
