using System;
using System.Collections;

// Динамические типы данных. (Анонимные типы)

namespace Dynamic
{
    class UserCollection
    {
        public static IEnumerable Generator()
        {
            yield return new { Key = 0, Value = "Zero" };
            yield return new { Key = 1, Value = "One" };
            yield return new { Key = 2, Value = "Two" };
        }
    }

    class Program
    {
        static void Main()
        {
            foreach (dynamic item in UserCollection.Generator())
            {
                Console.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
