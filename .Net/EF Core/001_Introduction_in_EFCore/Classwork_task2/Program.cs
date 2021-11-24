using System;
using System.Linq;


// Load the structure data from the database

namespace Classwork_task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Datas in db: ");

            using (TestDBContext context = new TestDBContext())
            {
                var list = context.Users.ToList();

                foreach (var item in list)
                    Console.WriteLine($"{item.Id} - {item.Name} - {item.Age}");
            }
        }
    }
}
