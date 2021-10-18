using System;

// Массивы (двумерный массив).

namespace Arrays
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();

            int[,] array = new int[3, 3];


            // Заполнение массива случайными значениями.
            for (int i = 0; i < 3; i++)
            { 
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = random.Next(0, 10);
                }
            }


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0} ", array[i, j]);
                }
                Console.Write("\n");
            }
           
            
            // Delay.
            Console.ReadKey();
        }
    }
}
