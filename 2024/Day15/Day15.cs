using System.Drawing;
using System.Runtime.CompilerServices;

namespace AdventOfCode._2024
{
    internal class Day15
    {
        private int _width;
        private int _height;
        private char[,] _grid;
        private string Path;
        private List<Point> FoundPoints;
        public void ReadFile(bool part)
        {
            // 1442192
            // Part 2
            // 1448042 To Low
            // 1449042 to High
            bool example = true;
            string[] input = File.ReadAllLines(example
                ? "C:\\Users\\jespe\\Source\\Repos\\Hellstrmer\\AdventOfCode2024\\2024\\Day15\\Example.txt"
                : "C:\\Users\\jespe\\Source\\Repos\\Hellstrmer\\AdventOfCode2024\\2024\\Day15\\Input.txt");

            if (!part)
            {
                ReadFirst(input);
            } else
            {
                ReadSecond(input);
            }
        }
        public void ReadFirst(string[] input)
        {            
            _width = input[0].Length;
            int found = 0;
            int PathStartLine = 0;
            for (int j = 0; j < input.Length; j++)
            {
                {
                    for (int i = 0; i < input[j].Length; i++)
                    {
                        if (input[j][i] == '#' && j != 0)
                        {
                            found++;
                        }
                        else
                        {
                            found = 0;
                            break;
                        }
                        if (found == input[j].Length - 1)
                        {
                            _height = j + 1;
                            PathStartLine = j + 2;
                            break;
                        }
                    }
                }
            }
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
            for (int i = PathStartLine; i < input.Length; i++)
            {
                Path += input[i].ToString();
            }
        }
        public void ReadSecond(string[] input)
        {
            int h = input.Length -1;
            int w = input[0].Length * 2;
            string[] Output = new string[input.Length -2];
            for(int i = 0; i < h-1; i++)
            {
                string Current = input[i];
                string NewRow = "";

                for (int j = 0; j < Current.Length; j++)
                {
                    char c  = Current[j];
                    if (c == '#')
                    {
                        NewRow += "##";
                    }
                    else if (c == 'O')
                    {
                        NewRow += "[]";
                    }
                    else if (c == '.')
                    {
                        NewRow += "..";
                    }
                    else if (c == '@')
                    {
                        NewRow += "@.";
                    }
                    else
                    {
                        NewRow += c;
                    }
                }
                Output[i] = NewRow;
            }
            _width = Output[0].Length;
            int found = 0;
            int PathStartLine = 0;
            for (int j = 0; j < Output.Length; j++)
            {
                {
                    for (int i = 0; i < Output[j].Length; i++)
                    {
                        if (Output[j][i] == '#' && j != 0)
                        {
                            found++;
                        }
                        else
                        {
                            found = 0;
                            break;
                        }
                        if (found == Output[j].Length - 1)
                        {
                            _height = j + 1;
                            PathStartLine = j + 2;
                            break;
                        }
                    }
                }
            }
            _grid = new char[_height, _width];
            for (var y = 0; y < _height; y++)
            {
                var line = Output[y];
                for (var x = 0; x < _width; x++)
                {
                    var character = line[x];
                    _grid[y, x] = character;
                }
            }
            for (int i = PathStartLine; i < input.Length; i++)
            {
                Path += input[i].ToString();
            }
        }
        public void FirstStar()
        {
            int TotalPrice = 0;
            ReadFile(false);
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_grid[y, x] == '@')
                    {
                        Point p = new Point(y, x);
                        StartTravel(p, false);

                        TotalPrice = FindZeroPoint();
                        break;
                    }
                }
            }
            PrintGrid();
            Console.WriteLine("Numbers: " + TotalPrice);
        }

        public void SecondStar()
        {
            int TotalPrice = 0;
            Point At = new Point(0, 0);
            ReadFile(true);
            PrintGrid();

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_grid[y, x] == '@')
                    {
                        Point p = new Point(y, x);
                        StartTravel(p, true);

                        TotalPrice = FindZeroPoint();
                        break;
                    }
                }
            }

            //TotalPrice = FindZeroPoint();
            PrintGrid();
            Console.WriteLine("Numbers: " + TotalPrice);

        }
        private void StartTravel(Point p, bool Part)
        {
            foreach (var Direction in Path)
            {
                if (CheckPath(p, Direction))
                {
                    Console.WriteLine(Direction);
                    p = ShiftToNextDot(p, Direction, Part);                    
                }
            }
        }

        private bool CheckPath(Point StartPath, Char Direction)
        {
            FoundPoints = new List<Point>();
            bool PathOK = false;
            int CheckBefore = 0;
            int steps = 0;
            var points = MovePoint(Direction);
            int DirX = points.X; 
            int DirY = points.Y;
            int DotX = StartPath.X, DotY = StartPath.Y;
            bool Breaker = false;
            while (_grid[DotX + DirX, DotY + DirY] != '#')
            {
                if (_grid[DotX + DirX, DotY + DirY] == '.')
                { 
                    steps++;
                } 
                if (_grid[DotX + DirX, DotY + DirY] == ']')
                {
                    FoundPoints.Add(new Point(DotX + DirX, DotY + DirY));
                    FoundPoints.Add(new Point(DotX + DirX, (DotY + DirY) -1));
                }
                if (_grid[DotX + DirX, DotY + DirY] == '[')
                {
                    FoundPoints.Add(new Point(DotX + DirX, DotY + DirY));
                    FoundPoints.Add(new Point(DotX + DirX, (DotY + DirY) + 1));
                }
                foreach (var point in FoundPoints) 
                { 
                    int NextDirX = point.X, NextDirY = point.Y;
                    int NextDotX = NextDirX +DirX, NextDotY = NextDirY +DirY;
                    if (_grid[NextDotX, NextDotY] == '#')
                    {
                        steps = steps;
                        Breaker = true;
                        break;
                    }
                }
                DotX += DirX;
                DotY += DirY;
            }
            if (steps > 0 && !Breaker)
            {
                PathOK = true;
            }
            return PathOK;
        }
        private Point ShiftToNextDot(Point StartPath, Char Direction, bool part)
        {
            Point p = new Point();
            var points = MovePoint(Direction);
            int DirX = points.X;
            int DirY = points.Y;
            int DotX = StartPath.X, DotY = StartPath.Y;
            Char FirstChar = _grid[DotX + DirX, DotY];
            int Iteration = 2;
            List<int> WidthPoints = new List<int>();
            while (_grid[DotX + DirX, DotY + DirY] != '.')
            {
                
                DotX += DirX;
                DotY += DirY;
                if (Direction == '^' || Direction == 'v')
                {
                    if (_grid[DotX, DotY] != FirstChar)// && DotX != DotX + DirX)
                    {
                        Iteration += 2;
                        WidthPoints.Add(Iteration);
                        FirstChar = _grid[DotX, DotY];
                    }
                }
            }
            
            DotX += DirX;
            DotY += DirY;

            int CurrentX = DotX, CurrentY = DotY;
            int NewDotX = CurrentX, NewDotY = CurrentY;

            
            while (CurrentX != StartPath.X || CurrentY != StartPath.Y)
            {
                int prevX = CurrentX - DirX, prevY = CurrentY - DirY;
                if (!part && _grid[prevX, prevY] == 'O')
                {
                    _grid[CurrentX, CurrentY] = 'O';
                    _grid[prevX, prevY] = '.';
                } 
                else if (part && (_grid[prevX, prevY] == '[' || _grid[prevX, prevY] == ']'))
                {
                    char FoundChar = _grid[prevX, prevY];                    
                    if (FoundChar == '[')
                    {

                        if (_grid[CurrentX, CurrentY] == '['
                         && _grid[CurrentX, CurrentY + 1] == ']')
                        {
                            return StartPath;                            
                        }
                        if (_grid[prevX, prevY -1] == ']')
                        {
                            List<Point> LoopPoints = new List<Point>();
                            int LoopX = CurrentX - DirX, LoopY = CurrentY;
                            while (_grid[LoopX, LoopY] == '[' || _grid[LoopX, LoopY] == ']')
                            {
                                if (!LoopPoints.Contains(new Point(LoopX, LoopY)) && LoopPoints.Count < (StartPath.X - LoopX) / 2)
                                {
                                    LoopPoints.Add(new Point(LoopX, LoopY));
                                }
                                else if (LoopPoints.Count >= (StartPath.X - LoopX) / 2 && _grid[LoopX, LoopY] == ']')
                                {
                                    LoopPoints.Add(new Point(LoopX, LoopY - 1));
                                }
                                LoopY--;
                            }
                            LoopY = CurrentY;
                            while (_grid[LoopX, LoopY] == '[' || _grid[LoopX, LoopY] == ']')
                            {
                                if (!LoopPoints.Contains(new Point(LoopX, LoopY)) && LoopPoints.Count < (StartPath.X - LoopX))
                                {
                                    LoopPoints.Add(new Point(LoopX, LoopY));
                                }
                                else if (LoopPoints.Count >= (StartPath.X - LoopX) && _grid[LoopX, LoopY] == '[')
                                {
                                    LoopPoints.Add(new Point(LoopX, LoopY + 1));
                                }
                                LoopY++;
                            }
                            foreach (Point po in LoopPoints)
                            {
                                if (_grid[po.X + DirX, po.Y] == '#')
                                {
                                    return StartPath;
                                }
                            }
                            foreach (Point po in LoopPoints)
                            {
                                _grid[po.X + DirX, po.Y] = _grid[po.X, po.Y];
                                _grid[po.X, po.Y] = '.';
                            }
                        }
                        _grid[CurrentX, CurrentY] = '[';
                        _grid[CurrentX, CurrentY +1] = ']';
                        _grid[prevX, prevY +1] = '.';
                        //Console.WriteLine("[");
                        //PrintGrid();
                    }
                    else if (FoundChar == ']')
                    {
                        if ( _grid[CurrentX, CurrentY] == ']'
                        && _grid[CurrentX, CurrentY - 1] == '[')
                        {
                            return StartPath;
                        }
                        List<Point> LoopPoints = new List<Point>();
                        int LoopX = CurrentX - DirX, LoopY = CurrentY;
                        //Setdots(CurrentX, CurrentY, DirX, StartPath);
                        while (_grid[LoopX, LoopY] == '[' || _grid[LoopX, LoopY] == ']')
                        {
                            if (!LoopPoints.Contains(new Point(LoopX, LoopY)) && LoopPoints.Count < (StartPath.X - LoopX) / 2)
                            {
                                LoopPoints.Add(new Point(LoopX, LoopY));
                            }
                            else if (LoopPoints.Count >= (StartPath.X - LoopX) / 2 && _grid[LoopX, LoopY] == ']')
                            {
                                LoopPoints.Add(new Point(LoopX, LoopY - 1));
                            }
                            LoopY--;
                        }
                        LoopY = CurrentY;
                        while (_grid[LoopX, LoopY] == '[' || _grid[LoopX, LoopY] == ']')
                        {
                            if (!LoopPoints.Contains(new Point(LoopX, LoopY)) && LoopPoints.Count < (StartPath.X - LoopX))
                            {
                                LoopPoints.Add(new Point(LoopX, LoopY));
                            }
                            else if (LoopPoints.Count >= (StartPath.X - LoopX) && _grid[LoopX, LoopY] == '[')
                            {
                                LoopPoints.Add(new Point(LoopX, LoopY + 1));
                            }
                            LoopY++;
                        }
                        foreach (Point po in LoopPoints)
                        {
                            if (_grid[po.X + DirX, po.Y] == '#')
                            {
                                return StartPath;
                            }
                        }
                        foreach (Point po in LoopPoints)
                        {
                            _grid[po.X + DirX, po.Y] = _grid[po.X, po.Y];
                            _grid[po.X, po.Y] = '.';
                        }
/*
                        _grid[CurrentX, CurrentY] = ']';
                        _grid[CurrentX, CurrentY -1] = '[';
                        _grid[prevX, prevY -1] = '.';*/
                        //Console.WriteLine("]");
                        //PrintGrid();
                    }
                }
                CurrentX = prevX;
                CurrentY = prevY;
                NewDotX = StartPath.X + DirX;
                NewDotY = StartPath.Y + DirY;
            }
            _grid[NewDotX, NewDotY] = '@';
            _grid[StartPath.X, StartPath.Y] = '.';
            PrintGrid();
            return new Point(NewDotX, NewDotY);
        }
        private void Setdots(int CurrentX, int CurrentY, int DirX, Point StartPath)
        {
            List<Point> LoopPoints = new List<Point>();
            int LoopX = CurrentX - DirX, LoopY = CurrentY;
            while (_grid[LoopX, LoopY] == '[' || _grid[LoopX, LoopY] == ']')
            {
                if (!LoopPoints.Contains(new Point(LoopX, LoopY)) && LoopPoints.Count < (StartPath.X - LoopX) / 2)
                {
                    LoopPoints.Add(new Point(LoopX, LoopY));
                }
                else if (LoopPoints.Count >= (StartPath.X - LoopX) / 2 && _grid[LoopX, LoopY] == ']')
                {
                    LoopPoints.Add(new Point(LoopX, LoopY - 1));
                }
                LoopY--;
            }
            LoopY = CurrentY;
            while (_grid[LoopX, LoopY] == '[' || _grid[LoopX, LoopY] == ']')
            {
                if (!LoopPoints.Contains(new Point(LoopX, LoopY)) && LoopPoints.Count < (StartPath.X - LoopX))
                {
                    LoopPoints.Add(new Point(LoopX, LoopY));
                }
                else if (LoopPoints.Count >= (StartPath.X - LoopX) && _grid[LoopX, LoopY] == '[')
                {
                    LoopPoints.Add(new Point(LoopX, LoopY + 1));
                }
                LoopY++;
            }
            foreach (Point po in LoopPoints)
            {
                if (_grid[po.X + DirX, po.Y] == '#')
                {
                    return;
                }
            }
            foreach (Point po in LoopPoints)
            {
                _grid[po.X + DirX, po.Y] = _grid[po.X, po.Y];
                _grid[po.X, po.Y] = '.';
            }
        }
        private Point MovePoint(char Direction)
        {
            var Dir = new Point();
            return (Dir) = Direction switch
            {
                '>' => (new Point(0, 1)),
                'v' => (new Point(1, 0)),
                '<' => (new Point(0, -1)),
                '^' => (new Point(-1, 0))
            };
        }
        public int FindZeroPoint()
        {
            int total = 0;
            for (int y = 1; y < _height; y++)
            {
                for (int x = 1; x < _width; x++)
                {
                    if (_grid[y, x] == 'O' || _grid[y, x] == '[')
                    {
                        Point p = new Point(y, x);
                        total += y * 100 + x;
                    }
                }
            }
            return total;
        }
        private void PrintGrid()
        {
            for (int row = 0; row < _grid.GetLength(0); row++)
            {
                for (int col = 0; col < _grid.GetLength(1); col++)
                {
                    Console.Write(_grid[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}