using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System;

// Расширяющие методы. (Extension methods)

// Расширяющие методы могут быть только статическими и создаваться только в статических классах.

namespace Extension
{
    static class ExtensionClass
    {
        // this - сообщает компилятору, что данный метод является расширяющим (Extension)!
        public static void ExtensionMethod(this string value)
        {
            Console.WriteLine(value);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            string text = "Тестовая строка";

            // Вызов метода, как статического.
            ExtensionClass.ExtensionMethod(text);

            // Вызов метода, как расширяющего.
            text.ExtensionMethod();


            // Delay.
            Console.ReadKey();
        }
    }
}

