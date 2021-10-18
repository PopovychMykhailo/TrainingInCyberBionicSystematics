using System;
using System.Collections.Specialized;

namespace StringDictionaryDemo
{
	class Program
	{
		static void Main()
		{
			var dict = new StringDictionary();

			dict["First"] = "1st";
			dict["Second"] = "2nd";
			dict["Third"] = "3rd";
			dict["Fourth"] = "4th";
			dict["fourth"] = "fourth";

			//dict[50] = "fifty";      <--     Ошибка компиляции - это не строка.
		    Console.WriteLine(dict.Count);
		    
			string converted = dict["Second"];
			// Приведение типов не требуется.

			converted = dict["FIRST"];
			// Ключи нечувствительны к регистру. Поэтому "FIRST" и "First" - эквивалентны.

			Console.WriteLine(converted + " " + dict.Count);

			// Delay.
			Console.ReadKey();
		}
	}
}
