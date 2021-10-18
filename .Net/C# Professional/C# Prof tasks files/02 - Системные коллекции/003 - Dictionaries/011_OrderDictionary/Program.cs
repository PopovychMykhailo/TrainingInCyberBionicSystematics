using System;
using System.Collections;
using System.Collections.Specialized;

// OrderedDictionary - Размещение элементов соответствует порядку их добавления в коллекцию, 
// что позволяет автоматически сохранять элементы в хронологическом порядке. 

namespace OrderDictionaryDemo
{
	class Program
	{
		static void Main()
		{
			var emailLookup = new OrderedDictionary
			                      {
			                          {"sbishop@contoso.com", "Bishop, Scott"},
			                          {"chess@contoso.com", "Hell, Christian"},
			                          {"djump@contoso.com", "Jump, Dan"}
			                      };

		    foreach (DictionaryEntry entry in emailLookup)
			{
				Console.WriteLine(entry.Value);
			}
            
			// Delay
			Console.ReadKey();
		}
	}
}
