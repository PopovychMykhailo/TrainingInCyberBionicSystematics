using System;
using System.Text;

// Логические операции.

// Например: 
// Чтобы проверить условие A < x < B, нельзя записать его в условном операторе непосредственно, 
// так как каждая операция отношения должна иметь два операнда. 
// Правильный способ записи: if ( A < x && x < B).

namespace Logic
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            int A = 0, B = 5, x = 3;


            if (A < x && x < B) // A < x < B
            {
                Console.WriteLine($"Число {x} находится в диапазоне чисел от {A}  до {B}.");
            }
            else
            {
                Console.WriteLine($"Число {x} не попадает в диапазон чисел от {A}  до {B}.");
            }


            // Delay.
            Console.ReadKey();
        }
    }
}
