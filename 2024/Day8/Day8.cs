using System.Drawing;

namespace AdventOfCode._2024
{
    internal class Day8
    {
        private int _width;
        private int _height;
        private char[,] _grid;
        public void ReadFile()
        {
            //Reading out a grid
            bool example = true;
            string[] input = File.ReadAllLines(example
                ? "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day8\\Example.txt"
                : "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day8\\Input.txt");

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
            int Antinode = 0;
            HashSet<Point> markedPoints = new HashSet<Point>();
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_grid[x, y] != '.' && _grid[x, y] != '#')
                    {
                        FoundPoint = new Point(x, y);
                        FoundChar = _grid[x, y];
                        Antinode = FindNextPoint(FoundPoint, FoundChar, Antinode, markedPoints);
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
                    Console.WriteLine("Antinode: " + Antinode);
                }
            }
        }

        private int FindNextPoint(Point Latest, char LatestChar, int Antinode, HashSet<Point> markedPoints)
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    Point Current = new Point(x, y);
                    if (_grid[x, y] == LatestChar && !Current.Equals(Latest))
                    {
                        List<Point> Points = new List<Point>();
                        Points.Add(new Point(Latest.X - (x - Latest.X), Latest.Y - (y - Latest.Y)));
                        Points.Add(new Point(x + (x - Latest.X), y + (y - Latest.Y)));
                        foreach(Point p in Points)
                        {
                            if (!OutOfBound(p) && _grid[p.X, p.Y] != '#' && !markedPoints.Contains(p))
                            {
                                if (_grid[p.X, p.Y] == '.')
                                {
                                    _grid[p.X, p.Y] = '#';
                                }
                                markedPoints.Add(p);
                                Antinode++;
                            }
                        }
                    }
                }
            }
            return Antinode;
        }
        public void SecondStar()
        {
            ReadFile();
            Point FoundPoint;
            char FoundChar;
            int Antinode = 0;
            HashSet<Point> markedPoints = new HashSet<Point>();
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_grid[x, y] != '.' && _grid[x, y] != '#')
                    {
                        FoundPoint = new Point(x, y);
                        FoundChar = _grid[x, y];
                        Antinode = FindNextPoints(FoundPoint, FoundChar, Antinode, markedPoints);
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
                    Console.WriteLine("Antinode: " + Antinode);                    
                }
            }
        }
        private int FindNextPoints(Point Latest, char LatestChar, int Antinode, HashSet<Point> markedPoints)
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    Point Current = new Point(x, y);
                    if (_grid[x, y] == LatestChar && !Current.Equals(Latest))
                    {
                        List<Point> Points = new List<Point>();

                        Point DistanceBetween = new Point(x - Latest.X, y - Latest.Y);

                        List<Point> NewPoints = FindAllPoints(Latest, DistanceBetween);
                        foreach (Point p in NewPoints)
                        {
                            if (!OutOfBound(p) && _grid[p.X, p.Y] != '#' && !markedPoints.Contains(p))
                            {
                                if (_grid[p.X, p.Y] == '.')
                                {
                                    _grid[p.X, p.Y] = '#';
                                }                                 
                                markedPoints.Add(p);
                                Antinode++;                                
                            }
                        }
                    }
                }
            }
            return Antinode;
        }
        private List<Point> FindAllPoints(Point Latest, Point DistanceBetween)
        {
            List<Point> Points = new List<Point>();
            Point current = Latest;

            while (!OutOfBound(current))
            {
                Points.Add(current);
                current = new Point(current.X + DistanceBetween.X, current.Y + DistanceBetween.Y);
            }
            return Points;
        }        

        private bool OutOfBound(Point ControlPoint)
        {
            return ControlPoint.X > _width - 1 || ControlPoint.X < 0 || ControlPoint.Y > _height - 1 || ControlPoint.Y < 0; 
        }
    }
}

