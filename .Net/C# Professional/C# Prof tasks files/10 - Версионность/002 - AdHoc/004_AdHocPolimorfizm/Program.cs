using System;

namespace AdHocPolimorfizm
{
    class Program
    {
        static void Main()
        {
            AbsBaseClass[] array = { new Class1(), new Class2(), new Class3() };

            foreach (AbsBaseClass item in array)
            {
                item.AbsMeth();
                item.VirtMeth();
                item.SimpleMeth();

                Console.WriteLine("Field: " + item.field);
                Console.WriteLine("Property: " + item.MyProperty);
                Console.WriteLine("Abstract Property: " + item.AbsProp);
                Console.WriteLine("Virtual Property: " + item.VirtualProp);
                Console.WriteLine(new string('_', 55));
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
