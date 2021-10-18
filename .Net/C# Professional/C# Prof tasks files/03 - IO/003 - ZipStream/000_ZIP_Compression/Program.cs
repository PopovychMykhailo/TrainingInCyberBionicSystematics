using System.IO;
using System.IO.Compression;

// Сжатие файлов.

namespace ZIP
{
	class Program
	{
		static void Main()
		{
			// Создание файла и архива.
			FileStream source = File.OpenRead(@"D:\test.txt");
			FileStream destination = File.Create(@"D:\archive.zip");

			// Создание компрессора.
			GZipStream compressor = new GZipStream(destination, CompressionMode.Compress);

			// Заполнение архива информацией из файла.
			int theByte = source.ReadByte();
			while (theByte != -1)
			{
				compressor.WriteByte((byte)theByte);
				theByte = source.ReadByte();
			}

			// Удаление компрессора.
			compressor.Close();
		}
	}
}
