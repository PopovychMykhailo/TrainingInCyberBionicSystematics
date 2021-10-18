
// Наследование.

namespace Inheritance
{
    class BaseClass
    {
        public int baseNumber = -1;

        // Конструктор по умолчанию.
        public BaseClass()
        {
        }

        // Пользовательский конструктор.
        public BaseClass(int number)
        {
            System.Console.WriteLine("One: " + baseNumber);
            this.baseNumber = number;
        }
    }
}
