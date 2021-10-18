using System;

// Плохой пример. Так делать не рекомендуется.

namespace Generics
{
    class MyClass<T>
    {
        public T Add(T a, T b)
        {
            if (typeof(T) == typeof(int))
                return (T)(Object)((int)(object)a + (int)(object)b);

            if (typeof(T) == typeof(double))
                return (T)(Object)((double)(object)a + (double)(object)b);

            return (T)(object)0;
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass<int> my = new MyClass<int>();
            int sum = my.Add(2, 3);

            Console.WriteLine(sum);

            // Delay.
            Console.ReadKey();
        }
    }
}
