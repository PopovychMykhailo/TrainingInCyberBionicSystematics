using System;
using System.Collections.Generic;
using MyLibrary;

namespace Homework_task2
{
    /* Technical task
    
        Создайте класс с методом помеченным модификатором доступа public. Докажите, что к данному
        методу можно обратиться не только из текущей сборки, но и из производного класса внешней сборки.
    */

    // Result: I proved that it is possible to inherit from a public class from a library.



    public class DeviredMyDictionary : MyDictionary<int, string>
    {
        // Everything inherits from the base class
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
