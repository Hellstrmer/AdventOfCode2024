
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode._2024
{
    internal class Day6
    {
        private Point _startpos;
        public List<string> ReadFile()
        {
            bool example = false;
            string input = File.ReadAllText(example
                ? "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day6\\Example.txt".Trim()
                : "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day6\\Input.txt").Trim();
            List<string> Inputs = input.Split("\r\n").ToList();
            return Inputs;
        }
        public void FirstStar()
        {
            List<string> Inputs = ReadFile();
            List<string> PathX = new List<string>();
            List<int> PathY = new List<int>();
            int ResultInt = 0;
            bool ResultDone = false;

            for (int x = 0; x < Inputs.Count; x++)
            {
                for (int y = 0; y < Inputs[x].Length; y++)
                {
                    if (Inputs[x][y].ToString() == "^")
                    {
                        ResultInt++;
                        if (!ResultDone)
                        {
                            _startpos = new Point(x, y);
                            ResultDone = FindStop(Inputs, PathX, PathY, _startpos, 0, ResultInt, false);
                        }
                        return;
                    }
                }
            }
        }

        public bool FindStop(List<string> Inputs, List<string> Path, List<int> PathY, Point Position, int Direction, int Match, bool Done)
        {
            //Upp
            if (Direction == 0)
            {                
                for (int x = Position.X; x >= 0; x--)
                {
                    if (Done)
                    {
                        return Done;
                    }
                    string PathMatch = x.ToString() + " " + Position.Y.ToString();
                    for (int i = 0; i < Path.Count; i++)
                    {
                        if (Path[i] == PathMatch)
                        {
                            break;
                        }
                        else if (i == Path.Count - 1 )
                        {
                            Match++;
                            break;
                        }
                    }
                    Path.Add(PathMatch);
                    if (x == Inputs.Count - 1)
                    {
                        Done = true;
                        Console.WriteLine("Match! " + Match);
                        return Done;
                    }
                    else if (Inputs[x - 1][Position.Y].ToString() == "#")
                    {
                        Position.X = x;
                        Direction++;
                        Done = FindStop(Inputs, Path, PathY, Position, Direction, Match, false);
                    }
                }
            }
            //Höger
            else if (Direction == 1)
            {
                for (int y = Position.Y; y < Inputs[Position.X].Length; y++)
                {
                    if (Done)
                    {
                        return Done;
                    }
                    string PathMatch = Position.X.ToString() + " " + y.ToString();
                    for (int i = 0; i < Path.Count; i++)
                    {
                        if (Path[i] == PathMatch)
                        {
                            break;
                        }
                        else if (i == Path.Count - 1)
                        {
                            Match++;
                            break;
                        }
                    }
                    Path.Add(PathMatch);
                    if (y == Inputs.Count - 1)
                    {
                        Done = true;
                        Console.WriteLine("Match! " + Match);
                        return Done;
                    }
                    else if (Inputs[Position.X][y + 1].ToString() == "#")
                    {
                        Position.Y = y;
                        Direction++;
                        Done = FindStop(Inputs, Path, PathY, Position, Direction, Match, false);
                    }
                }
            }
            //ner
            else if (Direction == 2)
            {
                for (int x = Position.X; x < Inputs.Count; x++)
                {
                    if (Done)
                    {
                        return Done;
                    }
                    string PathMatch = x.ToString() + " " + Position.Y.ToString();
                    for (int i = 0; i < Path.Count; i++)
                    {
                        if (Path[i] == PathMatch)
                        {
                            break;
                        }
                        else if (i == Path.Count - 1)
                        {
                            Match++;
                            break;
                        }
                    }
                    Path.Add(PathMatch);
                    if (x == Inputs.Count - 1)
                    {
                        Done = true;
                        Console.WriteLine("Match! " + Match);
                        return Done;
                    }
                    else if (Inputs[x + 1][Position.Y].ToString() == "#")
                    {
                        Position.X = x;
                        Direction++;
                        Done = FindStop(Inputs, Path, PathY, Position, Direction, Match, false);
                    }
                }
            }
            else if (Direction == 3)
            {
                for (int y = Position.Y; y > 0; y--)
                {
                    if (Done)
                    {
                        return Done;
                    }
                    string PathMatch = Position.X.ToString() + " " + y.ToString();
                    for (int i = 0; i < Path.Count; i++)
                    {
                        if (Path[i] == PathMatch)
                        {
                            break;
                        }
                        else if (i == Path.Count - 1)
                        {
                            Match++;
                            break;
                        }
                    }
                    Path.Add(PathMatch);
                    if (y == Inputs.Count - 1)
                    {
                        Done = true;
                        Console.WriteLine("Match! " + Match);
                        return Done;
                    }
                    else if (Inputs[Position.X][y - 1].ToString() == "#")
                    {
                        Position.Y = y;
                        Direction = 0;
                        Done = FindStop(Inputs, Path, PathY, Position, Direction, Match, false);
                    }
                }
            }
            return Done;
        }

        public int PathCheck(List<string> Path, string PathMatch, int ActualX, int OldX, int Match)
        {
            for (int i = 0; i < Path.Count; i++)
            {
                if (Path[i] == PathMatch)
                {
                    break;
                }
                else if (i == Path.Count - 1 && ActualX != OldX)
                {
                    Match++;
                    break;
                }
            }
            Path.Add(PathMatch);

            return Match;
        }

        private bool isOutOfBounds(int x, int y)
        {
            return false;
        }


        public void SecondStar()
        {
            /*//Inte alls färdig, tänkte helt fel.
            List<string> Inputs = ReadFile();
            List<int> First = new List<int>();
            List<int> Second = new List<int>();
            List<List<string>> Path = new List<List<string>>();
            int ResultInt = 0;

            foreach (string d in Inputs)
            {
                if (d.IndePosition.Xf('|') != -1)
                {
                    string f = d.Substring(0, d.IndePosition.Xf('|')).Trim();
                    string l = d.Substring(d.IndePosition.Xf('|') + 1).Trim();
                    First.Add(Int32.Parse(f));
                    Second.Add(Int32.Parse(l));
                }
                else if (d.IndePosition.Xf(",") != -1)
                {
                    List<string> tPath = d.Split(',').ToList();
                    tPath.Select(int.Parse).ToList();
                    ResultInt += sortList(true, tPath, First, Second);
                }
            }
            Console.WriteLine("Result: " + ResultInt);
            */
        }
    }
}
