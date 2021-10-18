using System;

namespace AdHocPolimorfizm
{
    public abstract class AbsBaseClass
    {
        public abstract void AbsMeth();
        
        public virtual void VirtMeth()
        {
            Console.WriteLine("VirtMeth definition from AbsBaseClass");
        }

        public void SimpleMeth()
        {
            Console.WriteLine("SimpleMeth definition from AbsBaseClass");
        }

        //public abstract int field;
        
        //public virtual string field = "Some string";

        public int field = 777;


        public abstract int AbsProp
        {
            get;
            set;
        }

        private int myVar2 = 888;

        public virtual int VirtualProp
        {
            get { return myVar2; }
            set { myVar2 = value; }
        }

        protected int myVar = 000;

        public virtual int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public abstract event Action AbstractEvent;

        public virtual event Action VirtualEvent;
    }
}
