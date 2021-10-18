using Newtonsoft.Json;
using System;

namespace _006_JSON
{
    // Класс Radio будет доступен для сериализации.
    public class Radio
    {
        private int id = 9;

        // Метод включения/выключения радио.
        public void OnOff(bool state)
        {
            if (state == true)
                Console.WriteLine("Радио Включено.");
            else
                Console.WriteLine("Радио Выключено.");
        }
    }
}
