using System;

namespace Classwork_task1
{
    /* Technical task
    
        Реализуйте шаблон NVI в собственной иерархии наследования.
    */



    class Base
    {
        string myText = "Base class";
        int myValue = 123456;

        public string GetFullInfo()
        {
            return (GetFullInfo_Core());
        }

        protected virtual string GetFullInfo_Core()
        {
            return $"Text: {myText} \nValue: {myValue}";
        }
    }

    class Derived : Base
    {
        decimal myDouble = 3.14M;

        protected override string GetFullInfo_Core()
        {
            return base.GetFullInfo_Core() + $"\nDecimal: {myDouble}";
        }
    }

    class Program
    {
        static void Main()
        {
            Base @class = new Derived();

            Console.WriteLine(@class.GetFullInfo());
        }
    }
}
