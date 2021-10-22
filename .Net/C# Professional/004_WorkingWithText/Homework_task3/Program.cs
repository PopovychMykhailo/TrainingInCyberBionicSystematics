using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework_task3
{
    /* Technical task
    
        Напишите шуточную программу «Дешифратор», которая бы в текстовом файле могла бы
        заменить все предлоги на слово «ГАВ!»
    */


    class Program
    {
        public static object MathColection { get; private set; }

        static void Main()
        {
            string pathFile = "Text.txt";
            StreamReader streamReader = new(new FileStream(pathFile, FileMode.OpenOrCreate, FileAccess.Read));
            StringBuilder text = new(streamReader.ReadToEnd().ToLower());
            streamReader.Close();

            string pattern = @"the|can";
            string substitute = "Gav";

            MatchCollection matchCollection = Regex.Matches(text.ToString(), pattern);

            foreach (Match match in matchCollection)
            {
                text.Remove(match.Index, match.Groups[0].Value.Length);
                text.Insert(match.Index, substitute);
            }

            StreamWriter streamWriter = new(new FileStream(pathFile, FileMode.OpenOrCreate, FileAccess.Write));
            streamWriter.Write(text);
            streamWriter.Close();
        }
    }
}
