using System;
using System.IO;
using System.Text;

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
            Console.OutputEncoding = Encoding.Unicode;
            try
            {
                //throw new Exception();
                throw new UserException();
            }
            catch (UserException userException)
            {
                Console.WriteLine("Обработка исключения.");
                userException.Method();

                try
                {
                    FileStream fs = File.Open(@"C:\NonExistentFile.log", FileMode.Open);                    
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
