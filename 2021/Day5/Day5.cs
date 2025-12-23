using AdventOfCode.Helpers;
using System.Drawing;
namespace AdventOfCode._2021
{
    internal class Day5() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = true;
        public void FirstStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);

            List<(int X1, int Y1, int X2, int Y2)> inp = Inputs
                .Select(s => s.Replace(">", "")
                .Split(',', '-'))
                .Select(Coordinates => (X1: Int32.Parse(Coordinates[0]), Y1: Int32.Parse(Coordinates[1]), X2: Int32.Parse(Coordinates[2]), Y2: Int32.Parse(Coordinates[3])))
                .ToList();

            Console.Write(inp[0].X1);
        }
        public void SecondStar()
        {

        }
    }
}

       