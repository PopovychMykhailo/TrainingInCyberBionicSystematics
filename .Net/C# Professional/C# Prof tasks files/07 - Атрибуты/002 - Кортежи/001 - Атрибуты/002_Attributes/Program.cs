using System;
using System.Reflection;

// Атрибуты. 

namespace AttributeWork
{
    [My("1/31/2008", Number = 1)]
    public class MyClass
    {
        [MyAttribute("2/31/2007", Number = 2)]
        public static void Method()
        {
            Console.WriteLine("MyClass.Method()\n");
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
            MyClass.Method();

            // Анализ атрибутов.

            Type type = typeof(MyClass);

            // Анализ атрибутов типа.

            // Получаем все аттрибуты заданного типа MyAttribute 
            // (false - без проверки базовых классов).
            object[] attributes = type.GetCustomAttributes(false);

            foreach (MyAttribute attribute in attributes)
            {
                Console.WriteLine("Анализ типа  : Number = {0}, Date = {1}",
                    attribute.Number, attribute.Date);
            }


            // Анализ атрибутов метода.

            // Получаем public static метод - Method.
            MethodInfo method = type.GetMethod("Method",
                BindingFlags.Public | BindingFlags.Static);

            // Получаем все аттрибуты заданного типа MyAttribute 
            // (false - без проверки базовых классов).
            attributes = method.GetCustomAttributes(typeof(MyAttribute), false);

            foreach (MyAttribute attribute in attributes)
            {
                Console.WriteLine("Анализ метода: Number = {0}, Date = {1}",
                    attribute.Number, attribute.Date);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
