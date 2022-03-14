using System.IO;

namespace FileReader
{
    public class FileReader : IFileReader
    {
        public string[] GetLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
