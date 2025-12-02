using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventOfCode.Helpers
{
    public class HelperClass
    {
        
        public List<string> ReadFileList(string name, [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "")
        {
            string dayFolder = Path.GetDirectoryName(sourceFilePath);
            string file = Path.Combine(dayFolder, name);
            string input = File.ReadAllText(file.Trim());
            List<string> inputs = input.Split("\r\n").ToList();
            return inputs;
        }
        public string ReadFileString(string name, [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "")
        {
            string dayFolder = Path.GetDirectoryName(sourceFilePath);
            string file = Path.Combine(dayFolder, name);
            string input = File.ReadAllText(file.Trim());
            return input;
        }
    }
}
