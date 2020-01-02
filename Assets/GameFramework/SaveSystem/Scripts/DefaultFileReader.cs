using MyCompany.GameFramework.SaveSystem.Interfaces;
using System.IO;

namespace MyCompany.GameFramework.SaveSystem
{
    public class DefaultFileReader : IFileReader
    {
        public byte[] Read(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            else
            {
                return null;
            }
        }
    }
}
