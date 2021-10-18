using System;

namespace _007_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Mom mom = new Mom();
            Child child = new Child();

            mom.TeachChildToGreet(Person.Dad, "Hi, dad!", child);
            mom.TeachChildToGreet(Person.MomsFriend, "Hello! My mom sends her regards!", child);
            mom.TeachChildToGreet(Person.Stranger, "I don't know you so don't speak to me please", child);
            mom.TeachChildToGreet(Person.PoliceOfficer, "Hello officer!", child);

            Console.WriteLine(new string('-', Console.WindowWidth));
            child.GoToSchool();

            Console.WriteLine(new string('-', Console.WindowWidth));
            child.GoHomeFromSchool();

            Console.WriteLine(new string('-', Console.WindowWidth));
            child.GoPlayWithFriends();

            Console.WriteLine(new string('-', Console.WindowWidth));
            child.GoToTheGranny();

        }
    }
}