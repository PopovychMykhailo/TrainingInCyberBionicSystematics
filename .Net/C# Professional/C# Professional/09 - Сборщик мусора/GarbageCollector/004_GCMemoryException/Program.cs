using System;
using System.Text;

// Большие объекты размещаются в большой куче и сразу относятся ко второму поколению.

namespace GCMemoryException
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
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Массив объектов - BigObject.
            // 381 * 1000 = 381 000 МБ = 372 ГБ - размер всего массива.
            BigObject[] objects = new BigObject[1000];

            try
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    //objects[i] = new BigObject();
                    BigObject @object = new BigObject(); 
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
