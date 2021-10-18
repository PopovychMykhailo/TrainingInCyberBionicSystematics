using System.IO;
using System.IO.Compression;

// Сжатие файлов.

namespace DEFLATE
{
    class Program
    {
        static void Main()
        {
            FileStream source = File.OpenRead(@"D:\test.txt");
            FileStream destination = File.Create(@"D:\archive.dfl");

            DeflateStream compressor = new DeflateStream(destination, CompressionMode.Compress);
        
            int theByte = source.ReadByte();
            while (theByte != -1)
            {
                compressor.WriteByte((byte)theByte);
                theByte = source.ReadByte();
            }

            compressor.Close();
        }
    }
}
