using System;

namespace AdHocPolimorfizm
{
    public class Class2 : AbsBaseClass2
    {
        public override void AbstractMethod()
        {
            Console.WriteLine("Class 2");
        }

        public new void SimpleMethod()
        {
            Console.WriteLine("SimpleMethod from Class2");
        }
    }
}
