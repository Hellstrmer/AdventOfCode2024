
using System.Text.RegularExpressions;

namespace AdventOfCode._2024
{
    internal class Day6
    {
        public List<string> ReadFile()
        {
            bool example = true;
            string input = File.ReadAllText(example
                ? "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day6\\Example.txt".Trim()
                : "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day6\\Input.txt").Trim();
            List<string> Inputs = input.Split("\r\n").ToList();
            return Inputs;
        }
        public void FirstStar()
        {
            List<string> Inputs = ReadFile();
            List<int> First = new List<int>();
            List<int> Second = new List<int>();
            List<int> PathX = new List<int>();
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
                        Console.WriteLine("Before!");
                        if (!ResultDone)
                        {
                            ResultDone = FindStop(Inputs, PathX, PathY, x, y, 0, ResultInt, false);
                        }

                        Console.WriteLine("Match!");
                        return;
                    }
                }
            }

            Console.WriteLine("Numbers: " + ResultInt);
        }

        public bool FindStop(List<string> Inputs,List<int> PathX, List<int> PathY, int xO, int yO, int Direction, int Match, bool Done)
        {
            for (int x = 0; x < Inputs.Count; x++)
            {
                for (int y = 0; y < Inputs[x].Length; y++)
                {
                    if (Done)
                    {
                        return Done;
                    }
                    if (Direction == 0)
                    {
                        if (Inputs[x][yO].ToString() == "#")
                        {
                            PathX.Add(x);
                            PathY.Add(yO);
                            Direction++;
                            Console.WriteLine("Match Up! Index X " + x +"| Y " + yO + "Match: " + Match);
                            Done = FindStop(Inputs, PathX, PathY, x +1, yO, Direction, Match, false);
                        }
                        else if (x == Inputs.Count - 1)
                        {
                            Done = true;
                            return Done;

                        }
                    }
                    else if (Direction == 1)
                    {
                        if (Inputs[xO][y].ToString() == "#")
                        {
                            Direction++;
                            Console.WriteLine("Match Right!" + "Match: " + Match);
                            Done = FindStop(Inputs, PathX, PathY, xO, y -1, Direction, Match, false);
                        }
                        else if (y == Inputs[xO].Length - 1)
                        {
                            Done = true;
                            return Done;
                        }
                    }
                    else if (Direction == 2)
                    {
                        if (Inputs[x][yO].ToString() == "#" && (x > xO || x == 0))
                        {
                            Direction++;
                            Console.WriteLine("Match Down!" + "Match: " + Match);
                            Done = FindStop(Inputs, PathX, PathY, x -1, yO, Direction, Match, false);
                        }
                        else if (x == Inputs.Count - 1)
                        {
                            Done = true;
                            return Done;
                        }
                    }
                    else if (Direction == 3)
                    {
                        if (Inputs[xO][y].ToString() == "#")
                        {
                            Direction = 0;
                            Console.WriteLine("Match Left!" + "Match: " + Match);
                            Done = FindStop(Inputs, PathX, PathY, xO, y + 1, Direction, Match, false);
                        } 
                        else if (y == Inputs[xO].Length -1)
                        {
                            Done = true;
                            return Done;
                        }
                    }
                }
                //Console.WriteLine("Numbers: " +  Match);
            }
            return Done;
        }

        public List<int> addPathX(List<int> PathX, int start, int goal)
        {
            List<int> Result = new List<int>();
            if (start < goal)
            {
                for (int i = start; i > goal; i++)
                {
                    Result.Add(i);
                }
            } 
            else
            {
                for (int i = goal; i > start; i--)
                {
                    Result.Add(i);
                }
            }
            return Result;
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

