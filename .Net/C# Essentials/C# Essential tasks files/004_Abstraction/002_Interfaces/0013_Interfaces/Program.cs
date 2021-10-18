using System;
using System.Text;

namespace _0013_Interfaces
{
    class Program
    {
        private static void VisitParents(ISon man)
        {
            Console.WriteLine($"В методе {nameof(VisitParents)}:");
            man.SayHi();
            man.ShareChildhoodMemories();

            // При работе с объектом с помощью интерфейса ISon, доступны только те методы, которые определены в этом интерфейсе
            // man.DiscussWork();
        }

        private static void MeetFriend(IFriend man)
        {
            Console.WriteLine($"В методе {nameof(MeetFriend)}:");
            man.SayHi();
            man.HangOut();

            // При работе с объектом с помощью интерфейса IFriend, доступны только те методы, которые определены в этом интерфейсе
            // man.ShareChildhoodMemories();
        }

        private static void ComeHome(IHusband man)
        {
            Console.WriteLine($"В методе {nameof(ComeHome)}:");
            man.SayHi();
            man.ExpressLove();

            // При работе с объектом с помощью интерфейса IHusband, доступны только те методы, которые определены в этом интерфейсе
            // man.HangOut();
        }

        private static void GoWork(IColleague man)
        {
            Console.WriteLine($"В методе {nameof(GoWork)}:");
            man.SayHi();
            man.DiscussWork();

            // При работе с объектом с помощью интерфейса IColleague, доступны только те методы, которые определены в этом интерфейсе
            // man.ExpressLove();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            string line = new string('-', Console.WindowWidth);

            Man man = new Man();

            // При выполнении каждого метода ниже объект приводится к определенному интерфейсу.
            // Это можно сравнить с ролью, которую играет человек в различных ситуациях.

            GoWork(man);
            Console.WriteLine(line);
            MeetFriend(man);
            Console.WriteLine(line);
            VisitParents(man);
            Console.WriteLine(line);
            ComeHome(man);

            Console.ReadLine();
        }
    }
}