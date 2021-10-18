using System.Collections;

// "ConcreteAggregate" 

namespace Iterator
{
    class ConcreteAggregate : Aggregate
    {
        private readonly ArrayList elements = new ArrayList();

        private ConcreteIterator iterator;

        public override Iterator CreateIterator()
        {
            iterator = new ConcreteIterator(this);
            return iterator;
        }

        public int Count
        {
            get { return elements.Count; }
        }

        public override object this[int index]
        {
            get { return elements[index]; }
            set { elements.Insert(index, value); }
        }
    }
}
