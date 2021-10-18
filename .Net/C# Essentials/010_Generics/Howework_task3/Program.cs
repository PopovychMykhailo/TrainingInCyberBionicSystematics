using System;

namespace Homework_task3
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте класс MyDictionary<TKey,TValue>. Реализуйте в простейшем приближении возможность
        использования его экземпляра аналогично экземпляру класса Dictionary (Урок 6 пример 5).
        Минимально требуемый интерфейс взаимодействия с экземпляром, должен включать метод
        добавления пар элементов, индексатор для получения значения элемента по указанному индексу и
        свойство только для чтения для получения общего количества пар элементов
    */

    public class MyDictionary<TKey, TValue>
        where TKey : new()
        where TValue : new()
    {
        TKey[] arrayKeys;
        TValue[] arrayValues;

        public MyDictionary(int length)
        {
            arrayKeys = new TKey[length];
            arrayValues = new TValue[length];

            for (int i = 0; i < length; i++)
            {
                arrayKeys[i] = new TKey();
                arrayValues[i] = new TValue();
            }
        }
        public MyDictionary()
        {
            arrayKeys = Array.Empty<TKey>();
            arrayValues = Array.Empty<TValue>();
        }

        public void Add(TKey key, TValue value)
        {
            TKey[] newArrayKeys = new TKey[arrayKeys.Length + 1];
            TValue[] newArrayValues = new TValue[arrayValues.Length + 1];

            for (int i = 0; i < arrayKeys.Length; i++)
            {
                newArrayKeys[i] = arrayKeys[i];
                newArrayValues[i] = arrayValues[i];
            }

            newArrayKeys[arrayKeys.Length] = key;
            newArrayValues[arrayKeys.Length] = value;

            arrayKeys = newArrayKeys;
            arrayValues = newArrayValues;
        }

        public TValue this[int index]
        {
            get
            {
                if (index >= 0 && index < arrayValues.Length)
                    return arrayValues[index];
                else
                    throw new Exception("Attention: index out of range!");
            }
        }

        public int Length
        {
            get
            {
                return arrayKeys.Length;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, int> myDictionary = new();
            myDictionary.Add(1, 2);
            myDictionary.Add(2, 4);
            myDictionary.Add(3, 6);
            myDictionary.Add(4, 8);

            for (int i = 0; i < myDictionary.Length; i++)
                Console.WriteLine($"myDictionary[{i}]: {myDictionary[i]}");
        }
    }
}
