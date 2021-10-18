using System;

namespace Static
{
    abstract class AbstractClass
    {
        // Статический фабричный метод.
        public static AbstractClass CreateObject()
        {
            return new ConcreteClass();
        }

        protected AbstractClass()
        {
            Console.WriteLine("Abstract ctor!");
        }

        public abstract void Method();
    }
}
