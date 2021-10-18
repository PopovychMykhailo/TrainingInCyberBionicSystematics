using Newtonsoft.Json;
using System;

namespace _006_JSON
{
    public class Mersedes : Car
    {
        [JsonProperty]
        // Два режима работы - Спорт и Люкс.
        protected Mode mode;

        public Mersedes(string name, int speed, Mode mode)
            : base(name, speed)
        {
            this.mode = mode;
        }

        public void SetMode(Mode mode)
        {
            this.mode = mode;
            Console.WriteLine(this.mode);
        }

        public void ShowMode()
        {
            Console.WriteLine(this.mode);
        }
    }
}
