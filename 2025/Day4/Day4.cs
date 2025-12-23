using AdventOfCode.Helpers;
using System.Drawing;
namespace AdventOfCode._2025
{
    internal class Day4() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        private int _width;
        private int _height;
        private char[,]? _grid;
        private char find = '@';
        private List<Point> changePoints = new List<Point>();  

        public void FirstStar()
        {
            Solution(false);
        }
        public void SecondStar()
        {
            Solution(true);            
        }
        public void Read()
        {
            String[] Inputs = example ? ReadFileArr(Example) : ReadFileArr(Input);
            (_grid,_width, _height) = Readgrid(Inputs);
        }
        public void Solution(bool searchAll)
        {
            Read();
            Point FoundPoint;
            int adjacent = 0;
            int res = 0;
            int lastState = 99;
            while (lastState != res)
            {
                changePoints.Clear();
                lastState = res;
                for (int y = 0; y < _height; y++)
                {
                    for (int x = 0; x < _width; x++)
                    {
                        if (_grid?[y, x] == find)
                        {
                            FoundPoint = new Point(x, y);
                            adjacent = CheckSurrounding(FoundPoint);
                            if (adjacent < 4)
                            {
                                changePoints.Add(FoundPoint);
                                res++;
                            }
                        }
                    }
                }
                updateInterface(changePoints);
                if (!searchAll) { break; }
            }
            Console.WriteLine(res);
        }
        public int CheckSurrounding(Point point)
        {
            int[] sx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] sy = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int res = 0;            
            for (int i = 0; i < sx.Length; i++)
            {
                int newX = point.X + sx[i];
                int newY = point.Y + sy[i];
                if (newX >= 0 && newX < _width && newY >= 0 && newY < _height)                
                    if (_grid?[newY, newX] == find)                    
                        res++;                           
            }
            return res;
        }  
        public void updateInterface(List<Point> UpdatePoints)
        {
            foreach (Point p in UpdatePoints)
            {
                _grid[p.Y, p.X] = '.';
            }
        }
    }
}
