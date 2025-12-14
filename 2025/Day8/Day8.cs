using AdventOfCode.Helpers;
using System.Drawing;
namespace AdventOfCode._2025
{
    internal class Day7() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = true;
        private int _width;
        private int _height;
        private char[,] _grid;
        private char Find = '^';
        private char Update = '|';
        int[] PossibleDirections = { -1, 1 };
        List<Point> Points = new List<Point>();
        int results = 0;
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

        public void SecondStar()
        {
            int res = 0;
            String[] Inputs = example ? ReadFileArr(Example) : ReadFileArr(Input);
            (_grid, _width, _height) = Readgrid(Inputs);
            for (int y = 1; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_grid?[y, x] == Find)
                    {                            
                        FoundEnd(y, x);
                        break;
                    }                                              
                }
            }
            Console.WriteLine(results);
        }

        //public void FoundEnd(int yStart, int xStart) 
        //{
        //    int y = yStart + 2;       
                
        //    foreach(var dir in PossibleDirections)
        //        {                    
        //        int xPos = xStart + dir;                    
        //        if (y >= _height -1)                    
        //        {                        
        //            results++;                        
        //            return;                    
        //        }                    
        //        if (_grid[y, xPos] == Find && !Points.Contains(new Point(y, xPos)))        
        //        {                        
        //            Points.Add(new Point(y, xPos));
        //            FoundEnd(y, xPos);                    
        //        }                
        //    }
        //}
        public void FoundEnd(int yStart, int xStart)
        {
            for (int y = yStart + 2; y < _height; y++)
            {
                foreach (var dir in PossibleDirections)
                {
                    int xPos = xStart + dir;
                    if (y == _height -1)
                    {
                        results++;
                        
                        //return;
                    }
                    if (y < _height -1 && _grid[y, xPos] == Find && !Points.Contains(new Point(y, xPos)))
                    {
                        Points.Add(new Point(y, xPos));
                        FoundEnd(y, xPos);
                    }
                }
            }
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
