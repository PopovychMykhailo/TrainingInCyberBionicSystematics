using System;

namespace Indexers
{
    class DerivedClass : BaseClass
    {
        private string[] derivedArray = null;

        // Конструктор.
        public DerivedClass()
        {
            derivedArray = new string[3];
            derivedArray[0] = "Zero!";
            derivedArray[1] = "One!";
            derivedArray[2] = "Two!";
        }

        // Переопределенный индексатор.
        public override string this[int index]
        {
            get { return base[index] + " - " + derivedArray[index]; }
        }
    }
}
