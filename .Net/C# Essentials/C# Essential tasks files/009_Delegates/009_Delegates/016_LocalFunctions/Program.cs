using System;

namespace _016_LocalFunctions
{
    delegate MyDelegate Functional(MyDelegate delegate1, MyDelegate delegate2);
    delegate string MyDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            string Function1() 
            {
                return "Hello ";
            }

            string Function2()
            {
                return "world!";
            }

            MyDelegate Functional(MyDelegate d1, MyDelegate d2) 
            {
                return () => d1() + d2();
            }

            var resultDelegate = Functional(Function1, Function2);
            var result = resultDelegate();
            Console.WriteLine(result);
        }
    }
}
