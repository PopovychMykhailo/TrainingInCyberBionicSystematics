using System;

// Базовый класс Object.

// Правило: Переопределяйте GetHashCode переопределяя Equals.

namespace ClassObject
{
    class Point
    {
        protected int x, y;

        public Point(int xValue, int yValue)
        {
            x = xValue;
            y = yValue;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            Point p = (Point)obj;
            return (x == p.x) && (y == p.y);
        }

        public override int GetHashCode()
        {
            // F1..FN

            // F1.GetHashCode() ^ F2.GetHashCode() ^ ... ^ FN.GetHashCode()

            // Prime1..PrimeN
            // Prime1 * F1.GetHashCode() ^ Prime2 * F2.GetHashCode() ^ ... ^ PrimeN * FN.GetHashCode()

            return 3 * x ^ 7 * y;
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

            // Delay.
            Console.ReadKey();
        }
    }
}
