using AdventOfCode.Helpers;

namespace AdventOfCode._2021
{
    internal class Day1() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;

        public void FirstStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);

            var res = Inputs
                .Select(s => Int32.Parse(s))
                .Zip(Inputs.Select(s => Int32.Parse(s))
                .Skip(1), (c, n) => n > c)
                .Count(inc => inc);
                
            Console.WriteLine(res);
        }
        public void SecondStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            int res = 0;            
            for (int i = 0; i < Inputs.Count - 3; i++)
            {
                int f = Int32.Parse(Inputs[i]) + Int32.Parse(Inputs[i + 1]) + Int32.Parse(Inputs[i + 2]);
                int s = Int32.Parse(Inputs[i + 1]) + Int32.Parse(Inputs[i + 2]) + Int32.Parse(Inputs[i + 3]);
                if (s > f)                
                    res++;                
            }
            Console.WriteLine(res);
        }
    }
}
