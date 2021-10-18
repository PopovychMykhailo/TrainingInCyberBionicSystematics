using System;

namespace Homework_task2
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте четыре лямбда оператора для выполнения арифметических действий: (Add – сложение, Sub –
        вычитание, Mul – умножение, Div – деление). Каждый лямбда оператор должен принимать два
        аргумента и возвращать результат вычисления. Лямбда оператор деления должен делать проверку
        деления на ноль.
        Написать программу, которая будет выполнять арифметические действия, указанные пользователем.
    */

    public delegate int DelegateForReturnInt(int number1, int number2);
    public delegate float DelegateForReturnFloat(int number1, int number2);

    public enum MathOperations : int
    {
        Add = 1,
        Sub = 2,
        Mul = 3,
        Div = 4
    }

    class Program
    {
        static void Main(string[] args)
        {
            DelegateForReturnInt delegateAdd = (int number1, int number2) => { return number1 + number2; };
            DelegateForReturnInt delegateSub = (int number1, int number2) => { return number1 - number2; };
            DelegateForReturnInt delegateMul = (int number1, int number2) => { return number1 * number2; };
            DelegateForReturnFloat delegateDiv = (int number1, int number2) =>
            {
                if (number2 != 0)
                    return number1 / number2;
                else
                    return 0;
            };

            // User variables
            int userChoice;
            int userValue1;
            int userValue2;
            float mathResult;

            Console.WriteLine("Select operation: ");
            Console.WriteLine($"Add – {(int)MathOperations.Add}, Sub – {(int)MathOperations.Sub}, Mul – {(int)MathOperations.Mul}, Div – {(int)MathOperations.Div}");
            Console.WriteLine();

            // Cyclic check of user choice (does is it exist in enum)
            do
            {
                Console.Write("Your choice: ");
                userChoice = Convert.ToInt32(Console.ReadLine());

                if (Enum.IsDefined(typeof(MathOperations), userChoice))
                    break;
                else
                    ColorPrinter("You wrote unknouwn math operation, please enter again.", ConsoleColor.Red);

            } while (true);
            Console.WriteLine();

            Console.Write("Enter first value:  ");   userValue1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second value: ");   userValue2 = Convert.ToInt32(Console.ReadLine());

            // Complete a math operation, according to the user's choice
            switch (userChoice)
            {
                case (int)MathOperations.Add:
                    {
                        mathResult = delegateAdd(userValue1, userValue2);
                        break;
                    }
                case (int)MathOperations.Sub:
                    {
                        mathResult = delegateSub(userValue1, userValue2);
                        break;
                    }
                case (int)MathOperations.Mul:
                    {
                        mathResult = delegateMul(userValue1, userValue2);
                        break;
                    }
                case (int)MathOperations.Div:
                    {
                        if (userValue2 == 0)
                        {
                            ColorPrinter("The second value cannot be 0!", ConsoleColor.Red);
                            mathResult = 0;
                            break;
                        }


                        mathResult = delegateDiv(userValue1, userValue2);
                        break;
                    }

                default:
                    {
                        mathResult = 0;
                        ColorPrinter("The choice of math operation is unknown!", ConsoleColor.Yellow);

                        break;
                    }
            }

            Console.WriteLine();
            ColorPrinter($"Result: {mathResult}", ConsoleColor.Green);
        }

        static public void ColorPrinter(string text, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
