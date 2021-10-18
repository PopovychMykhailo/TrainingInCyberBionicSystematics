using System;

namespace Classwork_task1
{
    /* Technical task
    
        Создайте класс Calculator, методы которого принимают аргументы и возвращают значения типа dynamic.
    */



    static class Calculator
    {
        public static dynamic Add(dynamic value1, dynamic value2)
        {
            return value1 + value2;
        }
        public static dynamic Sub(dynamic value1, dynamic value2)
        {
            return value1 - value2;
        }
        public static dynamic Mul(dynamic value1, dynamic value2)
        {
            return value1 * value2;
        }
        public static dynamic Div(dynamic value1, dynamic value2)
        {
            if (value2 != 0)
                return value1 / value2;
            else
                throw new Exception("Divide by zero is prohibited!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            dynamic value1 = 50;
            dynamic value2 = 10;

            try
            {
                Console.WriteLine($"Result 1: {Calculator.Add(value1, value2)}");
                Console.WriteLine($"Result 2: {Calculator.Sub(value1, value2)}");
                Console.WriteLine($"Result 3: {Calculator.Mul(value1, value2)}");
                Console.WriteLine($"Result 4: {Calculator.Div(value1, value2)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception!");
                Console.WriteLine($"Error message: {ex.Message}");
            }
        }
    }
}
