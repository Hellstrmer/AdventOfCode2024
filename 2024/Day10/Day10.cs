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
        public void ReadFile()
        {
            // 308915776 To high
            //Reading out a grid
            bool example = false;
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
            Point Zero = new Point();
            int SlopeCounter = 0;
            matches = 1;
            int res = 0;
            bool ResultDone = false;
            int Dir = 0;

            for (int x = 0; x < _width; x++)
            {
                //Console.WriteLine("Inputs! " + Inputs[x]);
                for (int y = 0; y < _height; y++)
                {
                    bool TP = Int32.TryParse(_grid[x, y].ToString(), out int t);
                    //if (Int32.Parse(_grid[x, y].ToString()) == Dir)
                    if (TP && t == Dir)
                    {
                        if (TP && t == 0)
                        {
                            FoundPointsZero.Add(new Point(x, y));
                        }
                        Dir++;
                        Zero = new Point(x, y);
                        //Console.WriteLine(_grid[x, y]);
                        for (int i = 0; i < matches; i++)
                        {
                            ResultDone = CheckPath(Zero, Dir, FoundPoints);
                            if (ResultDone)
                            {
                                Dir = 0;
                                
                                break;
                            }
                        }   
                    }
                }
                    /*if (x == _width - 1)
                    {
                        for (int row = 0; row < _grid.GetLength(0); row++)
                        {
                            for (int col = 0; col < _grid.GetLength(1); col++)
                            {
                                Console.Write(_grid[row, col]);
                            }
                            Console.WriteLine();
                        }
                        //Console.WriteLine("Antinode: " + Antinode);
                    }*/
                }
            int tes = (int)Math.Pow(FoundPoints.Count, FoundPointsZero.Count);
            Console.WriteLine("Numbers: " + ResultInt+ "Found: " + tes);
        }
        private bool CheckPath(Point point, int FindNumbers, HashSet<Point> FoundPoints)
        {
            int res = 0;
            //HashSet<Point> FoundPoints = new HashSet<Point>();
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
                        
            if (!OutOfBound(pX1) && bPx1 && IPx1 == FindNumbers)//Int32.Parse(_grid[pX1.X, pX1.Y].ToString()) == FindNumbers && Int32.Parse(_grid[pX1.X, pX1.Y].ToString()) != 9)
            {
                res++;
                Points.Add(pX1);
            }
            if (!OutOfBound(pX2) && bPx2 && IPx2 == FindNumbers)//Int32.Parse(_grid[pX2.X, pX2.Y].ToString()) == FindNumbers)
            {
                res++;
                Points.Add(pX2);
            }
            if (!OutOfBound(pY1) && bPy1 && IPy1 == FindNumbers)//Int32.Parse(_grid[pY1.X, pY1.Y].ToString()) == FindNumbers)
            {
                res++;
                Points.Add(pY1);
            }
            if (!OutOfBound(pY2) && bPy2 && IPy2 == FindNumbers)//Int32.Parse(_grid[pY2.X, pY2.Y].ToString()) == FindNumbers)
            {
                res++;
                Points.Add(pY2);                
            }

            if (FindNumbers == 9)
            /* && (!OutOfBound(pX1) && Int32.Parse(_grid[pX1.X, pX1.Y].ToString()) == 9
             || !OutOfBound(pX2) && Int32.Parse(_grid[pX2.X, pX2.Y].ToString()) == 9
             || !OutOfBound(pY1) && Int32.Parse(_grid[pY1.X, pY1.Y].ToString()) == 9
             || !OutOfBound(pY2) && Int32.Parse(_grid[pY2.X, pY2.Y].ToString()) == 9))*/
            {
                FoundPoints.Add(pX1);
                ResultInt += res;
                return true;
            }
            FindNumbers++; 
            
            foreach (var p in Points)
            {
                //Console.WriteLine("Points: " + res + " " +FindNumbers);
                CheckPath(p, FindNumbers, FoundPoints);
            }
            
            matches = res;
            return false;                
        }
        

        private bool CheckPos(List<string> Inputs, int ResultInt, int XFind, int YFind, int Direction)
        {
            bool ResultOK = false;
            /*int XFind = 0;
            int YFind = 0;*/
            if (ResultInt == 9)
            {
                ResultOK = true;
                Console.WriteLine($"Found full stack! X: " + XFind + " Y: " + YFind);
            }
            if (!ResultOK)
            {
                if (Direction == 0 && YFind < Inputs[XFind].Count() -1)
                {
                    XFind = XFind;
                    YFind = YFind + 1;
                    Console.WriteLine("Y: " + YFind + " Inputs: " + (Inputs[XFind].Count() - 2));
                    int InputPos = Int32.Parse(Inputs[XFind][YFind].ToString());
                    if (InputPos == ResultInt +1)
                    {
                        ResultInt++;
                        CheckPos(Inputs, ResultInt, XFind, YFind, 0);
                    } 
                    else
                    {
                        CheckPos(Inputs, ResultInt -1, XFind, YFind, 1);
                    }
                } 
                else if(Direction == 0 && YFind >= Inputs[XFind].Count() - 1)
                {
                    Console.WriteLine("Numbers In Rec0: " + ResultInt);
                    CheckPos(Inputs, ResultInt, XFind, YFind, 1);
                }
                    
                if (Direction == 1 && XFind < Inputs.Count() -1)
                {
                    XFind = XFind + 1;
                    YFind = YFind;
                    int InputPos = Int32.Parse(Inputs[XFind][YFind].ToString());
                    if (InputPos == ResultInt + 1)
                    {
                        ResultInt++;
                        CheckPos(Inputs, ResultInt, XFind, YFind, 1);
                    }
                    else
                    {
                        CheckPos(Inputs, ResultInt, XFind, YFind, 2);
                    }
                }
                else if (Direction == 1 && XFind >= Inputs.Count() - 1)
                {
                    Console.WriteLine("Numbers In Rec1: " + ResultInt);
                    CheckPos(Inputs, ResultInt, XFind, YFind, 2);
                }
                if (Direction == 2 && YFind >= 0)
                {
                    XFind = XFind;
                    YFind = YFind - 1;
                    int InputPos = Int32.Parse(Inputs[XFind][YFind].ToString());
                    if (InputPos == ResultInt + 1)
                    {
                        ResultInt++;
                        CheckPos(Inputs, ResultInt, XFind, YFind, 2);
                    }
                    else
                    {
                        CheckPos(Inputs, ResultInt, XFind, YFind, 3);
                    }
                }
                else if (Direction == 2 && YFind == 0)
                {
                    Console.WriteLine("Numbers In Rec2: " + ResultInt);
                    CheckPos(Inputs, ResultInt, XFind, YFind, 3);
                }

                if (Direction == 3 && XFind > 0)
                {
                    XFind = XFind - 1;
                    YFind = YFind;
                    int InputPos = Int32.Parse(Inputs[XFind][YFind].ToString());
                    if (InputPos == ResultInt + 1)
                    {
                        ResultInt++;
                        CheckPos(Inputs, ResultInt, XFind, YFind, 3);
                    }
                    else
                    {
                        CheckPos(Inputs, ResultInt - 1, XFind, YFind, 0);
                    }
                }
                else if (Direction == 3 && YFind == 0)
                {
                    Console.WriteLine("Numbers In Rec3: " + ResultInt);
                    CheckPos(Inputs, ResultInt - 1, XFind, YFind, 0);
                }
            }        
            return ResultOK;
        }
        private enum Pathern
        {
            X1,
            X2,
            Y1,
            Y2
        }

        private bool OutOfBound(Point ControlPoint)
        {
            return ControlPoint.X > _width - 1 || ControlPoint.X < 0 || ControlPoint.Y > _height - 1 || ControlPoint.Y < 0;
        }
    }
}

