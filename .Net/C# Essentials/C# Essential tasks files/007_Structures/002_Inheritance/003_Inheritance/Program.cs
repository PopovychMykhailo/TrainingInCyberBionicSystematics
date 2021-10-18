using System;

// Структуры. Наследование.

// От структур нельзя наследоваться.

namespace Inheritance
{
    struct MyStruct 
    {
        // Структуры не могут иметь protected членов.
        //protected int field;
    }

    class MyClass //: MyStruct
    {
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("От структур нельзя наследоваться.");    
                   
            // Delay.
            Console.ReadKey();
        }
    }
}
