using System;
using System.Text;

// Обработка внутренних исключений.

namespace Exceptions
{
    public class ClassWithException
    {
        public void ThrowInner()
        {
            throw new Exception("Это внутреннее исключение!");
        }

        public void CatchInner()
        {
            try
            {
                this.ThrowInner();
            }
            catch (Exception e)
            {
                throw new Exception("Это внешнее исключение!", e);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            ClassWithException instance = new ClassWithException();
            //instance.CatchInner(); // Попробовать вызвать.
            try
            {
                instance.CatchInner();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception caught: {0}", exception.Message);
                Console.WriteLine("Inner Exception : {0}", exception.InnerException.Message);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
