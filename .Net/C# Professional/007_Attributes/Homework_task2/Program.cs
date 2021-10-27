using System;

namespace Homework_task2
{
    /* Tehnical task
    
        Создайте класс и примените к его методам атрибут Obsolete сначала в форме, просто
        выводящей предупреждение, а затем в форме, препятствующей компиляции.
        Продемонстрируйте работу атрибута на примере вызова данных методов.
    */


    [Obsolete("The class is old, dont use it!", false)]
    class MyClass1
    {
        public void MyMethod(string str)
        {
            Console.WriteLine($"{GetType()}.Method: {str}");
        }
    }

    [Obsolete("The class is old, dont use it!", true)]
    class MyClass2
    {
        public void MyMethod(string str)
        {
            Console.WriteLine($"{GetType()}.Method: {str}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass1 myClass1 = new();  // Shows a warning
            MyClass2 myClass2 = new();  // Shows an error, and the program could not be created

            myClass1.MyMethod("Text 1");
            myClass2.MyMethod("Text 2");
        }
    }
}
