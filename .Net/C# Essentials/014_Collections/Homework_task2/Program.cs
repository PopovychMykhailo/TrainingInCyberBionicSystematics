using System;
using System.Collections.Generic;

namespace Homework_task2
{
    /* Technical task
      
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте коллекцию MyList<T>. Реализуйте в простейшем приближении возможность использования
        ее экземпляра аналогично экземпляру класса List<T>. Минимально требуемый интерфейс
        взаимодействия с экземпляром, должен включать метод добавления элемента, индексатор для
        получения значения элемента по указанному индексу и свойство только для чтения для получения
        общего количества элементов. Реализуйте возможность перебора элементов коллекции в цикле
        foreach.
    */

    public class MyList<T>
        where T : new()
    {
        T[] array;

        public MyList(int length)
        {
            array = new T[length];

            for (int i = 0; i < length; i++)
                array[i] = new T();
        }

        public void Add(T newElement)
        {
            T[] newArray = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];

            newArray[array.Length] = newElement;

            array = newArray;
        }
        public T this[int index]
        {
            set
            {
                if (index >= 0 && index < array.Length)
                    array[index] = value;
                else
                    Console.WriteLine("Attention: index out of range!");
            }

            get
            {
                if (index >= 0 && index < array.Length)
                    return array[index];
                else
                    throw new Exception("Attention: index out of range!");
            }
        }
        public int Length
        {
            get { return array.Length; }
        }

        public IEnumerable<T> GetEnumerable()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            MyList<int> myList = new(5);

            for (int i = 0; i < myList.Length; i++)
                myList[i] = random.Next(10);

            foreach (var item in myList.GetEnumerable())
            {
                Console.Write($"{item} ");
            }

            Console.Read();
        }
    }
}
