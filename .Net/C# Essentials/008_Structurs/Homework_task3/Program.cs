using System;

namespace Homework_task3
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте перечисление, в котором будут содержаться должности сотрудников как имена констант.
        Присвойте каждой константе значение, задающее количество часов, которые должен отработать
        сотрудник за месяц.
        Создайте класс Accountant с методом bool AskForBonus(Post worker, int hours), отражающее
        давать или нет сотруднику премию. Если сотрудник отработал больше положенных часов в месяц, то
        ему положена премия.
    */

    enum Positions : int
    {
        PM = 180,
        Developer = 176,
        HR = 132,
        Maid = 88
    }

    static class Accountant
    {
        static public bool AskForBonus(Post worker, int workedHours)
        {
            if (workedHours > worker.MonthWorkHours) 
                return true;
            else 
                return false;
        }
    }

    class Post
    {
        public Positions Position { set; get; }
        public int MonthWorkHours { get; }

        public Post(Positions position)
        {
            this.Position = position;
            this.MonthWorkHours = (int)position;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Post pm = new(Positions.PM);
            Post developer = new(Positions.Developer);
            Post hr = new(Positions.HR);
            Post maid = new(Positions.Maid);

            Console.WriteLine($"Is premium for PM:        {Accountant.AskForBonus(pm, 180)}");
            Console.WriteLine($"Is premium for developer: {Accountant.AskForBonus(developer, 180)}");
            Console.WriteLine($"Is premium for HR:        {Accountant.AskForBonus(hr, 150)}");
            Console.WriteLine($"Is premium for maid:      {Accountant.AskForBonus(maid, 80)}");
        }
    }
}
