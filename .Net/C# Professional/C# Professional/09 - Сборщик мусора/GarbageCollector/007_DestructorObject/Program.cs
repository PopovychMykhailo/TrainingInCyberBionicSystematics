using System;

namespace DestructorObject
{
    class MyClass : Object
    {
        // INFO:
        // В базовом классе Object имеется свой деструктор, 
        // но он не вызывается для объектов производного класса.
        // В производных классах, требуется создавать собственный деструктор.

        // См. Ctrl + w + j 
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
        }
    }
}
