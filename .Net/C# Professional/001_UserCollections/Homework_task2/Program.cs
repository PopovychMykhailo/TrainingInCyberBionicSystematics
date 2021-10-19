using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Homework_task2
{
    /* Technical task
    
        Создайте коллекцию, в которой бы хранились наименования 12 месяцев, порядковый номер и
        количество дней в соответствующем месяце. Реализуйте возможность выбора месяцев, как по
        порядковому номеру, так и количеству дней в месяце, при этом результатом может быть не
        только один месяц.
    */



    class CollectionMonths : IEnumerable
    {
        private Month[] months = new Month[12];
        private const int count = 12;

        public int Count
        {
            get => count;
        }


        public CollectionMonths()
        {
            months[0] = new Month { Sequence = 1, Name = "January", NumberDays = 31 };
            months[1] = new Month { Sequence = 2, Name = "February", NumberDays = 28 };
            months[2] = new Month { Sequence = 3, Name = "March", NumberDays = 31 };
            months[3] = new Month { Sequence = 4, Name = "April", NumberDays = 30 };
            months[4] = new Month { Sequence = 5, Name = "May", NumberDays = 31 };
            months[5] = new Month { Sequence = 6, Name = "June", NumberDays = 30 };
            months[6] = new Month { Sequence = 7, Name = "July", NumberDays = 31 };
            months[7] = new Month { Sequence = 8, Name = "August", NumberDays = 31 };
            months[8] = new Month { Sequence = 9, Name = "September", NumberDays = 30 };
            months[9] = new Month { Sequence = 10, Name = "October", NumberDays = 31 };
            months[10] = new Month { Sequence = 11, Name = "November", NumberDays = 30 };
            months[11] = new Month { Sequence = 12, Name = "December", NumberDays = 31 };
        }

        public Month this[int index]
        {
            get => months[index];
        }

        public IEnumerator GetEnumerator()
        {
            return months.GetEnumerator();
        }

        public IEnumerable<Month> IndexOfName(string name)
        {
            for (int i = 0; i < Count; i++)
            {
                if (months[i].Name.Contains(name))
                    yield return months[i];
            }

            yield break;
        }

        public IEnumerable<Month> IndexOfNumberDays(int numberDays)
        {
            for (int i = 0; i < Count; i++)
            {
                if (months[i].NumberDays == numberDays)
                    yield return months[i];
            }

            yield break;
        }

        public Month IndexOfSequence(int sequence)
        {
            if (sequence > 0 && sequence <= count)
            {
                return months[sequence - 1];
            }
            else
            {
                return new Month();
            }
        }

    }
    class Month
    {
        public int Sequence { init; get; }
        public string Name { init; get; }
        public int NumberDays { init; get; }
    }

    class Program
    {
        static void Main()
        {
            CollectionMonths months = new();

            Console.WriteLine("IndexOfName");
            foreach (var item in months.IndexOfName("A"))
            {
                Console.WriteLine($"{item.Sequence + ",", -3} {item.Name + ",", -10} {item.NumberDays, -20}");
            }
            Console.WriteLine(new string('-', 20) + "\n");

            Console.WriteLine("IndexOfSequence");
            Month month = months.IndexOfSequence(4);
            Console.WriteLine($"{month.Sequence + ",",-3} {month.Name + ",",-10} {month.NumberDays,-20}");
            Console.WriteLine(new string('-', 20) + "\n");

            Console.WriteLine("IndexOfNumberDays");
            foreach (var item in months.IndexOfNumberDays(31))
            {
                Console.WriteLine($"{item.Sequence + ",",-3} {item.Name + ",",-10} {item.NumberDays,-20}");
            }
            Console.WriteLine(new string('-', 20) + "\n");
        }
    }
}
