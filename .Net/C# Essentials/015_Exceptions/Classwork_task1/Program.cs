using System;


namespace Classwork_task1
{

    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте класс Calculator.
        В теле класса создайте четыре метода для арифметических действий: Add – сложение, Sub – вычитание,
        Mul – умножение, Div – деление.
        Метод деления должен делать проверку деления на ноль, если проверка не проходит, сгенерировать
        исключение.
        Пользователь вводит значения, над которыми хочет произвести операцию и выбрать саму операцию.
        При возникновении ошибок должны выбрасываться исключения
    */

    static class Calculator
    {
        public static double Value1 { set; get; }
        public static double Value2 { set; get; }
        public static double Result { get; private set; }
        

        public static double Add() => Result = Value1 + Value2;
        public static double Sub() => Result = Value1 - Value2;
        public static double Mul() => Result = Value1 * Value2;
        public static double Div()
        {
            if (Value2 != 0)
                return Result = Value1 / Value2;
            else
                throw new DivideByZeroException();
        }
    }

    class DivideByZeroException : Exception
    {
        public DivideByZeroException() : base("Devide by zero is progibited!") { }
    }

    class Program
    {
        static void Main()
        {
            string userChoice;

            while (true)
            {
                // Get the values and operator for the calculate
                Console.Write("Arithmetic operation (Add, Sub, Mul, Div): "); userChoice = Console.ReadLine();
                Console.Write("Enter first  value: "); Calculator.Value1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter second value: "); Calculator.Value2 = Convert.ToDouble(Console.ReadLine());

                try
                {
                    // To lower all characters and delete section characters
                    userChoice = userChoice.ToLower().Trim(new char[] { ' ', '.', ',' });

                    switch (userChoice)
                    {
                        case "add":
                            {
                                Calculator.Add();
                                break;
                            }
                        case "sub":
                            {
                                Calculator.Sub();
                                break;
                            }
                        case "mul":
                            {
                                Calculator.Mul();
                                break;
                            }
                        case "div":
                            {
                                Calculator.Div();
                                break;
                            }
                        default:
                            {
                                throw new Exception("Unknown arithmetic operation!");
                            }
                    }
                }
                catch (DivideByZeroException ex)
                {
                    WriteError("Error: can not divide by zero!");
                    WriteError($"Exception message: {ex.Message}");
                }
                catch (Exception ex)
                {
                    WriteError("Error: unknown exception!");
                    WriteError($"Exception message: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"Result: {Calculator.Result}");
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine();
                }
            }
        }

        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
