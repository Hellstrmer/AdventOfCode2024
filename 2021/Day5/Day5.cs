using AdventOfCode.Helpers;
namespace AdventOfCode._2021
{
    internal class Day5() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        public char[,] _grid;
        public int _width;
        public int _height;
        public void FirstStar()
        {
            List<(int X1, int Y1, int X2, int Y2)> inp = ParseInput();
            int res = 0;
            (_grid, _width, _height) = BuildGrid(inp);
            foreach (var input in inp)
            {
                var character = 0;
                if (input.X1 == input.X2)
                {
                    int start = input.Y1 > input.Y2 ? input.Y2 : input.Y1;
                    int end = input.Y1 > input.Y2 ? input.Y1 : input.Y2;
                    for (int i = start; i <= end; i++)
                    {
                        character = Int32.Parse(_grid[i, input.X1].ToString()) + 1;
                        _grid[i, input.X1] = character.ToString()[0];
                    }
                }
                else if (input.Y1 == input.Y2)
                {
                    int start = input.X1 > input.X2 ? input.X2 : input.X1;
                    int end = input.X1 > input.X2 ? input.X1 : input.X2;
                    for (int i = start; i <= end; i++)
                    {
                        character = Int32.Parse(_grid[input.Y1, i].ToString()) + 1;
                        _grid[input.Y1, i] = character.ToString()[0];
                    }
                }
            }
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    if (Int32.Parse(_grid[y, x].ToString()) >= 2)
                        res++;
                }
            }
            Console.WriteLine(res);
        }
        public void SecondStar()
        {
            List<(int X1, int Y1, int X2, int Y2)> inp = ParseInput();
            int res = 0;
            (_grid, _width, _height) = BuildGrid(inp);
            foreach (var input in inp)
            {
                var character = 0;
                if (input.X1 == input.X2)
                {
                    int start = input.Y1 > input.Y2 ? input.Y2 : input.Y1;
                    int end = input.Y1 > input.Y2 ? input.Y1 : input.Y2;
                    for (int i = start; i <= end; i++)
                    {
                        character = Int32.Parse(_grid[i, input.X1].ToString()) + 1;
                        _grid[i, input.X1] = character.ToString()[0];
                    }
                }
                else if (input.Y1 == input.Y2)
                {
                    int start = input.X1 > input.X2 ? input.X2 : input.X1;
                    int end = input.X1 > input.X2 ? input.X1 : input.X2;
                    for (int i = start; i <= end; i++)
                    {
                        character = Int32.Parse(_grid[input.Y1, i].ToString()) + 1;
                        _grid[input.Y1, i] = character.ToString()[0];
                    }
                }

            }
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    if (Int32.Parse(_grid[y, x].ToString()) >= 2)
                        res++;
                }
            }
            Console.WriteLine(res);

        }

        public List<(int X1, int Y1, int X2, int Y2)> ParseInput()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            int res = 0;
            List<(int X1, int Y1, int X2, int Y2)> inp = Inputs
                .Select(s => s.Replace(">", "")
                .Split(',', '-'))
                .Select(Coordinates => (X1: Int32.Parse(Coordinates[0]), Y1: Int32.Parse(Coordinates[1]), X2: Int32.Parse(Coordinates[2]), Y2: Int32.Parse(Coordinates[3])))
                .ToList();

            return inp;
        }

        public (char[,] grid, int width, int height) BuildGrid(List<(int X1, int Y1, int X2, int Y2)> Inputs)
        {
            char[,]? grid; 
            int width = Math.Max(Inputs.Max(i => i.X1), Inputs.Max(i => i.X2)) + 1;
            int height = Math.Max(Inputs.Max(i => i.Y1), Inputs.Max(i => i.Y2)) + 1;
            grid = new char[height, width];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)                
                    grid[y, x] = '0';                
            }
            return (grid, width, height);
        }


    }
}

