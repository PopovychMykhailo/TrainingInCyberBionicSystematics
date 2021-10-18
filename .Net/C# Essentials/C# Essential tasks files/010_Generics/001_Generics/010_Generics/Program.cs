using System;

// Контрвариантность обобщений.
// Контрвариантность обобщений в C# 4.0 ограничена делегатами.

namespace Generics
{
    class Animal { }
    class Cat : Animal { }

    class Program
    {
        delegate void MyDelegate<in T>(T a);  // in - Для аргумента.

        public static void CatUser(Animal animal)
        {
            Console.WriteLine(animal.GetType().Name);
        }

        static void Main()
        {

            MyDelegate<Animal> delegateAnimal = new MyDelegate<Animal>(CatUser);
            MyDelegate<Cat> delegateCat = delegateAnimal;    // От базового к производному.

            delegateAnimal(new Animal());
            delegateCat(new Cat());

            //delegateCat(new Animal()); // Невозможно.

            // Delay.
            Console.ReadKey();
        }
    }
}
