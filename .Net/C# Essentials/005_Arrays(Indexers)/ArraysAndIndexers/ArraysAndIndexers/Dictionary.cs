using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndIndexers
{
    class Dictionary
    {
        private string[] wordRU = new string[5];
        private string[] wordEN = new string[5];
        private string[] wordUA = new string[5];

        public Dictionary()
        {
            wordRU[0] = "стол";     wordUA[0] = "стіл";     wordEN[0] = "table";
            wordRU[1] = "облако";   wordUA[1] = "хмара";    wordEN[1] = "cloud";
            wordRU[2] = "солнце";   wordUA[2] = "сонце";    wordEN[2] = "sun";
            wordRU[3] = "яблоко";   wordUA[3] = "яблуко";   wordEN[3] = "apple";
            wordRU[4] = "окно";     wordUA[4] = "вікно";    wordEN[4] = "window";
        }

        public string this[string index]
        {
            get
            {
                for (int i = 0; i < wordRU.Length; i++)
                    if (wordRU[i] == index)
                        return wordRU[i] + " - " + wordUA[i] + " - " + wordEN[i];

                return string.Format("{0} - нет перевода для этого слова.", index);
            }
        }

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < wordRU.Length)
                    return wordRU[index] + " - " + wordUA[index] + " - " + wordEN[index];
                else
                    return "Попытка обращения за пределы массива.";
            }
        }

        public string TranslateByRU(string index)
        {
            for (int i = 0; i < wordRU.Length; i++)
                if (wordRU[i] == index)
                    return wordRU[i] + " - " + wordUA[i] + " - " + wordEN[i];

            return string.Format("{0} - нет перевода для этого слова.", index);
        }
        public string TranslateByUA(string index)
        {
            for (int i = 0; i < wordUA.Length; i++)
                if (wordUA[i] == index)
                    return wordRU[i] + " - " + wordUA[i] + " - " + wordEN[i];

            return string.Format("{0} - нет перевода для этого слова.", index);
        }
        public string TranslateByEN(string index)
        {
            for (int i = 0; i < wordEN.Length; i++)
                if (wordEN[i] == index)
                    return wordRU[i] + " - " + wordUA[i] + " - " + wordEN[i];

            return string.Format("{0} - нет перевода для этого слова.", index);
        }
    }
}
