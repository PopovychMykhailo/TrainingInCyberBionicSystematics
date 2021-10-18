using System;
using System.IO;
using System.Reflection;
using System.Text;
using CarLibrary;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Assembly assembly = null;

            try
            {
                assembly = Assembly.Load("001_CarLibrary");

                Type type = assembly.GetType("CarLibrary.MiniVan");

                ICar carInstance = Activator.CreateInstance(type) as ICar;

                if (carInstance != null)
                {
                    carInstance.Acceleration();
                    carInstance.Driver("Shumaher", 26);
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
           
            // Delay.
            Console.ReadKey();
        }
    }
}
