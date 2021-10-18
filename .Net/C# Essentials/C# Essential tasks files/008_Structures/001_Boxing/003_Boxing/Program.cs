using System;
using System.Net;

// Упаковка и распаковка

namespace Boxing
{
    struct MyStruct //: ValueType
    {
        public void Method()
        {
            Console.WriteLine("Method");
        }
    }

    class Program
    {
        static void Main()
        {
            MyStruct my = new MyStruct();

            // Упаковка (Boxing).
            ValueType boxed = my;
            
            // Распаковка объекта (UnBoxing).
            MyStruct unBoxed = (MyStruct)boxed;

            // Delay.
            Console.ReadKey();
        }
    }
}
