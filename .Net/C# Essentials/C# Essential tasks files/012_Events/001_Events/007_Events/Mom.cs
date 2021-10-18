using System;

namespace _007_Events
{
    class Mom 
    {
        public void TeachChildToGreet(Person person, string greeting, Child child) 
        {
            Console.WriteLine($"Mom: If wou meet {person}, tell \"{greeting}\"");
            
            child.Meet += (p) => 
            {
                if (p == person)
                {
                    Console.WriteLine($"Child: {greeting}");
                }
            };
        }
    }
}