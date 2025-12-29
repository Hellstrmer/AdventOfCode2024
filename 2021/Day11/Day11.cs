using AdventOfCode.Helpers;
namespace AdventOfCode._2021
{
    internal class Day11() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        int[,] _grid;
        int _width;
        int _height;
        public void FirstStar()
        {
            String[] Inputs = example ? ReadFileArr(Example) : ReadFileArr(Input);
            (_grid, _width, _height) = ReadgridInt(Inputs);
            bool[,] Flashed = new bool[_height, _width];
            int Steps = 0;
            int Flashes = 0;
            while (Steps < 100)
            {
                for (int y = 0; y < _height; y++)
                    for (int x = 0; x < _width; x++)
                        _grid[y, x]++;
                bool Changed = false;
                do
                {
                    Changed = searchFlashes(Flashed);
                } while (Changed);
                Flashes += UpdateAfterFlashes(Flashed);
                Steps++;
            }
            Console.WriteLine("Flashes: " + Flashes);
        }
        public void SecondStar()
        {
            String[] Inputs = example ? ReadFileArr(Example) : ReadFileArr(Input);
            (_grid, _width, _height) = ReadgridInt(Inputs);
            bool[,] Flashed = new bool[_height, _width];
            int Steps = 0;
            while (!FindAllFlashes())
            {
                for (int y = 0; y < _height; y++)
                    for (int x = 0; x < _width; x++)
                        _grid[y, x]++;
                bool Changed = false;
                do
                {
                    Changed = searchFlashes(Flashed);
                } while (Changed);
                int Flashes = UpdateAfterFlashes(Flashed);
                Steps++;
            }
            Console.WriteLine("Steps: " + Steps);
        }
        public bool searchFlashes(bool[,] Flashed)
        {
            bool Changed = false;
            for (int y = 0; y < _height; y++)            
                for (int x = 0; x < _width; x++)                
                    if (_grid[y, x] > 9 && !Flashed[y, x])
                    {
                        Flashed[y, x] = true;
                        Changed = true;
                        UpdateAdjacent(y, x);
                    }
            return Changed;
        }
        public void UpdateAdjacent(int y, int x)
        {
            int[] sx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] sy = { -1, 0, 1, -1, 1, -1, 0, 1 };
            for (int i = 0; i < sx.Length; i++)
            {
                int newX = x + sx[i];
                int newY = y + sy[i];
                if (newX >= 0 && newX < _width && newY >= 0 && newY < _height)
                    _grid[newY, newX]++;
            }
        }
        public int UpdateAfterFlashes(bool[,] Flashed)
        {
            int Flashes = 0;
            for (int y = 0; y < _height; y++)            
                for (int x = 0; x < _width; x++)                
                    if (Flashed[y, x])
                    {
                        Flashes++;
                        Flashed[y, x] = false;
                        _grid[y, x] = 0;
                    }
            return Flashes;
        }
        public bool FindAllFlashes()
        {
            return _grid.Cast<int>().All(x => x == 0);
        }
    }
}
