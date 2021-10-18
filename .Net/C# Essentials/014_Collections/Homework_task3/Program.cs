using System;
using System.Collections.Generic;

namespace Homework_task3
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте коллекцию MyDictionary<TKey,TValue>. Реализуйте в простейшем приближении
        возможность использования ее экземпляра аналогично экземпляру класса Dictionary<TKey,TValue>.
        Минимально требуемый интерфейс взаимодействия с экземпляром, должен включать метод
        добавления элемента, индексатор для получения значения элемента по указанному индексу и свойство
        только для чтения для получения общего количества элементов. Реализуйте возможность перебора
        элементов коллекции в цикле foreach.
    */



    public class MyDictionary<TKey, TValue>
        where TKey : notnull
        where TValue : notnull
    {
        TKey[] arrayKeys;
        TValue[] arrayValues;
        public int Length
        {
            get => arrayKeys.Length;
        }

        public MyDictionary(int length)
        {
            arrayKeys = new TKey[length];
            arrayValues = new TValue[length];

            //for (int i = 0; i < length; i++)
            //{
            //    arrayKeys[i] = new TKey();
            //    arrayValues[i] = new TValue();
            //}
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
        public KeyValuePair<TKey, TValue> this[int index]
        {
            set
            {
                if (index >= 0 && index < arrayValues.Length)
                {
                    arrayKeys[index] = value.Key;
                    arrayValues[index] = value.Value;
                }
                else
                    throw new Exception("Attention: index out of range!");
            }

            get
            {
                if (index >= 0 && index < arrayValues.Length)
                    return new KeyValuePair<TKey, TValue>(arrayKeys[index], arrayValues[index]);
                else
                    throw new Exception("Attention: index out of range!");
            }
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> GetEnumerable()
        {
            for (int i = 0; i < arrayValues.Length; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(arrayKeys[i], arrayValues[i]);
            }
        }
        
        //public IEnumerable<TValue> GetEnumerableValues()
        //{
        //    for (int i = 0; i < arrayValues.Length; i++)
        //    {
        //        yield return arrayValues[i];
        //    }
        //}

        //public IEnumerable<TKey> GetEnumerableKeys()
        //{
        //    for (int i = 0; i < arrayKeys.Length; i++)
        //    {
        //        yield return arrayKeys[i];
        //    }
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, string> myDictionary = new(5);
            myDictionary[0] = new KeyValuePair<int, string>(0, "Zero");
            myDictionary[1] = new KeyValuePair<int, string>(1, "One");
            myDictionary[2] = new KeyValuePair<int, string>(2, "Two");
            myDictionary[3] = new KeyValuePair<int, string>(3, "Three");
            myDictionary[4] = new KeyValuePair<int, string>(4, "Four");

            foreach (var item in myDictionary.GetEnumerable())
            {
                Console.WriteLine($"Key: {item.Key} \t Value: {item.Value}");
            }
        }
    }
}
