using System;

// Библиотека кода — CarLibrary.dll

namespace CarLibrary
{
    public abstract class Car : ICar
    {
        protected string name;
        protected short currentSpeed;
        protected short maxSpeed;
        protected EngineState state;

        protected Car()
        {
            state = EngineState.EngineAlive;
        }

        protected Car(string name, short maxSpeed, short currentSpeed)
            : this()
        {
            this.name = name;
            this.maxSpeed = maxSpeed;
            this.currentSpeed = currentSpeed;
        }

        public abstract void Acceleration();

        public void Driver(string name, int age)
        {
            Console.WriteLine("Имя водителя: {0}. Возраст: {1}", name, age);
        }

        #region Свойства

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public short CurrentSpeed
        {
            get { return currentSpeed; }
            set { currentSpeed = value; }
        }

        public short MaxSpeed
        {
            get { return maxSpeed; }
        }

        public EngineState EngineState
        {
            get { return state; }
        }

        #endregion
    }
}
