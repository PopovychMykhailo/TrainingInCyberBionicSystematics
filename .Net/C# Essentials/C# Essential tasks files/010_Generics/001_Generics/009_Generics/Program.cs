using System;

// Ковариантность обобщений.
// Ковариантность обобщений в C# 4.0 ограничена интерфейсами и делегатами.

namespace Generics
{
    class Animal { }
    class Cat : Animal { }

    class Program
    {
        delegate T MyDelegate<out T>();   // out - Для возвращаемого значения.

        public static Cat CatCreator()
        {
            return new Cat();
        }

        static void Main()
        {
            MyDelegate<Cat> delegateCat = new MyDelegate<Cat>(CatCreator);
            MyDelegate<Animal> delegateAnimal = delegateCat;    // От производного к базовому.                      

            Animal animal = delegateAnimal.Invoke();

            Console.WriteLine(animal.GetType().Name);

            // Delay.
            Console.ReadKey();
        }
    }
}
