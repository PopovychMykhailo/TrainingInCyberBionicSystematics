using System;

namespace Classwork_task1
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте структуру описывающую точку в трехмерной системе координат. Организуйте возможность
        сложения двух точек, через использование перегрузки оператора +.
     */


    class Point3D
    {
        public int X { set; get; }
        public int Y { set; get; }
        public int Z { set; get; }


        public Point3D() { }
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public static Point3D operator +(Point3D point1, Point3D point2)
        {
            Point3D pointResult = new();

            pointResult.X = point1.X + point2.X;
            pointResult.Y = point1.Y + point2.Y;
            pointResult.Z = point1.Z + point2.Z;

            return pointResult;
        }
    }

    class Program
    {
        static void Main()
        {
            Point3D point1 = new(1, 2, 3);
            Point3D point2 = new(10, 20, 30);
            Point3D pointResult = point1 + point2;

            Console.WriteLine($"PointResult: X: {pointResult.X}; Y: {pointResult.Y}; Z: {pointResult.Z}");
        }
    }
}
