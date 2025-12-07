using AdventOfCode.Helpers;
namespace AdventOfCode._2025
{
    internal class Day7() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        private int _width;
        private int _height;
        private char[,] _grid;
        private char Find = '^';
        private char Update = '|';
        public void FirstStar()
        {           
            int res = 0;
            String[] Inputs = example ? ReadFileArr(Example) : ReadFileArr(Input);
            (_grid, _width, _height) = Readgrid(Inputs);
            for (int y = 1; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_grid?[y, x] == Find)
                        res += FoundMatch(y, x);
                }
            }
            Console.WriteLine(res);
        }            
        public int FoundMatch(int yRes, int x)
        {
            int y = yRes - 2;
            if (_grid[y, x] == Update || _grid[y, x] == 'S')
            {
                _grid[yRes, x - 1] = Update;
                _grid[yRes, x + 1] = Update;
                _grid[yRes + 1, x - 1] = Update;
                _grid[yRes + 1, x + 1] = Update;
                for (int i = 0; i < _width; i++)
                {
                    if (_grid[yRes - 1, i] == Update && _grid[yRes, i] != Find)
                    {
                        _grid[yRes, i] = Update;
                        _grid[yRes + 1, i] = Update;
                    }
                }
                return 1;
            }            
            return 0;
        }      
    }
}
