using System;
using System.Collections;

namespace HashtableDemo4
{
    public class Fish
    {
        public string name;

        public Fish(string name)
        {
            this.name = name;
        }
    }

    class Program
    {
        static void Main()
        {
            var duplicates = new Hashtable();

            var key1 = new Fish("Herring");
            var key2 = new Fish("Herring");
            
            
            duplicates[key1] = "Hello";
            duplicates[key2] = "Hello2";
            
            // 2 объекта так как они имеют разные хеш-коды.
            Console.WriteLine(duplicates.Count);

            // Delay.
            Console.ReadKey();
        }
    }
}
