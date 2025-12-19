using AdventOfCode.Helpers;
using System;
using System.Drawing;
namespace AdventOfCode._2025
{
    internal class Day9() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = true;
        private long _width;
        private long _height;
        private char[,] _grid;
        public void FirstStar()
        {
            long res = 0;
            var Inputs = ParseInput();
            res = (from line in  Inputs
                   from other in Inputs
                   let Width = (line.X - other.X) + 1
                   let Height = (line.Y - other.Y) + 1
                   select Math.Abs(Width * Height))
            .Max();        
            Console.WriteLine(res);
        }            

        //public void SecondStar()
        //{
        //    int res = 0;
        //    var Inputs = ParseInput();
        //    //_width = Inputs.OrderByDescending(x => x.X).First().X + 3;
        //    //_height = Inputs.OrderByDescending(x => x.Y).First().Y + 2;
        //    //Inputs = Inputs.OrderBy(x => x.Y).ToList();
        //    //_grid = new char[_height, _width];
        //    //var character = '.';

        //    //for (var y = 0; y < _height; y++)
        //    //{
        //    //    for (var x = 0; x < _width; x++)
        //    //    {
        //    //        if (Inputs.Any(inp => inp.Y == y && inp.X == x))
        //    //            character = '#';
        //    //        else
        //    //            character = '.';
        //    //        _grid[y, x] = character;
        //    //    }
        //    //}
        //    ShowGrid(_grid);
        //    Console.WriteLine(res);
        //}


        //..............
        //.......#...#..
        //..............
        //..#....#......
        //..............
        //..#......#....
        //..............
        //.........#.#..
        //..............
        public void SecondStar()
        {
            long res = 0;
            var Inputs = ParseInput();

            foreach (var line in Inputs)
            {
                for (int i = 0; i < Inputs.Count; i++)
                {
                    long Width = line.X - Inputs[i].X + 1;
                    long Height = line.Y - Inputs[i].Y + 1;
                    long Area = Width * Height;
                    if (Area > res && Inputs.Any(
                        inp => inp.Y < line.Y && 
                        inp.Y != line.Y && 
                        inp.X < line.X && 
                        inp.X != line.X))
                    {
                        res = Area;
                    }
                }                
            }
            Console.WriteLine(res);
        }

        public List<(int X, int Y)> ParseInput()
        {
            var Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            return Inputs
                .Where(s => s.Contains(','))
                .Select(s => s.Split(','))
                .Select(Coordinate => (X: int.Parse(Coordinate[0]), Y: int.Parse(Coordinate[1])))
                .ToList();
        }


    }
}
