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
                ? "C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day10\\Example.txt"
                : "C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day10\\Input.txt");

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
            HashSet<Point> FoundPoints = new HashSet<Point>();
            HashSet<Point> FoundPointsZero = new HashSet<Point>();
            HashSet<Point> StartStop = new HashSet<Point>();
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
                        StartStop.Clear();
                        StartStop.Add(ZeroPoint);

                    }
                    if (TP && t == Dir)
                    {
                        StartStop.Clear();
                        Dir++;
                        Zero = new Point(x, y);
                        ResultDone = CheckPath(Zero, Dir, FoundPoints, StartStop);
                        if (ResultInt == 23)
                        {
                            Console.WriteLine("Numbers In: " + ResultInt);
                        }
                        if (ResultDone)
                        {
                            Dir = 0;
                            StartStop.Clear();
                        }                 
                    }
                }                
            }
            Console.WriteLine("Numbers: " + ResultInt);
        }
        private bool CheckPath(Point point, int FindNumbers, HashSet<Point> FoundPoints, HashSet<Point> StartStop)
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
                        
            if (!OutOfBound(pX1) && bPx1 && IPx1 == FindNumbers && !(StartStop.Contains(pX1) && StartStop.Contains(ZeroPoint)))
            {
                res++;
                Points.Add(pX1);
                if (FindNumbers == 9)
                {
                    StartStop.Add(pX1);
                }
            }
            if (!OutOfBound(pX2) && bPx2 && IPx2 == FindNumbers && !(StartStop.Contains(pX2) && StartStop.Contains(ZeroPoint)))
            {
                res++;
                Points.Add(pX2);
                if (FindNumbers == 9)
                {
                    StartStop.Add(pX2);
                }
            }
            if (!OutOfBound(pY1) && bPy1 && IPy1 == FindNumbers && !(StartStop.Contains(pY1) && StartStop.Contains(ZeroPoint)))
            {
                res++;
                Points.Add(pY1);
                if (FindNumbers == 9)
                {
                    StartStop.Add(pY1);
                }
            }
            if (!OutOfBound(pY2) && bPy2 && IPy2 == FindNumbers && !(StartStop.Contains(pY2) && StartStop.Contains(ZeroPoint)))
            {
                res++;
                Points.Add(pY2);
                if(FindNumbers == 9)
                {
                    StartStop.Add(pY2);
                }
            }

            if (FindNumbers == 9)
            {                
                ResultInt += res;
                FindNumbers = 0;
                done = true;
                //Console.WriteLine("Res: " + res);
                return done;
            }
            FindNumbers++; 
            
            if (!done)
            {
                foreach (var p in Points)
                {
                    //Console.WriteLine("Points: " + res + " " +FindNumbers);
                    bool temp = CheckPath(p, FindNumbers, FoundPoints, StartStop);
                }
            }
            
            matches = res;
            return false;
        }   

        private bool OutOfBound(Point ControlPoint)
        {
            return ControlPoint.X > _width - 1 || ControlPoint.X < 0 || ControlPoint.Y > _height - 1 || ControlPoint.Y < 0;
        }
    }
}

