// "ConcreteIterator"

namespace Iterator
{
    class ConcreteIterator : Iterator
    {
        private readonly ConcreteAggregate aggregate;
        private int current;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public override object First()
        {
            return aggregate[0];
        }

        public override object Next()
        {
            object element = null;

            if (current < aggregate.Count - 1)
                element = aggregate[++current];

            return element;
        }

        public override object CurrentItem()
        {
            return aggregate[current];
        }

        public override bool IsDone()
        {
            return current >= aggregate.Count - 1;
        }
    }
}
