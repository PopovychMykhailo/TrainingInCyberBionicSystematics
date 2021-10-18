using System;

// Ковариантность обобщений.
// Ковариантность обобщений в C# 4.0 ограничена интерфейсами и делегатами.

namespace Generics
{
    public abstract class Shape { }
    public class Circle : Shape { }

    public interface IContainer<out T>
    {
        T Figure { get; }
    }

    public class Container<T> : IContainer<T>
    {
        private T figure;

        public Container(T figure)
        {
            this.figure = figure;
        }

        public T Figure
        {
            get { return figure; }
        }
    }

    class Program
    {
        static void Main()
        {
            Circle circle = new Circle();

            IContainer<Shape> container = new Container<Circle>(circle);

            Console.WriteLine(container.Figure.ToString());

            // Delay.
            Console.ReadKey();
        }
    }
}
