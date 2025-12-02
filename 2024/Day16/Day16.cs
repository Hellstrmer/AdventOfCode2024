using System.Drawing;

namespace AdventOfCode._2024
{
    internal class Day16
    {
        private int _width;
        private int _height;
        private char[,] _grid;
        public void ReadFile()
        {
            //Reading out a grid
            bool example = true;
            string[] input = File.ReadAllLines(example
                ? "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day16\\Example.txt"
                : "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day16\\Input.txt");

            _width = input[0].Length;
            _height = input.Length;
            _grid = new char[_height, _width]; 
            for (var y = 0; y < _height; y++) 
            {
                var line = input[y];
                for (var x = 0; x < _width; x++)
                {
                    var character = line[x];
                    _grid[y, x] = character;
                }
            }
        }
        public void FirstStar()
        {
            ReadFile();
            Point FoundPoint;
            char FoundChar;
            int Score = 0;
            HashSet<Point> markedPoints = new HashSet<Point>();
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_grid[x, y] == 'S')
                    {
                        FoundPoint = new Point(x, y);
                        FoundChar = _grid[x, y];
                        Score = FindE(FoundPoint, Score, 0, markedPoints);
                    }                    
                }
                if (y == _height - 1)
                {
                    for (int row = 0; row < _grid.GetLength(0); row++)
                    {
                        for (int col = 0; col < _grid.GetLength(1); col++)
                        {
                            Console.Write(_grid[row, col]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Antinode: " + Score);
                }
            }
        }
       

        private int FindE(Point Latest, int Score, int Direction, HashSet<Point> markedPoints)
        {

            int Temporary = 1;
            int Permanent = 2;
            int NIL = -1;
            int Infinity = 999999;

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {

                    List<Point> points = new List<Point>();
                    Point Current = new Point(x, y);
                    points = PossibleDirections(Latest, Direction, markedPoints);
                    foreach(Point p in points)
                    {
                        if (_grid[p.X, p.Y] == 'E')
                        {
                            return Score;
                        }

                        //markedPoints.Add(p);
                        int Found = Find(p, Score, 0);
                        
                    } 
                }
            }
            return Score;
        }
        private int Find(Point Latest, int Score, int Direction)
        {
            if (Direction == 0)
            {


            }
            return Score;
        }

        private List <Point> PossibleDirections(Point Current, int Direction, HashSet<Point> markedPoints)
        {
            List<Point> PossibleDirection = new List<Point>();
            if (_grid[Current.X, Current.Y + 1] != '#')
            {

                PossibleDirection.Add(new Point(Current.X, Current.Y + 1));
            }
            if (_grid[Current.X, Current.Y -1] != '#')
            {
                PossibleDirection.Add(new Point(Current.X, Current.Y - 1));
            }
            if (_grid[Current.X +1, Current.Y] != '#')
            {
                PossibleDirection.Add(new Point(Current.X + 1, Current.Y));
            }
            if (_grid[Current.X - 1, Current.Y] != '#' )
            {
                PossibleDirection.Add(new Point(Current.X - 1, Current.Y));
            }
            return PossibleDirection;
        }
       
    }
    
    class AddValues
    {
        List<Point> Points = new List<Point>();
        int Score = 0;
        int Direction = 0;
    }
}

