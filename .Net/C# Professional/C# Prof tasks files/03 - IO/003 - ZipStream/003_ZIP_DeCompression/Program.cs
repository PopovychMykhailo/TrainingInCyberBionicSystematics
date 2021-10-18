using System.IO;
using System.IO.Compression;

// Восстановление из архива.

namespace ZIP_DeCompression
{
    class Program
    {
        static void Main()
        {
            FileStream source = File.OpenRead(@"D:\archive.zip");
            FileStream destination = File.Create(@"D:\text_zip.txt");

            GZipStream deCompressor = new GZipStream(source, CompressionMode.Decompress);

            int theByte = deCompressor.ReadByte();
            while (theByte != -1)
            {
                destination.WriteByte((byte)theByte);
                theByte = deCompressor.ReadByte();
            }

            deCompressor.Close();
        }
    }
}
