using System;

namespace SerializableWork
{
    // Класс Radio будет доступен для сериализации.
    [Serializable]
    public class Radio
    {
        [NonSerialized]
        private int id = 9;
        
        // Метод включения/выключения радио.
        public void OnOff(bool state)
        {
            Console.WriteLine(state ? "Радио Включено." : "Радио Выключено.");
        }
    }
}
