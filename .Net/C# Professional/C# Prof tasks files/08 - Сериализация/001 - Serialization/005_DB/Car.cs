using System;

namespace SerialDataBase
{
    [Serializable]
    public class Car
    {
        public string name, make, color;

        public Car(string name, string make, string color)
        {
            this.name = name;
            this.color = color;
            this.make = make;
        }
    }
}
