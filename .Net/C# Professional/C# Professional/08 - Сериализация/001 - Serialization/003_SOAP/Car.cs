using System;

namespace SerializableWork
{
    // Класс Car будет доступен для сериализации.
    [Serializable]
    public class Car
    {
        protected int speed;
        protected string name;
        protected Radio radio;

        public Car(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
            radio = new Radio();
        }

        // Метод включения/выключения радио.
        public void TurnOnRadio(bool state)
        {
            this.radio.OnOff(state);
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
