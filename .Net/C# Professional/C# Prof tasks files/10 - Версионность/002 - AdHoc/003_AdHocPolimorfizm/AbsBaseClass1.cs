using System;

namespace AdHocPolimorfizm
{
    public abstract class AbsBaseClass1
    {
        public abstract void AbstractMethod();

        public virtual void VirtualMethod()
        {
            Console.WriteLine("VirtualMethod definition from AbsBaseClass1");
        }

        public void SimpleMethod()
        {
            Console.WriteLine("SimpleMethod from AbsBaseClass1");
        }
    }
}
