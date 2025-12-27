using AdventOfCode.Helpers;
namespace AdventOfCode._2021
{
    internal class Day9() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        public void FirstStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            List<long> Points = new List<long>();

            for (int y = 0; y < Inputs.Count; y++)
            {
                for (int x = 0; x < Inputs[y].Length; x++)
                {
                    if (CheckSurrounding(Inputs, y, x, Int32.Parse(Inputs[y][x].ToString())))
                        Points.Add(Int32.Parse(Inputs[y][x].ToString()) + 1);
                }
            }
            Console.WriteLine(Points.Sum());
        }
        public void SecondStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            List<int> Points = new List<int>();
            var Visited = new bool[Inputs.Count, Inputs[0].Length];
            for (int y = 0; y < Inputs.Count; y++)
            {
                for (int x = 0; x < Inputs[y].Length; x++)
                {
                    if (CheckSurrounding(Inputs, y, x, Int32.Parse(Inputs[y][x].ToString())))                    
                        Points.Add(CheckBasin(Inputs, y, x, -1, Visited));                                         
                }
            }
            Console.WriteLine(Points
                .OrderByDescending(p => p)
                .Take(3)
                .Aggregate(1, (acc, cur) => acc * cur));
        }
        public int CheckBasin(List<string> Inputs, int y, int x, int find, bool[,] Visited)
        {
            if (y < 0 || y >= Inputs.Count || x < 0 || x >= Inputs[0].Length)
                return 0;
            int v = Inputs[y][x] - '0';
            if (v == 9)
                return 0;
            if (Visited[y, x])
                return 0;
            if (v < find)
                return 0;
            Visited[y, x] = true;
            return 1
            + CheckBasin(Inputs, y + 1, x, v, Visited)
            + CheckBasin(Inputs, y - 1, x, v, Visited)
            + CheckBasin(Inputs, y, x + 1, v, Visited)
            + CheckBasin(Inputs, y, x - 1, v, Visited);
        }
        public bool CheckSurrounding(List<string> Inputs, int y, int x, int find)
        {
            int[] sx = { -1, +1, 0, 0 };
            int[] sy = { 0, 0, -1, 1 };
            for (int i = 0; i < sx.Length; i++)
            {
                int newX = x + sx[i];
                int newY = y + sy[i];
                if (newX >= 0 && newX < Inputs[0].Length && newY >= 0 && newY < Inputs.Count)
                {
                    if (Int32.Parse(Inputs[newY][newX].ToString()) <= find)
                        return false;
                }
            }
            return true;
        }
    }
}
