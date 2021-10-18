using System;

namespace Classwork_task1
{
    /* Technical task
        
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте анонимный метод, который принимает в качестве параметров три целочисленных аргумента и
        возвращает среднее арифметическое этих аргументов.
    */

    class Program
    {
        public delegate float DelegateForArithmeticMean(int a, int b, int c);

        static void Main(string[] args)
        {
            DelegateForArithmeticMean arithmeticMean = (a, b, c) => { return (float)(a + b + c) / 3; };

            Console.WriteLine($"Values input 3, 9, 5. Arithmetic mean {arithmeticMean(3, 9, 5)}");

        }
    }
}
