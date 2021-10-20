using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;

namespace Homework_task4
{
    /* Technical task
    
        Создайте коллекцию типа OrderedDictionary и реализуйте в ней возможность сравнения значений.
    */


    // Comment: 
    // I didn't quite understand the task, so I did it.


    public class MyComparer : IEqualityComparer
    {
        bool IEqualityComparer.Equals(object x, object y)
        {
            return x.ToString().Equals(y);
        }

        int IEqualityComparer.GetHashCode(object obj)
        {
            return obj.ToString().GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderedDictionary array = new OrderedDictionary(new MyComparer());

            array.Add(2, "Two");
            array.Add(3, "Three");
            array.Add(1, "One");
            array.Add(4, "Four");


            foreach (DictionaryEntry item in array)
            {
                Console.WriteLine($"{item.Key,-5} {item.Value}");
            }
        }
    }
}
