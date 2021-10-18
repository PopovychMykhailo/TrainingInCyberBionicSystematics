using System;

namespace Collection
{
    class Program
    {
        static void Main()
        {
            var collection = new UserCollection<int> { 1, 2, 3};

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(collection.Contains(2));

            // Delay.
            Console.ReadKey();
        }
    }
}
