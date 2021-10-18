using System;

namespace _007_Events
{
    class Child 
    {
        public event Action<Person> Meet;

        public void GoHomeFromSchool() 
        {
            Console.WriteLine("Walking from school...");
            Walk();
        }

        public void GoToSchool()
        {
            Console.WriteLine("Walking to school...");
            Walk();
        }

        public void GoPlayWithFriends()
        {
            Console.WriteLine("Walking to friends...");
            Walk();
        }

        public void GoToTheGranny()
        {
            Console.WriteLine("Walking to the granny...");
            Walk();
        }

        private void Walk() 
        {
            bool hasMetSomeone = new Random().Next(1, 3) % 2 == 0;
            if (hasMetSomeone)
            {
                var person = GetRandomPerson();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"*met {person}*");
                Console.ResetColor();
                Meet.Invoke(person);
            }
        }

        private Person GetRandomPerson()
        {
            var enumValues = Enum.GetValues(typeof(Person));
            var randomIdx = new Random().Next(0, enumValues.Length);
            return (Person)enumValues.GetValue(randomIdx);
        }
    }
}