using System;

namespace AdHocPolimorfizm
{
    public abstract class AbsBaseClass2
    {
        public abstract void AbstractMethod();
        
        public virtual void VirtualMethod()
        {
            Console.WriteLine("VirtualMethod definition from AbsBaseClass2");
        }

        public void SimpleMethod()
        {
            Console.WriteLine("SimpleMethod from AbsBaseClass2");
        }
    }
}
