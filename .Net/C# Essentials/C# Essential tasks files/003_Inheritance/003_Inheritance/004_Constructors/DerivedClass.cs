
// Наследование.

namespace Inheritance
{
    class DerivedClass : BaseClass
    {
        public int derivedField;

        // Конструктор по умолчанию.
        public DerivedClass()
            : this(5, 10)
        {
            System.Console.WriteLine("Three: " + baseNumber);
        }

        // Пользовательский конструктор.
        // Вызывается пользовательский конструктор базового класса, при этом не нужно, 
        // присваивать значения, унаследованным членам в конструкторе производного класса.
        public DerivedClass(int number1, int number2)
            : base(number1)
        {
            System.Console.WriteLine("Two: " + baseNumber);
            derivedField = number2;
        }
    }
}
