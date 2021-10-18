using System;
using System.Text;
using System.Threading;

// ПОКОЛЕНИЯ (Генерации)
// Поколение 0 - Объекты не проверялись сборщиком мусора.
// Поколение 1 - Объекты пережившие одну проверку сборщиком мусора 
//               (а также объекты помеченные на удаление, но не удаленные,
//               так как в управляемой куче было достаточно свободного места).
// Поколение 2 - Объекты которые пережили более чем одну проверку сборщиком мусора.

namespace GarbageCollector
{
    class NormalObject
    {
        byte[] array = new byte[1024]; // 1 KB
        public NormalObject()
        {
            Console.WriteLine("Constructor {0}", this.GetHashCode());
        }
        ~NormalObject()
        {
            Console.WriteLine("Destructor {0}", this.GetHashCode());
        }
    }
    class OtherObject
    {
        byte[] array = new byte[1024 * 50]; // 50 KB
    }
    class Program
    {
        static void AuxiliaryMethod()
        {
            OtherObject[] objects = new OtherObject[1000];

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i] = new OtherObject();
                //OtherObject @object = new OtherObject();

                Thread.Sleep(5);
            }
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Система поддерживает {0} поколения.", (GC.MaxGeneration + 1));
            Console.WriteLine(new string('-', 40));

            NormalObject @object = new NormalObject();

            // Параллельное наполнение малой кучи другими объектами.
            new Thread(AuxiliaryMethod).Start();

            for (int i = 0; i < 30; i++)
            {
                Console.Write("Поколение: {0} | ", GC.GetGeneration(@object));
                Console.WriteLine("Размер кучи = {0} KB", GC.GetTotalMemory(false) / 1024); // true
                Thread.Sleep(100);
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Поколение 0 проверялось {0} раз", GC.CollectionCount(0));
            Console.WriteLine("Поколение 1 проверялось {0} раз", GC.CollectionCount(1));
            Console.WriteLine("Поколение 2 проверялось {0} раз", GC.CollectionCount(2));
            Console.WriteLine(new string('-', 40));
        }
    }
}
