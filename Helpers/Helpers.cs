using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Helpers
{
    public class HelperClass
    {
        public List<string> ReadFileList(string file)
        {
            string input = File.ReadAllText(file.Trim());
            List<string> inputs = input.Split("\r\n").ToList();
            return inputs;
        }
        public string ReadFileString(string file)
        {
            string input = File.ReadAllText(file.Trim());
            return input;
        }
    }
}
