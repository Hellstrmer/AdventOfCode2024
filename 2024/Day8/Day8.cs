namespace AdventOfCode._2024
{
    internal class Day8
    {
        public List<string> ReadFile()
        {
            bool example = true;
            string input = File.ReadAllText(example
                ? "C:\\Users\\jespe\\Source\\Repos\\Hellstrmer\\AdventOfCode2024\\2024\\Day8\\Example.txt".Trim()
                : "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day7\\Input.txt").Trim();
            List<string> Inputs = input.Split("\r\n").ToList();
            return Inputs;
        }
        public void FirstStar()
        {
            List<string> Inputs = ReadFile();
            List<int> First = new List<int>();
            List<int> Second = new List<int>();
            List<int> PathX = new List<int>();
            List<int> PathY = new List<int>();
            int ResultInt = 0;
            bool ResultDone = false;

            for (int x = 0; x < Inputs.Count; x++)
            {
                Console.WriteLine("Inputs!" + Inputs[x]);
                for (int y = 0; y < Inputs[x].Length; y++)
                {
                    //Console.WriteLine("Inputs!" + Inputs[x]);
                    if (Inputs[x][y].ToString() == "^")
                    {;
                        
                        return;
                    }
                }
            }

            Console.WriteLine("Numbers: " + ResultInt);
        }

        public bool ControlNumbs(ulong CheckNumb, List<ulong> Path, int MathVersion)
        {
            var comb = Combinations(Path);
            foreach(var ops in comb)
            {
                    ulong test = Evaluate(ops, Path, CheckNumb);
                    if (Evaluate(ops, Path, CheckNumb) == CheckNumb)
                    {
                        return true;
                    }          
            }
            return false;
        }

        private ulong Evaluate(List<MathMethod> ops, List<ulong> Path, ulong CheckNumb)
        {
            var result = Path[0];
            for (int i = 0; i < ops.Count; i++) 
            {
                result = ops[i] switch
                {
                    MathMethod.Add => result + Path[i + 1],
                    MathMethod.Multiply => result * Path[i + 1]
                };
            }
            return result;
        }
        private IEnumerable <List<MathMethod>> Combinations(List<ulong> Path)
        {
            var OPCount = Path.Count - 1;
            var States = 2;
            var CombinationCount = (int)Math.Pow(States, OPCount);

            for (int i = 0; i < CombinationCount; i++)
            {
                var combination = new List<MathMethod>();
                var Value = i;

                for (int pos = 0; pos < OPCount; pos++)
                {
                    var op = (Value % States) switch
                    {
                        0 => MathMethod.Add,
                        1 => MathMethod.Multiply
                    };
                    combination.Add(op);
                    Value /= States;
                }
                yield return combination;
            }
        }

        private enum MathMethod
        {
            Add,
            Multiply
        }        
    }
}

