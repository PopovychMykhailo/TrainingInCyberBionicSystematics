using System;

namespace NullableTypes
{
    class Program
    {
        static void Main()
        {
            // a - содержит неизвестное значение.
            int? a = null;
            int? b = a + 4; // b = null
            int? c = a * 5; // c = null
            
            Console.WriteLine("->{0}<-", a); 

            // Delay.
            Console.ReadKey();
        }
    }
}
