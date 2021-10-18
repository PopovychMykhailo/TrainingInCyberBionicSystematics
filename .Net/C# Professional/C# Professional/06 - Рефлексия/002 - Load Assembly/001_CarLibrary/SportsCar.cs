using System;

namespace CarLibrary
{
    public class SportsCar : Car
    {
        public SportsCar() { }

        public SportsCar(string name, short maxSpeed, short currentSpeed)
            : base(name, maxSpeed, currentSpeed)
        {
        }

        public override void Acceleration()
        {
            Console.WriteLine("SPORTCAR:  Ускоряется!");
        }
    }

    internal class SecretCar : Car
    {
        public override void Acceleration()
        {
            throw new NotImplementedException();
        }
    }
}
