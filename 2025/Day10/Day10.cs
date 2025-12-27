using AdventOfCode.Helpers;
using System.Text.RegularExpressions;
namespace AdventOfCode._2025
{
    internal class Day10() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = true;
        private long _width;
        private long _height;
        private char[,] _grid;
        public void FirstStar()
        {
            long res = 0;
            var Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            var IndicatorLights = Inputs
                .Where(s => s.Contains(']'))
                .Select(s => s.Split(']'))
                .Select(Indicator => Indicator[0].Substring(1))
                .ToArray();
            var Buttons = Inputs
                .Where(s => s.Contains('('))
                .Select(s => Regex.Matches(s, @"\([^)]+\)")
                .Cast<Match>()                
                .Select(m => m.Value.Trim('(', ')'))        
                .ToArray())            
                .ToArray();
            var Joltage = Inputs
                .Where(s => s.Contains('{'))
                .Select(s => Regex.Matches(s, @"\{[^)]+\}")
                .Cast<Match>()
                .Select(m => m.Value.Trim('{', '}'))
                .ToArray())
                .ToArray();

            foreach (var ind in IndicatorLights)
            {

            }

            Console.WriteLine(res);
        }            

        public void SecondStar()
        {
            long res = 0;

        }
    }
}
