using System;

namespace HomeWork_task3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMatrix myMatrix = new MyMatrix(5, 10);

            myMatrix.Show();
            Console.WriteLine("-----------------------------------------------");

            myMatrix.ReSize(10, 5);
            myMatrix.Show();
            Console.WriteLine("-----------------------------------------------");

            myMatrix.ReSize(5, 10);
            myMatrix.Show();
            Console.WriteLine("-----------------------------------------------");
        }
    }
}
