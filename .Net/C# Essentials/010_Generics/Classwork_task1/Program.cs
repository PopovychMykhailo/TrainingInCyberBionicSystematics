using System;

namespace Classwork_task1
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте класс MyClass<T>, содержащий статический фабричный метод – T FacrotyMethod(),
        который будет порождать экземпляры типа, указанного в качестве параметра типа (указателя места
        заполнения типом – Т).
    */

    public static class MyClass<T> where T : new()
    {
        static public T FacrotyMethod()
        {
            return new T();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int integer = MyClass<int>.FacrotyMethod();

            Console.WriteLine($"Integer: {integer}");
        }
    }
}
