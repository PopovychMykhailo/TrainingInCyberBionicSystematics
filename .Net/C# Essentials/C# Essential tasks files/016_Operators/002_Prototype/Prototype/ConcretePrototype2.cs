namespace Prototype
{
    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(string id)
            : base(id)
        {
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype2(this.Id);
        }
    }
}
