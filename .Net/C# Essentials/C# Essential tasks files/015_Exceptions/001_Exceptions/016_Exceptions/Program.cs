using System;

namespace _016_Exceptions
{
    class MyException : Exception
    {
        public int Code { get; }

        public MyException(int code)
        {
            Code = code;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoSomething(100);
            }
            catch (MyException ex) when (ex.Code == 10)
            {
                Console.WriteLine("First catch.");
                Console.WriteLine(ex.Message);
            }
            catch (MyException ex) when (ex.Code == 7)
            {
                Console.WriteLine("Second catch.");
                Console.WriteLine(ex.Message);
            }
            catch (MyException ex) when (ex.Code > 5)
            {
                Console.WriteLine("Third catch.");
                Console.WriteLine(ex.Message);
            }
            catch (MyException ex)
            {
                Console.WriteLine("Fourth catch.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Last catch.");
                Console.WriteLine(ex.Message);
            }
        }

        private static void DoSomething(int number)
        {
            throw new MyException(number);
        }
    }
}
