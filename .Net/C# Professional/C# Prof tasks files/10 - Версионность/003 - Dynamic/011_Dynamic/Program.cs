using System;

// dynamic

namespace Dynamic
{
	class Base<T>
	{
		public T Value { get; set; }
	}

	class Derived : Base<dynamic>
	{

	}

	class Program
	{
		static void Main()
		{
			//Derived instance = new Derived();
		    var instance = new Base<dynamic>
		                       {
		                           Value = "Some string..."
		                       };


		    Console.WriteLine(instance.GetType());

			// Delay.
			Console.ReadKey();
		}
	}
}
