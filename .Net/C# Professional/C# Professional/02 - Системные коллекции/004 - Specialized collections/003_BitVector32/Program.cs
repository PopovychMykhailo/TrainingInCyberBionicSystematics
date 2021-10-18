using System;
using System.Collections.Specialized;
using System.Text;

namespace BitVector32Dimo3
{
	class Program
	{
		static void Main()
		{
			Console.OutputEncoding = Encoding.Unicode;

			var vector = new BitVector32(0);

			int firstBit = BitVector32.CreateMask();           // ... 0000 0001 B - 1D
			int secondBit = BitVector32.CreateMask(firstBit);  // ... 0000 0010 B - 2D
			int thirdBit = BitVector32.CreateMask(secondBit);  // ... 0000 0100 B - 4D
			Console.WriteLine(firstBit + " " + secondBit + " " + thirdBit); // Test

			vector[firstBit] = true;
			vector[secondBit] = true;

			Console.WriteLine("{0} должно быть 3", vector.Data);
			Console.WriteLine(vector.ToString());

			var newVector = new BitVector32(4);
			Console.WriteLine(newVector);

			bool bit1 = newVector[firstBit];
			bool bit2 = newVector[secondBit];
			bool bit3 = newVector[thirdBit];

			Console.WriteLine("bit1 = {0}, bit2 = {1}, bit3 = {2}", bit1, bit2, bit3);

			// Delay.
			Console.ReadKey();
		}
	}
}
