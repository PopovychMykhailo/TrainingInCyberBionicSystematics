using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermometerLibrary
{
    class Thermometer : IThermometer
    {
        decimal temperature;

        public decimal Temperature
        {
            set => temperature = value;
            get => temperature;
        }

        public Thermometer(decimal celsiusTemperature)
        {
            temperature = celsiusTemperature;
        }

        public Thermometer()
        {
            temperature = 30;
        }

        public decimal ConvertCelsiusToFahrenheit()
        {
            temperature = (temperature * 9 / 5) + 32;
            return temperature;
        }

        public decimal ConvertFahrengeitToCelsius()
        {
            temperature = (temperature - 32) / 9 * 5;
            return temperature;
        }
    }
}
