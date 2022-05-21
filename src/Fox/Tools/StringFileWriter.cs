using Fox.Tools.Interfaces;
using System.IO;

namespace Fox.Tools
{
    public class StringFileWriter : IStringFileWriter
    {
        public void Write(string text, string outputPath)
        {
            StreamWriter sw;
            
            if (!File.Exists(outputPath))
            {
                sw = File.CreateText(outputPath);
            }
            else
            {
                sw = new StreamWriter(outputPath, true);
            }

            sw.Write(text);
            sw.Close();
        }
    }
}
