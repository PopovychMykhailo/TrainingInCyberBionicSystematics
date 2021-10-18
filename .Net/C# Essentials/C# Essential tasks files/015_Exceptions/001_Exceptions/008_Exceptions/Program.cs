using System;
using System.IO;

// Обработка исключений.

namespace Exceptions
{
    // Для создания пользовательского исключения, требуется наследование от System.Exception.
    class UserException : Exception
    {        
        public void Method()
        {
            Console.WriteLine("Мое Исключение!");
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                throw new UserException();
            }
            catch (UserException userException)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Обработка исключения 1:");
                userException.Method();

                try
                {
                    throw userException;
                }
                catch (UserException exception)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Обработка исключения 2:");
                    exception.Method();
                }
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine("Press any key...");

            // Delay.
            Console.ReadKey();
        }
    }
}
