using System;

namespace Static
{
    class ConcreteClass : AbstractClass
    {
        public override void Method()
        {
            Console.WriteLine("Hello world!");
        }

        public ConcreteClass()
        {
            Console.WriteLine("Concrete Ctor");
        }
    }
}
