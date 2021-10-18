using System;

// Базовый класс Object.

// Правило: Переопределяйте GetHashCode переопределяя Equals.

namespace ClassObject
{
    class Point : object
    {
        protected int x, y;

        public Point(int xValue, int yValue)
        {
            x = xValue;
            y = yValue;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Point p = (Point)obj;
            return (x == p.x) && (y == p.y);
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }
    }

    class Program
    {
        static void Main()
        {
            Point a = new Point(1, 2);
            Point b = new Point(1, 2);
            Point c = new Point(0, 0);

            Console.WriteLine("a == b : {0}", a.Equals(b));
            Console.WriteLine("a == c : {0}", a.Equals(c));

            Console.WriteLine("a == b : {0}", Equals(a, b));
            Console.WriteLine("a == c : {0}", Equals(a, c));

            // Delay.
            Console.ReadKey();
        }
    }
}
