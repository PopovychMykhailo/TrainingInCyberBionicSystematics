using System;

namespace Homework_task4
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте класс ArrayList. Реализуйте в простейшем приближении возможность использования его
        экземпляра аналогично экземпляру класса ArrayList из пространства имен System.Collections.
    */

    public class ArrayList<T>
    {
        T[] array;


        public ArrayList()
        {
            array = Array.Empty<T>();
        }

        public ArrayList(int length)
        {
            array = new T[length];
        }

        public void Add(T newObject)
        {
            T[] newArray = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];

            newArray[array.Length] = newObject;

            array = newArray;
        }

        public T this[int index]
        {
            set
            {
                if (index >= 0 && index < array.Length)
                    array[index] = value;
                else
                    throw new Exception($"Attention: the index out of range the {this.ToString()}!");
            }

            get
            {
                if (index >= 0 && index < array.Length)
                    return (T)array[index];
                else
                    throw new Exception($"Attention: the index out of range the {this.ToString()}!");
            }
        }

        public int Length
        {
            get => array.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> arrayList = new(2);
            arrayList[0] = 1;
            arrayList[1] = 2;
            arrayList.Add(3);
            arrayList.Add(4);

            for (int i = 0; i < arrayList.Length; i++)
                Console.WriteLine($"arrayList[{i}]: {arrayList[i]}");

        }
    }
}
