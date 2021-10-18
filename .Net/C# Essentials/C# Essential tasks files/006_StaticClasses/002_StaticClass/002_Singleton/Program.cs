using System;
using System.Text;

// Паттерн проектирования - Singleton.

namespace Static
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Конструктор "protected" - невозможно использовать - new Singleton() 
            Singleton instance1 = Singleton.GetInstance();
            Singleton instance2 = Singleton.GetInstance();

            if (instance1 == instance2)
                Console.WriteLine("Ссылки указывают на один экземпляр объекта.");            
            
            // Delay.
            Console.ReadKey();
        }
    }
}
