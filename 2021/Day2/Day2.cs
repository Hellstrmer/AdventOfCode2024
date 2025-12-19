using AdventOfCode.Helpers;

namespace AdventOfCode._2021
{
    internal class Day2() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;

        public void FirstStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            int res = 0;
            var Inp = Inputs
                .Where(s => s.Contains(' '))
                .Select(s => s.Split(' '))
                .Select(d => (Dir: d[0], Distance:  Int32.Parse(d[1])))
                .ToList();
            int Horizontal = 0;
            int Depth = 0;
            int Aim = 0;
            foreach (var d in Inp)
            {
                if (d.Dir == "forward")
                    Horizontal += d.Distance;
                else if (d.Dir == "down")
                    Depth += d.Distance;            
                else
                    Depth -= d.Distance;
            }
            Console.WriteLine(Horizontal * Depth);
        }
        public void SecondStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            int res = 0;
            var Inp = Inputs
                .Where(s => s.Contains(' '))
                .Select(s => s.Split(' '))
                .Select(d => (Dir: d[0], Distance: Int32.Parse(d[1])))
                .ToList();
            int Horizontal = 0;
            int Depth = 0;
            int Aim = 0;
            foreach (var d in Inp)
            {
                if (d.Dir == "forward")
                {
                    Horizontal += d.Distance;
                    Depth += Aim * d.Distance;
                }
                else if (d.Dir == "down")
                {
                    //Depth += d.Distance;
                    Aim += d.Distance;
                }
                else
                {
                    //Depth -= d.Distance;
                    Aim -= d.Distance;
                }
            }
            Console.WriteLine(Horizontal * Depth);
        }
    }
}
