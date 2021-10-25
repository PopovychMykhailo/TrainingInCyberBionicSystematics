using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermometerLibrary
{
    /* Technical task
    
        Создайте свою пользовательскую сборку по примеру сборки CarLibrary из урока, сборка будет
        использоваться для работы с конвертером температуры.
    */

    internal interface IThermometer
    {
        public decimal ConvertCelsiusToFahrenheit();
        public decimal ConvertFahrengeitToCelsius();
    }
}
