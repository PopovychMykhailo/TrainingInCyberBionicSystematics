namespace _013_Variance
{
    class Animal { }
    class Dog : Animal { }

    interface IReadOnlyCollection<out T>
    {
        T GetElement(int index);
    }

    interface IWriteOnlyCollection<in T> 
    {
        void SetElement(T element, int index);
    }

    class Collection<T> : IReadOnlyCollection<T>, IWriteOnlyCollection<T>
    {
        private T[] _collection;

        public Collection(T[] collection)
        {
            _collection = collection;
        }

        public T GetElement(int index)
        {
            return _collection[index];
        }

        public void SetElement(T element, int index)
        {
            _collection[index] = element;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dogs = new Dog[]
            {
                new Dog(),
                new Dog(),
                new Dog()
            };

            var dogCollection = new Collection<Dog>(dogs);
            var animalCollection = new Collection<Animal>(dogs);

            IReadOnlyCollection<Dog> readonlyDogs = dogCollection;
            IWriteOnlyCollection<Dog> writeOnlyDogs = dogCollection;

            IReadOnlyCollection<Animal> readonlyAnimals = dogCollection;
            IWriteOnlyCollection<Dog> writeOnlyAnimals = animalCollection;

            Animal animal = readonlyAnimals.GetElement(0);
            writeOnlyAnimals.SetElement(new Dog(), 1);
        }
    }
}
