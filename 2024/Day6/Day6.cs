
using System.Text.RegularExpressions;

namespace AdventOfCode._2024
{
    internal class Day6
    {
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
                            ResultDone = FindStop(Inputs, PathX, PathY, x, y, 0, ResultInt, false);
                        }
                        return;
                    }
                }
            }
        }

        public bool FindStop(List<string> Inputs,List<string> Path, List<int> PathY, int xO, int yO, int Direction, int Match, bool Done)
        {            
            //Upp
            if (Direction == 0)
            {
                for (int x = xO; x >= 0; x--)
                {
                    if (Done)
                    {
                        return Done;
                    }
                    string PathMatch = x.ToString() + " " + yO.ToString();
                    for (int i = 0; i < Path.Count; i++)
                    {
                        if (Path[i] == PathMatch)
                        {
                            break;
                        }
                        else if (i == Path.Count - 1 && x != xO)
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
                    else if (Inputs[x -1][yO].ToString() == "#")
                    {
                        Direction++;
                        Done = FindStop(Inputs, Path, PathY, x, yO, Direction, Match, false);
                    }                    
                }
            } 
            //Höger
            else if (Direction == 1)
            {
                for (int y = yO; y < Inputs[xO].Length; y++)
                {
                    if (Done)
                    {
                        return Done;
                    }
                    string PathMatch = xO.ToString() + " " + y.ToString();
                    for (int i = 0; i < Path.Count; i++)
                    {
                        if (Path[i] == PathMatch)
                        {
                            break;
                        }
                        else if (i == Path.Count - 1 && y != yO)
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
                    else if (Inputs[xO][y +1].ToString() == "#")
                    {
                        Direction++;
                        Done = FindStop(Inputs, Path, PathY, xO, y, Direction, Match, false);
                    } 
                }
            }
            //ner
            else if (Direction == 2)
            {
                for (int x = xO; x < Inputs.Count; x++)
                {
                    if (Done)
                    {
                        return Done;
                    }
                    string PathMatch = x.ToString() + " " + yO.ToString();
                    for (int i = 0; i < Path.Count; i++)
                    {
                        if (Path[i] == PathMatch)
                        {
                            break;
                        }
                        else if (i == Path.Count - 1 && x != xO)
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
                    else if (Inputs[x + 1][yO].ToString() == "#")
                    {
                        Direction++;
                        Done = FindStop(Inputs, Path, PathY, x, yO, Direction, Match, false);
                    }
                }
            }
            else if (Direction == 3)
            {
                for (int y = yO; y > 0; y--)
                {
                    if (Done)
                    {
                        return Done;
                    }
                    string PathMatch = xO.ToString() + " " + y.ToString();
                    for (int i = 0; i < Path.Count; i++)
                    {
                        if (Path[i] == PathMatch)
                        {
                            break;
                        } else if (i == Path.Count -1 && y != yO) 
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
                    else if (Inputs[xO][y - 1].ToString() == "#")
                    {
                        Direction = 0;
                        Done = FindStop(Inputs, Path, PathY, xO, y, Direction, Match, false);
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
                if (d.IndexOf('|') != -1)
                {
                    string f = d.Substring(0, d.IndexOf('|')).Trim();
                    string l = d.Substring(d.IndexOf('|') + 1).Trim();
                    First.Add(Int32.Parse(f));
                    Second.Add(Int32.Parse(l));
                }
                else if (d.IndexOf(",") != -1)
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

