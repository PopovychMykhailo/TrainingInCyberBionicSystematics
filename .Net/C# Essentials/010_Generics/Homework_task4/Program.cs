using System;

namespace Homework_task4
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте расширяющий метод: public static T[] GetArray<T>(this MyList<T> list)
        Примените расширяющий метод к экземпляру типа MyList<T>, разработанному в домашнем задании 2
        для данного урока. Выведите на экран значения элементов массива, который вернул расширяющий
        метод GetArray().
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
    }

    static class WorkingWithArray
    {
        public static T[] GetArray<T>(this MyList<T> list)  // Here is the error CS0310, and I don't know how to fix it
        {
            T[] array = new T[list.Length];

            for (int i = 0; i < list.Length; i++)
                array[i] = list[i];

            return array;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            MyList<int> myList = new(5);

            for (int i = 0; i < myList.Length; i++)
            {
                myList[i] = random.Next(10);
                Console.WriteLine($"myList[{i}]: {myList[i]}");
            }

            int[] array = WorkingWithArray.GetArray<int>(myList);

            for (int i = 0; i < array.Length; i++)
                Console.WriteLine($"array[{i}]: {array[i]}");
        }
    }
}
