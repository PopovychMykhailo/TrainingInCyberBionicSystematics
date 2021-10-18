using System;

namespace _0013_Interfaces
{
    interface ISon
    {
        void SayHi();

        void ShareChildhoodMemories();
    }

    interface IFriend
    {
        void SayHi();

        void HangOut();
    }

    interface IHusband
    {
        void SayHi();

        void ExpressLove();
    }

    interface IColleague
    {
        void SayHi();

        void DiscussWork();
    }

    abstract class Human
    {
        public abstract void Walk();

        public void Sleep()
        {
            Console.WriteLine("Just sleeping...");
        }
    }

    class Man : Human, ISon, IFriend, IHusband, IColleague
    {
        void ISon.SayHi()
        {
            Console.WriteLine("Привет, родители!");
        }

        void IFriend.SayHi()
        {
            Console.WriteLine("Привет, друзья!");
        }

        void IHusband.SayHi()
        {
            Console.WriteLine("Привет, дорогая!");
        }

        void IColleague.SayHi()
        {
            Console.WriteLine("Здравствуйте!");
        }

        public void DiscussWork()
        {
            Console.WriteLine("Представляешь, когда я работал над той задачей, у меня возникла такая проблема...");
        }

        public void ExpressLove()
        {
            Console.WriteLine("Люблю тебя!");
        }

        public void HangOut()
        {
            Console.WriteLine("*тусуется с другом*");
        }

        public void ShareChildhoodMemories()
        {
            Console.WriteLine("А вы помните тот случай, когда я остался один дома на рождество и нас пытались ограбить...");
        }

        public override void Walk()
        {
            Console.WriteLine("*человек идет*");
        }
    }

}
