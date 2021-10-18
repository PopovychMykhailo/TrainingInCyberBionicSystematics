using System;

// Ковариантность структурных типов.

namespace Covariant
{
    class Program
    {
        static void Main()
        {
            uint[] array = new uint[3] { (uint)int.MaxValue + 3, 1, 3 };

            Console.WriteLine($"array  {array is uint[]} {array is int[]}");

            object @object = array;

            Console.WriteLine($"object {@object is uint[]} {@object is int[]}");


            var intArray = (int[])@object;
            var uintArray = (uint[])@object;

            Console.WriteLine("ints: ");
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
            }

            Console.WriteLine("uints: ");
            for (int i = 0; i < uintArray.Length; i++)
            {
                Console.WriteLine(uintArray[i]);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
