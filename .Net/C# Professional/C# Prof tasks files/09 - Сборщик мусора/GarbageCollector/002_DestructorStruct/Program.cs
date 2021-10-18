
// Ограничения деструкторов.

namespace DestructorStruct
{
    struct MyStruct
    {
        // В структурах недопустимо создавать деструкторы.
        //~MyStruct()
        //{

        //}
    }

    class MyClass
    {
        // Деструкторы не могут иметь аргументов.

        //~ MyClass(int arg)
        //{

        //}

        // Деструкторы не могут быть статичесикими.
        //static ~ MyClass()
        //{

        //}

        // Деструкторы не могут иметь модификаторов доступа.

        //public ~ MyClass()
        //{

        //}
    }

    class Program
    {
        static void Main()
        {
        }
    }
}
