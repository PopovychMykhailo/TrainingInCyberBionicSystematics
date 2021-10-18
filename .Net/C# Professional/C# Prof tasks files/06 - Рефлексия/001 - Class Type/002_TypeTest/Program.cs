using System;
using System.Reflection;
using System.Text;

namespace Type_test
{
    static class Program
    {
        // Отображение различной информации о Class1.
        static void ListVariosStats(Class1 cl)
        {
            Console.WriteLine(new string('_', 30) + "\n");
            Type t = cl.GetType();

            Console.WriteLine($"{nameof(t.FullName)}     {t.FullName}    ", t.FullName);
            Console.WriteLine($"{nameof(t.BaseType)}     {t.BaseType}    ", t.BaseType);
            Console.WriteLine($"{nameof(t.IsAbstract)}   {t.IsAbstract}  ", t.IsAbstract);
            Console.WriteLine($"{nameof(t.IsCOMObject)}  {t.IsCOMObject} ", t.IsCOMObject);
            Console.WriteLine($"{nameof(t.IsSealed)}     {t.IsSealed}     ", t.IsSealed);
            Console.WriteLine($"{nameof(t.IsClass)}      {t.IsClass}     ", t.IsClass);
        }

        // Отображение методов Class1.
        static void ListMethods(Class1 cl)
        {
            Console.WriteLine(new string('_', 30) + " Методы класса Class1" + "\n");

            Type t = cl.GetType();
            MethodInfo[] mi = t.GetMethods(
                BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.Public
                    | BindingFlags.NonPublic 
                    | BindingFlags.DeclaredOnly);

            foreach (MethodInfo m in mi)
                Console.WriteLine("Метод: {0}", m.Name);
        }

        // Отображение полей Class1.
        static void ListFields(Class1 cl)
        {
            Console.WriteLine(new string('_', 30) + " Поля класса Class1" + "\n");

            Type t = cl.GetType();
            FieldInfo[] fi =
                t.GetFields(BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.Public
                    | BindingFlags.NonPublic);

            foreach (FieldInfo f in fi)
                Console.WriteLine("Field: {0}", f.Name);
        }

        // Отображение свойств Class1.
        static void ListProps(Class1 cl)
        {
            Console.WriteLine(new string('_', 30) + " Свойства класса Class1" + "\n");

            Type t = cl.GetType();
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.Public
                    | BindingFlags.NonPublic);

            foreach (PropertyInfo p in pi)
                Console.WriteLine("Свойство: {0}", p.Name);
        }

        // Отображение интерфесов, реализованных Class1.
        static void ListInterfaces(Class1 cl)
        {
            Console.WriteLine(new string('_', 30) + " Интерфейсы, реализованные классом Class1" + "\n");

            Type t = cl.GetType();

            Type[] it = t.GetInterfaces();

            foreach (Type i in it)
                Console.WriteLine("Интерфейс: {0}", i.Name);
        }

        // Отображение конструкторов Class1.
        static void ListConstructors(Class1 cl)
        {
            Console.WriteLine(new string('_', 30) + " Конструкторы класса Class1" + "\n");

            Type t = cl.GetType();
            ConstructorInfo[] ci = t.GetConstructors();

            foreach (ConstructorInfo m in ci)
                Console.WriteLine("Constructor: {0}", m.Name);
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.SetWindowSize(80, 45);

            Class1 instance = new Class1();

            ListVariosStats(instance); 
            ListMethods(instance);     
            ListFields(instance);      
            ListProps(instance);       
            ListInterfaces(instance);  
            ListConstructors(instance);

            Console.WriteLine(new string('-', 60));

            Type type = instance.GetType();

            MethodInfo methodC = type.GetMethod("MethodC", BindingFlags.Instance | BindingFlags.NonPublic);
            methodC.Invoke(instance, new object[] { "Hello", " world!" });
            
            FieldInfo mystring = type.GetField("mystring", BindingFlags.Instance | BindingFlags.NonPublic);
            mystring.SetValue(instance, "New Value!");

            // Delay.
            Console.ReadKey();
        }
    }
}
