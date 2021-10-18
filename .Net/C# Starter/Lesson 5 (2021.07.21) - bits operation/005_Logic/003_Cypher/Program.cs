using System;
using System.Text;

// Побитовые логические операции. (^)

// Например: 
// Используя операцию XOR, мы можем зашифровать сообщение.
// В таком виде шифрования используется один ключ, как для шифрования, так и для расшифровки.
// Криптостойкость такого ключа, можно увеличить, если увеличить его длину.

namespace Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            ushort secretKey = 0x0088; // Секретный ключ (длина - 16 bit).
            char character = 'A';      // Исходный символ для шифрования.

            Console.WriteLine($"Исходный символ: {character}, его код в кодовой таблице: {(byte)character:X}");
            Console.WriteLine($"Размер символа: {character} = {sizeof(char) * 8} бит");

            // Зашифровываем символ.
            character = (char)(character ^ secretKey);
            Console.WriteLine($"Зашифрованный символ: {character}, его код в кодовой таблице: {(byte)character:X}");

            // Расшифровываем символ.
            character = (char)(character ^ secretKey);
            Console.WriteLine($"Расшифрованный символ: {character}, его код в кодовой таблице: {(byte)character:X}");

            // Delay.
            Console.ReadKey();
        }
    }
}
