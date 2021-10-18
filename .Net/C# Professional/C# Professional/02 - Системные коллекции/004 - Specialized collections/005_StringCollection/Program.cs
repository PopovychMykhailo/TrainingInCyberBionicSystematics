using System;
using System.Collections.Specialized;

namespace StringCollectionDemo
{
    class Program
    {
        static void Main()
        {
            var coll = new StringCollection {"First", "Second", "Third", "Fourth", "fourth"};

            //coll.Add(50);      //<--      Ошибка компиляции - это не строка.

            string theString = coll[3];
            // Теперь приведение типов не требуется
            // string theString = (string) coll[3];

            foreach (string  str in coll)
            {
                Console.WriteLine(str);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
