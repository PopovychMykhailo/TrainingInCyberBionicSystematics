using System;

// Индексаторы.

namespace Indexers
{
    class MyClass
    {
        private int[] array = new int[5];

        // Индексатор. 
        public int this[int index]
        {
            get    // Аксессор.
            {
                return array[index];
            }
            set    // Мутатор.
            {
                array[index] = value;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();

            my[0] = 1;
            my[1] = 2;
            my[2] = 3;
            my[3] = 4;
            my[4] = 5;

            Console.WriteLine(my[0]);
            Console.WriteLine(my[1]);
            Console.WriteLine(my[2]);
            Console.WriteLine(my[3]);
            Console.WriteLine(my[4]);

            // Delay.
            Console.ReadKey();
        }
    }
}
