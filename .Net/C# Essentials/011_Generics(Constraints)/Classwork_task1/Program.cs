using System;
using System.Collections;

namespace Classwork_task1
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        В коллекцию ArrayList, через вызов метода Add добавьте элементы структурного и ссылочного типа,
        переберите данную коллекцию с помощью, цикла for. С какой проблемой вы столкнулись?
    */

    /* Result
     * 
     * I didn't find any problem
     */

    public readonly struct Coords
    {
        public Coords(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; init; }
        public double Y { get; init; }

        public override string ToString() => $"({X}, {Y})";
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new();

            int integer = 300;
            string str = "Hello";
            Coords coords = new(2, 5);

            arrayList.Add(integer);
            arrayList.Add(str);
            arrayList.Add(coords);

            for (int i = 0; i < arrayList.Count; i++)
                Console.WriteLine($"arrayList[{i}]: {arrayList[i]}");
        }
    }
}
