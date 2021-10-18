using System;
using System.Text;

// Большие объекты размещаются в большой куче и сразу относятся ко второму поколению.

namespace GCBigObjects
{
    // BigObject - обертка для большого объекта. Будет размещен в малой куче.
    class BigObject
    {
        // Действительно большой объект. Будет размещен в большой куче.
        // 100 000 000 * 4 Б = 400 000 000 Б = 390 625 КБ = 381 МБ
        Array array = new int[100000000];
        public BigObject()
        {
            Console.WriteLine(this.GetHashCode());
        }
        ~BigObject()
        {
            Console.WriteLine("Объект " + this.GetHashCode() + " удален");
        }
    }
    class Program
    {
        static void CreateInstance()
        {
            BigObject @object = new BigObject();
            Console.WriteLine("Поколение объекта BigObject: {0}", GC.GetGeneration(@object));
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Действительно большой объект. Будет размещен в большой куче (Поколение 2).
            // 100 000 000 * 4 Б = 400 000 000 Б = 390 625 КБ = 381 МБ
            Array array = new int[100000000];
            Console.WriteLine("Поколение объекта Array: {0}", GC.GetGeneration(array));

            // Будет размещен в малой куче, а внутренний массив в большой куче (Поколение 0).
            CreateInstance();

            GC.Collect();
            // Delay.
            Console.ReadKey();
        }
    }
}
