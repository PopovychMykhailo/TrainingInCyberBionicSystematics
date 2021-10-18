using System;
using System.Text;

namespace AttributeWork
{
    [My("XXXXX", "YYYYY")]
    class BaseClass
    {
    }

    //[My("First", "31/01/2008"), My("First", "31/01/2009")]

    [My("First", "31/01/2008")]
    [My("Second", "31/01/2009")]
    class MyClass : BaseClass
    {
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Type type = typeof(MyClass);

            object[] attributes = type.GetCustomAttributes(typeof(MyAttribute), true);

            foreach (MyAttribute attribute in attributes)
            {
                Console.WriteLine("{0}, {1}", attribute.Text, attribute.Data);
                attribute.Method();
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
