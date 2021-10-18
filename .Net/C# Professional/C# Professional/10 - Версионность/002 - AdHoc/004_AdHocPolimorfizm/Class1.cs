using System;

namespace AdHocPolimorfizm
{
    public class Class1 : AbsBaseClass
    {
        public override void AbsMeth()
        {
            Console.WriteLine("AbsMeth implementation from Class1");
        }

        private int myVar = 111;
        public override int AbsProp
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public override int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        public override event Action AbstractEvent;
    }
}
