using System;
using System.Collections;

namespace Homework_task3
{
    /* Technical task
    
        Создайте коллекцию, которая бы по своей структуре напоминала «родовое дерево» (имя
        человека, год рождения), причем в нее можно добавлять/удалять нового родственника, есть
        возможность увидеть всех наследников выбранного человека, отобрать родственников по году
        рождения.
    */


    class CollectionPerson : ICollection
    {
        Person[] array = Array.Empty<Person>();

        int ICollection.Count
        {
            get => array.Length;
        }
        public int Count
        {
            get => array.Length;
        }
        bool ICollection.IsSynchronized => false;
        object ICollection.SyncRoot => null;


        public CollectionPerson(Person[] persons)
        {
            array = new Person[persons.Length];
            persons.CopyTo(array, 0);
        }

        public void Add(Person item)
        {
            var newArray = new Person[array.Length + 1];    // Создание нового массива (на 1 больше старого).
            array.CopyTo(newArray, 0);                      // Копирование старого массива в новый.
            newArray[^1] = item;           // Помещение нового значения в конец массива.
            array = newArray;                               // Замена старого массива на новый.
        }
        public bool Remove(Person item)
        {
            int indexRemoveItem = -1;

            // Look up item in the array
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == item)
                {
                    indexRemoveItem = i;
                    break;
                }
            }

            // Shift the array (deleting this element)
            if (indexRemoveItem >= 0)
            {
                for (int i = indexRemoveItem; i < array.Length - 1; i++)
                    array[i] = array[i + 1];

                // Create a new array and copy objects to it
                Person[] newArray = new Person[Count - 1];
                for (int i = 0; i < newArray.Length; i++)
                    newArray[i] = array[i];
                array = newArray;

                return true;    // Remove successful
            }
            else
                return false;   // Remove failed
        }
        public bool Remove(string personName)
        {
            int indexRemoveItem = -1;

            // Look up item in the array
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Name == personName)
                {
                    indexRemoveItem = i;
                    break;
                }
            }

            // Shift the array (deleting this element)
            if (indexRemoveItem >= 0)
            {
                for (int i = indexRemoveItem; i < array.Length - 1; i++)
                    array[i] = array[i + 1];

                // Create a new array and copy objects to it
                Person[] newArray = new Person[Count - 1];
                for (int i = 0; i < newArray.Length; i++)
                    newArray[i] = array[i];
                array = newArray;

                return true;    // Remove successful
            }
            else
                return false;   // Remove failed
        }

        public Person this[int index]
        {
            set
            {
                if (index >= 0 && index < Count)
                {
                    array[index] = value;
                }
            }
            get
            {
                if (index >= 0 && index < Count)
                {
                    return array[index];
                }
                else
                {
                    throw new Exception("Index out of range!");
                }
            }
        }

        public IEnumerable IndexOfYearBirth(int yearBirth)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].YearBirth == yearBirth)
                    yield return array[i];
            }

            yield break;
        }
        void ICollection.CopyTo(Array array, int index)
        {
            array.CopyTo(array, index);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (array as IEnumerable).GetEnumerator();
        }
    }

    class Person
    {
        public string Name { set; get; }
        public int YearBirth { init; get; }

        public CollectionPerson Parents { set; get; } = null;
        public CollectionPerson Children { set; get; } = null;


        public bool AddParent(Person parent)
        {
            if (Parents != null)
            {
                Parents.Add(parent);
                return true;    // Added successfully
            }
            else
                return false;   // Added failed
        }
        public bool AddChild(Person child)
        {
            if (Children != null)
            {
                Children.Add(child);
                return true;    // Added successfully
            }
            else
                return false;   // Added failed
        }

        public void ShowFamily(bool isMainPerson = false, string shift = "")
        {
            if (Children != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(shift + "\t" + $"Children ({Name}): ");
                Console.ResetColor();

                for (int i = 0; i < Children.Count; i++)
                {
                    //Console.WriteLine($"{Children[i].Name,-15}, {Children[i].YearBirth}");
                    Children[i].ShowFamily(isMainPerson: false, shift + "\t");
                }
            }

            // Change color for main person
            if (isMainPerson)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(shift + $"Person: {Name,-15}, {YearBirth}");
                Console.ResetColor();
            }
            else
                Console.WriteLine(shift + $"Person: {Name,-15}, {YearBirth}");

            if (Parents != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(shift + "\t" + $"Parents ({Name}): ");
                Console.ResetColor();

                for (int i = 0; i < Parents.Count; i++)
                {
                    //Console.WriteLine(shift + $"{Parents[i].Name,-15}, {Parents[i].YearBirth}");
                    Parents[i].ShowFamily(isMainPerson: false, shift + "\t");
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Person i = new Person { Name = "Mykhailo", YearBirth = 2003 };
            Person mom = new Person { Name = "Larisa", YearBirth = 1963 };

            CollectionPerson momParents = new CollectionPerson(new Person[] {
                    new Person { Name = "Ivan", YearBirth = 1925 },
                    new Person { Name = "Olexandra", YearBirth = 1930, Parents = new CollectionPerson (new Person[] {
                            new Person{ Name = "Fedir", YearBirth = 1900 }
                        })
                    }
                });
            CollectionPerson momChildren = new CollectionPerson(new Person[] {
                    new Person { Name = "Tymofiy", YearBirth = 1990 },
                    new Person { Name = "Ludmila", YearBirth = 1990, Children = new CollectionPerson (new Person[] {
                            new Person{ Name = "Mykyta", YearBirth = 2010 }
                        })
                    }
                });

            mom.Parents = momParents;
            mom.Children = momChildren;


            // Add children
            mom.AddChild(i);                                                        // Variant 1
            mom.Children.Add(new Person { Name = "Anastasiya", YearBirth = 2005 }); // Variant 2

            // Delete child
            mom.Children.Add(new Person { Name = "5-th child", YearBirth = 2007 });
            mom.Children.Remove("5-th child");

            // Show all mom heirs
            Console.WriteLine("Heirs:");
            foreach (Person item in mom.Children)
            {
                Console.WriteLine($"{item.Name,-15}, {item.YearBirth}");
            }
            Console.WriteLine();

            // Show all relatives by year
            Console.WriteLine("Show all relatives by year:");
            foreach (Person item in mom.Children.IndexOfYearBirth(1990))
            {
                Console.WriteLine($"{item.Name,-15}, {item.YearBirth}");
            }
            foreach (Person item in mom.Parents.IndexOfYearBirth(1930))
            {
                Console.WriteLine($"{item.Name,-15}, {item.YearBirth}");
            }
            Console.WriteLine();

            // Show mom family
            mom.ShowFamily(isMainPerson: true);
        }
    }
}
