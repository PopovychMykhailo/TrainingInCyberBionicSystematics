using System;

namespace AdHocPolimorfizm
{
    public class Class1 { public void Method() { Console.WriteLine("Class 1"); } }
    public class Class2 { public void Method() { Console.WriteLine("Class 2"); } }
    public class Class3 { public void Method() { Console.WriteLine("Class 3"); } }

    class Program
    {
        static void Main()
        {
            dynamic[] array = { new Class1(), new Class2(), new Class3(), new DateTime() };

            foreach (var item in array)
                item.Method();

            // Delay
            Console.ReadKey();
        }
    }
}
