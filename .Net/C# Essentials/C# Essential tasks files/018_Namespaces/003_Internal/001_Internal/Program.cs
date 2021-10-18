using System;
using LibraryA;

namespace Internal
{
    class Program
    {
        static void Main()
        {
            // 1.

            MyPublicClass instanceA = new MyPublicClass();
            instanceA.PublicMethod();
            //instanceA.InternalMethod();             // Недоступен.
            //instanceA.InternalProtectedMethod();    // Недоступен.

            //MyInternalClass instance = new MyInternalClass();   // Недоступен.


            Console.WriteLine(new string('-', 20));


            // 2.

            MyClass instance = new MyClass();
            instance.PublicMethod();
            instance.MyMethod();     // Вызов InternalProtectedMethod().
            //instance.InternalMethod();     // Недоступен.
            

            // Delay.
            Console.ReadKey();
        }
    }
}
