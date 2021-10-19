using System;
using System.Collections;

namespace Homework_task4
{
    /* Technical task
    
        Создайте коллекцию, в которую можно записывать два значения одного слова, по типу русско-англо-украинский словарь. 
        И в ней можно для украинского слова найти либо только русское значение, либо только английское и вывести его на экран.
    */



    class CollectionWords : ICollection
    {
        MeaningWord[] array;

        public int Count { get => array.Length; }
        public bool IsSynchronized => false;
        public object SyncRoot => null;

        public CollectionWords()
        {
            array = Array.Empty<MeaningWord>();
        }

        public void Add(MeaningWord word)
        {
            MeaningWord[] newArray = new MeaningWord[array.Length + 1];
            array.CopyTo(newArray, 0);

            newArray[^1] = word;

            array = newArray;
        }
        public MeaningWord GetTranslation(string request, Languege language)
        {
            if (language == Languege.English)
            {
                for (int i = 0; i < array.Length; i++)
                    if (request == array[i].English)
                        return array[i];

                throw new Exception("No the word in the collection");
            }
            else if (language == Languege.Ukrainian)
            {
                for (int i = 0; i < array.Length; i++)
                    if (request == array[i].Ukrainian)
                        return array[i];

                throw new Exception("No the word in the collection");
            }
            else if (language == Languege.Russian)
            {
                for (int i = 0; i < array.Length; i++)
                    if (request == array[i].Russian)
                        return array[i];

                throw new Exception("No the word in the collection");
            }
            else
            {
                throw new Exception("Unknown language!");
            }
        }
        public string TranslateFromUkrainianToEnglish(string request)
        {
            return GetTranslation(request, Languege.Ukrainian).English;
        }
        public string TranslateFromUkrainianToRussian(string request)
        {
            return GetTranslation(request, Languege.Ukrainian).Russian;
        }

        public void CopyTo(Array array, int index)
        {
            this.array.CopyTo(array, index);
        }
        public IEnumerator GetEnumerator()
        {
            return (array as IEnumerable).GetEnumerator();
        }
    }

    enum Languege
    {
        English,
        Ukrainian,
        Russian
    }

    class MeaningWord
    {
        public string English { init; get; }
        public string Ukrainian { init; get; }
        public string Russian { init; get; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            CollectionWords collectionWords = new CollectionWords();
            collectionWords.Add(new MeaningWord { English = "Sun", Ukrainian = "Сонце", Russian = "Солнце" });
            collectionWords.Add(new MeaningWord { English = "Monitor", Ukrainian = "Екран", Russian = "Экран" });
            collectionWords.Add(new MeaningWord { English = "Mouse", Ukrainian = "Миша", Russian = "Мышь" });
            collectionWords.Add(new MeaningWord { English = "Keyboard", Ukrainian = "Клавіатура", Russian = "Клавиатура" });
            collectionWords.Add(new MeaningWord { English = "Watch", Ukrainian = "Годиник", Russian = "Часы" });

            Console.WriteLine("Translate Ukrainian to English");
            foreach (MeaningWord item in collectionWords)
            {
                Console.WriteLine($"{item.Ukrainian,-15} -> {collectionWords.TranslateFromUkrainianToEnglish(item.Ukrainian)}");
            }
            Console.WriteLine();

            Console.WriteLine("Translate Ukrainian to Russian");
            foreach (MeaningWord item in collectionWords)
            {
                Console.WriteLine($"{item.Ukrainian,-15} -> {collectionWords.TranslateFromUkrainianToRussian(item.Ukrainian)}");
            }
            Console.WriteLine();

        }
    }
}
