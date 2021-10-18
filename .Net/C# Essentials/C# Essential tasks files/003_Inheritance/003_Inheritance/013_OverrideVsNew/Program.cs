using System;

namespace _013_OverrideVsNew
{
    class BaseClass
    {
        public virtual void Method()
        {
            Console.WriteLine("Method from BaseClass");
        }
    }

    class DerivedClass : BaseClass
    {
        public override void Method()
        {
            Console.WriteLine("Method from DerivedClass");
        }
    }


    class A
    {
        public void Method1()
        {
            Console.WriteLine("A.Method1");
        }
        public virtual void Method2()
        {
            Console.WriteLine("A.Method2");
        }
    }

    class B : A
    {
        public new void Method1()
        {
            Console.WriteLine("B.Method1");
        }
        public override void Method2()
        {
            Console.WriteLine("B.Method2");
        }
    }

    class C : B
    {
        public new virtual void Method1()
        {
            Console.WriteLine("C.Method1");
        }
        public override void Method2()
        {
            Console.WriteLine("C.Method2");
        }
    }

    class D : C
    {
        public new virtual void Method1()
        {
            Console.WriteLine("D.Method1");
        }

        public new virtual void Method2()
        {
            Console.WriteLine("D.Method2");
        }
    }

    class E : D
    {
        public override void Method1()
        {
            Console.WriteLine("E.Method1");
        }
        public override void Method2()
        {
            Console.WriteLine("E.Method2");
        }
    }

    class Program
    {

        static void Main(string[] args)
        {

            DerivedClass inst = new DerivedClass();
            inst.Method();

            ((BaseClass)inst).Method();

            A a = new A();
            B b = new B();
            C c = new C();
            D d = new D();
            E e = new E();

            // Раскомментируйте одну из строк с вызовами методов Method1 и Method2.
            // Попробуйте определить, какая строка будет выведена на экран в результате выполнения метода.
            // Запустите приложение и проверьте, верным ли было Ваше предположение.

            //Console.WriteLine(new string('-', 30));
            //((A)e).Method2();
            //Console.WriteLine(new string('-', 30));

            //a.Method1();
            //b.Method1();
            //c.Method1();
            //d.Method1();
            //e.Method1();

            //Console.WriteLine(new string('-', 30));

            //a.Method2();
            //b.Method2();
            //c.Method2();
            //d.Method2();
            //e.Method2();

            //Console.WriteLine(new string('-', 30));

            //((A)b).Method1();
            //((A)c).Method1();
            //((A)d).Method1();
            //((A)e).Method1();

            //Console.WriteLine(new string('-', 30));

            //((A)b).Method2();
            //((A)c).Method2();
            //((A)d).Method2();
            //((A)e).Method2();

            //Console.WriteLine(new string('-', 30));

            //((B)c).Method1();
            //((B)d).Method1();
            //((B)e).Method1();

            //Console.WriteLine(new string('-', 30));

            //((B)c).Method2();
            //((B)d).Method2();
            //((B)e).Method2();

            //Console.WriteLine(new string('-', 30));

            //((C)d).Method1();
            //((C)e).Method1();

            //Console.WriteLine(new string('-', 30));

            //((C)d).Method2();
            //((B)e).Method2();

            //Console.WriteLine(new string('-', 30));

            //((D)e).Method1();

            //Console.WriteLine(new string('-', 30));

            //((D)e).Method2();

            Console.Read();
        }
    }
}
