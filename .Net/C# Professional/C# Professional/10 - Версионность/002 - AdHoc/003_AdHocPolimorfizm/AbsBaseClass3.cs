using System;

namespace AdHocPolimorfizm
{
    public abstract class AbsBaseClass3
    {
        public abstract void AbstractMethod();

        public virtual void VirtualMethod()
        {
            Console.WriteLine("VirtualMethod definition from AbsBaseClass3");
        }

        public void SimpleMethod()
        {
            Console.WriteLine("SimpleMethod from AbsBaseClass1");
        }
    }
}
