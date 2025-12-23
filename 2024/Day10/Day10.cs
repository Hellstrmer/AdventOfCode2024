using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode._2024
{
    internal class Day10
    {
        private int _width;
        private int _height;
        private char[,] _grid;
        private int ResultInt;
        private int matches;
        private Point ZeroPoint;
        public void ReadFile()
        {
            // 308915776 To high
            //Reading out a grid
            bool example = true;
            string[] input = File.ReadAllLines(example
                ? "C:\\Users\\jespe\\Source\\Repos\\Hellstrmer\\AdventOfCode2024\\2024\\Day10\\Example.txt"
                : "C:\\Users\\jespe\\Source\\Repos\\Hellstrmer\\AdventOfCode2024\\2024\\Day10\\Input.txt");

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
            List<int> Matches = new List<int>();
            List<Point> Path = new List<Point>();
            HashSet<Point> FoundPoints = new HashSet<Point>();
            HashSet<Point> FoundPointsZero = new HashSet<Point>();
            Point Zero = new Point();
            matches = 1;
            int res = 0;
            bool ResultDone = false;
            int Dir = 0;

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    bool TP = Int32.TryParse(_grid[x, y].ToString(), out int t);
                    if (TP && t == 0)
                    {
                        FoundPointsZero.Add(new Point(x, y));
                        ZeroPoint = new Point(x, y);
                        Path.Clear();

                    }
                    if (TP && t == Dir)
                    {
                        Path.Add(ZeroPoint);
                        Dir++;
                        Zero = new Point(x, y);
                        Path.Add(Zero);
                        ResultDone = CheckPath(Zero, Dir, Path);
                        Console.WriteLine("ResultInt: " + ResultInt);
                        if (ResultInt == 23)
                        {
                            Console.WriteLine("Numbers In: " + ResultInt);
                        }
                        if (ResultDone)
                        {
                            Dir = 0;
                        }                 
                    }
                }                
            }
            Console.WriteLine("Numbers: " + ResultInt);
        }
        private bool CheckPath(Point point, int FindNumbers, List<Point> Path)
        {
            bool done = false;
            int res = 0;
            //StartStop.Add(point);
            List<Point> Points = new List<Point>();
            Point pX1 = new Point(point.X +1, point.Y);
            Point pX2 = new Point(point.X -1, point.Y);
            Point pY1 = new Point(point.X, point.Y + 1);
            Point pY2 = new Point(point.X, point.Y - 1);
            bool bPx1 = false;
            bool bPx2 = false;
            bool bPy1 = false;
            bool bPy2 = false;
            int IPx1 = 0;
            int IPx2 = 0;
            int IPy1 = 0;
            int IPy2 = 0;
            if (!OutOfBound(pX1))
                {
                bPx1 = Int32.TryParse(_grid[pX1.X, pX1.Y].ToString(), out IPx1);
            }
            if (!OutOfBound(pX2))
            {
                bPx2 = Int32.TryParse(_grid[pX2.X, pX2.Y].ToString(), out IPx2);
            }
            if (!OutOfBound(pY1))
            {
                bPy1 = Int32.TryParse(_grid[pY1.X, pY1.Y].ToString(), out IPy1);
            }
            if (!OutOfBound(pY2))
            {
                bPy2 = Int32.TryParse(_grid[pY2.X, pY2.Y].ToString(), out IPy2);
            }                    
                        
            if (!OutOfBound(pX1) && bPx1 && IPx1 == FindNumbers && CheckPathStorage(pX1, Path))
            {
                res++;
                Points.Add(pX1);
                Path.Add(pX1);
            }
            if (!OutOfBound(pX2) && bPx2 && IPx2 == FindNumbers && CheckPathStorage(pX2, Path))
            {
                res++;
                Points.Add(pX2);
                Path.Add(pX2);                
            }
            if (!OutOfBound(pY1) && bPy1 && IPy1 == FindNumbers && CheckPathStorage(pY1, Path))
            {
                res++;
                Points.Add(pY1);
                Path.Add(pY1);
            }
            if (!OutOfBound(pY2) && bPy2 && IPy2 == FindNumbers && CheckPathStorage(pY2, Path))
            {
                res++;
                Points.Add(pY2);
                Path.Add(pY2);
            }

            if (FindNumbers == 9)
            {                
                ResultInt += res;
                FindNumbers = 0;
                //done = true;
                //Console.WriteLine("Res: " + res);
                
                return done;
            }
            FindNumbers++;

            //if (!done)
            //{
            foreach (var p in Points)
            {
                var newPath = new List<Point>(Path);
                newPath.Add(p);
                bool temp = CheckPath(p, FindNumbers, newPath);
            }

            //}

            matches = res;
            return done;
        }   

        private void CheckValidPoint(Point p, int FindNumbers, List<Point> Points, List<Point> Path)
        {
            //if(!OutOfBound(p) && )
        }

        private bool CheckPathStorage(Point p, List<Point> path)
        {
            bool Found = false;/*
            if (p.X == 4 && p.Y == 3)
            {
                Console.WriteLine("P!");
            } */
            foreach (Point p2 in path)
            {
                if(p.Equals(p2))
                {
                    Found = false;
                    break;
                }
                else
                {
                    Found = true;
                }
            }

            return Found;
        }
        private bool OutOfBound(Point ControlPoint)
        {
            return ControlPoint.X > _width - 1 || ControlPoint.X < 0 || ControlPoint.Y > _height - 1 || ControlPoint.Y < 0;
        }
    }
}

