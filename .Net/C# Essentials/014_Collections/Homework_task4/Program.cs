using System;
using System.Collections.Generic;
using System.Collections;

namespace Homework_task4
{

    /* Techinal task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте расширяющий метод:
        public static T[] GetArray<T>(this IEnumerable<T> list){…}
        Примените расширяющий метод к экземпляру типа MyList<T>, разработанному в домашнем задании 2
        для данного урока. Выведите на экран значения элементов массива, который вернул расширяющий
        метод GetArray().
    */

    public class MyList<T> : IEnumerable<T>
    {
        T[] array;

        public MyList(int length)
        {
            array = new T[length];
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

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class MyClass
    {
        public static T[] GetArray<T>(this IEnumerable<T> list)
        {
            T[] array;
            int listCount = 0;

            // Find out the number of items in the list
            foreach (var item in list)
                ++listCount;

            // Create an array of the desired size
            array = new T[listCount];

            // Copy the value from the list to the array
            int i = 0;
            foreach (var item in list)
                array[i++] = item;

            return array;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();

            MyList<int> list1 = new(5);
            MyList<int> list2 = new(5);
            MyList<int> list3 = new(5);
            int[] array1;
            int[] array2;
            int[] array3;

            // Fill in the lists with random values
            for (int i = 0; i < list1.Length; i++)
            {
                list1[i] = random.Next(10);
                list2[i] = random.Next(10);
                list3[i] = random.Next(10);
            }

            array1 = MyClass.GetArray(list1);
            array2 = list2.GetArray();
            array3 = list3.GetArray();

            #region Shows the arrays in the console

            for (int i = 0; i < array1.Length; i++)
                Console.Write($"{array1[i]} ");
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));

            for (int i = 0; i < array2.Length; i++)
                Console.Write($"{array2[i]} ");
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));

            for (int i = 0; i < array3.Length; i++)
                Console.Write($"{array3[i]} ");
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));
            #endregion  
        }
    }
}










