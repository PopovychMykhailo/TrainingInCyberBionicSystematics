using System;
using System.Collections.Generic;
using MyLibrary;


namespace Homework_task1
{
    /* Technical task
    
        Используя пример выполненного домашнего задания 3 из 14 урока, реализуйте возможность
        подключения вашего пространства имен и работы с MyDictionary<TKey,TValue> аналогично
        экземпляру класса Dictionary<TKey,TValue>.
    */


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
