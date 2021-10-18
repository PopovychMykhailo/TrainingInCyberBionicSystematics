using System;
using System.IO;
using System.Reflection;

namespace LoadAssembly
{
    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(80, 50);

            Assembly assembly = null;
            
            try
            {
                //assembly = Assembly.Load("001_CarLibrary"); // LoadFrom(...)
                // Необходимо скопировать сборку 001_CarLibrary.dll из директории bin/debug в примере 001_CarLibrary
                // и разместить её по указаному пути
                assembly = Assembly.LoadFrom("D:\\001_CarLibrary.dll");
                Console.WriteLine("Loaded CarLibrary assembly");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ListAllTypes(assembly);
            ListAllMembers(assembly);
            GetParams(assembly);

            // Delay.
            Console.ReadKey();
        }

        private static void ListAllTypes(Assembly assembly)
        {
            Console.WriteLine(new string('_', 80));
            Console.WriteLine("\nListAllTypes in: {0} \n", assembly.FullName);

            Type[] types = assembly.GetTypes();

            foreach (Type t in types)
                Console.WriteLine("Type: {0}", t);
        }

        private static void ListAllMembers(Assembly assembly)
        {
            Console.WriteLine(new string('_', 80));

            Type type = assembly.GetType("CarLibrary.MiniVan");

            Console.WriteLine("\nListAllMembers for: {0} \n", type);

            MemberInfo[] members = type.GetMembers();

            foreach (MemberInfo element in members)
                Console.WriteLine("{0,-15}:  {1}", element.MemberType, element);
        }

        private static void GetParams(Assembly assembly)
        {
            Console.WriteLine(new string('_', 80));

            Type type = assembly.GetType("CarLibrary.MiniVan");
            MethodInfo method = type.GetMethod("Driver"); // Equals , Acceleration, Driver

            Console.WriteLine("\nGetParams for method {0}", method.Name);
            ParameterInfo[] parameters = method.GetParameters();
            Console.WriteLine("Params length: " + parameters.Length);

            foreach (ParameterInfo parameter in parameters)
            {
                Console.WriteLine("parameter.Name: {0}", parameter.Name);
                Console.WriteLine("parameter.Position: {0}", parameter.Position);
                Console.WriteLine("parameter.ParameterType: {0}", parameter.ParameterType);
            }
        }
    }
}
