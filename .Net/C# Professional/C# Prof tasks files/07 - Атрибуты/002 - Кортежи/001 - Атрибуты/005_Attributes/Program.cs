using System;
using System.Reflection;

// Атрибуты сборки - добавляются в файл AssemblyInfo.cs

namespace Attributes
{
    class Program
    {
        static void Main()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            object[] attributes = assembly.GetCustomAttributes(false);

            foreach (Attribute attribute in attributes)
            {
                Console.WriteLine("Attribute: {0}", attribute.GetType().Name);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
