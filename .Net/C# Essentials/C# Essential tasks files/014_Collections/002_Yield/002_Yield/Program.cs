using System;
using System.Collections;

namespace Yield
{
    class Program
    {
        static void Main()
        {
            foreach (string element in UserCollection.Power())
                Console.WriteLine(element);

            Console.WriteLine(new string('-', 12));

            //-----------------------------------------------------------------------------------------------
            // Так работает foreach.

            IEnumerable enumerable = UserCollection.Power();

            IEnumerator enumerator = enumerable.GetEnumerator();
            enumerator.Reset();

            while (enumerator.MoveNext()) // Перемещаем курсор на 1 шаг вперед.
            {
                String element = enumerator.Current as String;

                Console.WriteLine(element);
            }

            // Delay. 
            Console.ReadKey();
        }
    }
}
