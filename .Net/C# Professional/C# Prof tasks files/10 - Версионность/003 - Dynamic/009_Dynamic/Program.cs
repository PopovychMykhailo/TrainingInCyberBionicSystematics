using System;

// перегрузка

namespace Dynamic
{
    class MyClass
    {
        static public void Method(double dbl, dynamic dyn)
        {
            Console.WriteLine("void Method( double dbl, dynamic dyn )");
        }

        static public void Method(int i, string str)
        {
            Console.WriteLine("void Method( int i, string str )");
        }

        static public void Method(double i, string str)
        {
            Console.WriteLine("void Method( double i, string str )");
        }
    }

    class Program
    {
        static void Main()
        {
            dynamic d = "I'm dynamic";
            dynamic d1 = new object();

            MyClass.Method(3.1415, d); // перегрузка времени компиляции? 
            MyClass.Method(42, d);     // перегрузка времени выполнения 
            MyClass.Method(42, d1);    // перегрузка времени выполнения 

            //А это не компилируется! 
            // MyClass.Method("Hello!", d);

            // Delay.
            Console.ReadKey();
        }
    }
}
