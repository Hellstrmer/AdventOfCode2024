using AdventOfCode.Helpers;
namespace AdventOfCode._2021
{
    internal class Day12() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = true;
        public void FirstStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            List<(string Start, string End)> Paths = Inputs
                .Where(s => s.Contains('-'))
                .Select(s => s.Split('-'))
                .Select((p => (Start: p[0], End: p[1])))
                .ToList();



            Console.WriteLine("Flashes: ");
        }
        public void SecondStar()
        {

        }
    }
}
