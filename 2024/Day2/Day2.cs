
using System.Text.RegularExpressions;

namespace AdventOfCode._2024
{
    internal class Day2
    {
        public string ReadFile()
        {
            string input = "";
            bool example = false;
            if (example)
            {
                input = File.ReadAllText("C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day2\\Example.txt");
            }
            else
            {
                input = File.ReadAllText("C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day2\\Input.txt");
            }
            input = input.Trim();
            return input;
        }

        public void FirstStar()
        {
            string message = ReadFile();

            List<string> Inputs = message.Split("\r\n").ToList();

            List<List<int>> Data = new List<List<int>>();
            string find = null;
            int numbOfResult = 0;
            bool Numb;
            int NumbOut;
            int level = 0;
            string t = null;
            bool up = false;
            bool down = false;
            int tNext = 0;
            int tCurrent = 0;

            foreach (string d in Inputs)
            {
                level += 1;
                Data.Add(new List<int>());

                for (int i = 0; i < d.Length; i++)
                {
                    Numb = false;
                    if (i < d.Length - 1)
                    {
                        if (d[i].ToString() != " " && d[i + 1].ToString() != " ")
                        {
                            t += d[i].ToString() + d[i + 1].ToString();
                            i += 1;
                        }
                        else
                        {
                            t = d[i].ToString();
                        }
                    }
                    else
                    {
                        t = d[i].ToString();
                    }
                    Numb = int.TryParse(t, out NumbOut);
                    if (Numb)
                    {
                        Data[level - 1].Add(NumbOut);
                    }
                }
            }

            for (int i = 0; i < Data.Count; i++)
            {
                up = false;
                down = false;
                tNext = 0;
                tCurrent = 0;
                for (int j = 0; j < Data[i].Count; j++)
                {
                    if (j == 0)
                    {
                        if (Data[i][j + 1] > Data[i][j])
                        {
                            up = true;
                            down = false;
                        }
                        else if (Data[i][j + 1] < Data[i][j])
                        {
                            down = true;
                            up = false;
                        }
                        else
                        {
                            up = false;
                            down = false;
                            break;
                        }
                        if (i == 49)
                        {
                            Console.WriteLine(Data[i][j]);
                            j = j;
                            i = i;
                        }
                    }

                    if (j < Data[i].Count - 1)
                    {
                        if (up && !down)
                        {
                            tNext = Data[i][j + 1];
                            tCurrent = Data[i][j];
                            if (tNext > tCurrent + 3
                                && tNext > tCurrent + 1 && up && !down || tNext < tCurrent || tNext == tCurrent)
                            {
                                up = false;
                                break;
                            }
                        }
                        if (down && !up)
                        {

                            tNext = Data[i][j + 1];
                            tCurrent = Data[i][j];
                            if (tNext < tCurrent - 3
                                && tNext < tCurrent - 1 && down && !up || tNext > tCurrent || tNext == tCurrent)
                            {
                                down = false;
                                break;
                            }
                        }
                    }
                    if (j == Data[i].Count - 1)
                    {
                        tNext = tNext;
                        tCurrent = tCurrent;
                        up = false;
                        down = false;
                        numbOfResult += 1;
                    }
                }
            }
            Console.WriteLine("Numbers = " + numbOfResult);
        }

        public void SecondStar()
        {
            string message = ReadFile();
            List<string> Inputs = message.Split("\r\n").ToList();
            List<List<int>> Data = new List<List<int>>();
            string find = null;
            int numbOfResult = 0;
            bool Numb;
            int NumbOut;
            int level = 0;
            string t = null;
            bool up = false;
            bool down = false;
            int tNext = 0;
            int tSafe = 0;
            int tCurrent = 0;

            foreach (string d in Inputs)
            {
                level += 1;
                Data.Add(new List<int>());
                t = "";

                for (int i = 0; i < d.Length; i++)
                {
                    Numb = false;
                    if (i < d.Length - 1)
                    {
                        if (d[i].ToString() != " " && d[i + 1].ToString() != " ")
                        {
                            t += d[i].ToString() + d[i + 1].ToString();
                            i += 1;
                        }
                        else
                        {
                            t = d[i].ToString();
                        }
                    }
                    else
                    {
                        t = d[i].ToString();
                    }
                    Numb = int.TryParse(t, out NumbOut);
                    if (Numb)
                    {
                        Data[level - 1].Add(NumbOut);
                    }
                }
            }

            for (int i = 0; i < Data.Count; i++)
            {
                up = false;
                down = false;
                tNext = 0;
                tCurrent = 0;
                for (int j = 0; j < Data[i].Count; j++)
                {
                    if (j == 0)
                    {
                        if (Data[i][j + 1] > Data[i][j])
                        {
                            up = true;
                            down = false;
                        }
                        else if (Data[i][j + 1] < Data[i][j])
                        {
                            down = true;
                            up = false;
                        }
                        else
                        {
                            up = false;
                            down = false;
                            break;
                        }
                    }

                    if (j < Data[i].Count - 1)
                    {
                        if (up && !down)
                        {
                            tNext = Data[i][j + 1];
                            tCurrent = Data[i][j];
                            if (tNext > tCurrent + 3
                                && tNext > tCurrent + 1 && up && !down || tNext < tCurrent || tNext == tCurrent)
                            {
                                if (j < Data[i].Count - 2)
                                {
                                    if (Data[i][j + 2] > tCurrent + 3
                                        && Data[i][j + 2] > tCurrent + 1 && up && !down && Data[i][j + 1] != tCurrent) 
                                    {
                                        tSafe += 2;                                        
                                    }
                                    if (Data[i][j + 1] < tCurrent || Data[i][j + 1] == tCurrent)
                                    {
                                        
                                        tSafe += 1;                                        
                                    }
                                }
                            }                                                     
                                if (tSafe > 1)
                                {                                    
                                    tSafe = 0;
                                    up = false;
                                    break;
                                }                              
                        }
                        if (down && !up)
                        {
                            tNext = Data[i][j + 1];
                            tCurrent = Data[i][j];
                            if (tNext < tCurrent - 3
                                && tNext < tCurrent - 1 && down && !up || tNext > tCurrent || tNext == tCurrent)
                            {
                                if (j < Data[i].Count - 2)
                                {
                                    if (Data[i][j + 2] < tCurrent + 3
                                        && Data[i][j + 2] < tCurrent - 1 && down && !up && Data[i][j + 1] != tCurrent)
                                    {
                                        Console.WriteLine("Level = " + i + " tCurrent " + tCurrent + " tNext: " + tNext + " Next Next " + Data[i][j + 2]);
                                        tSafe += 2;
                                    }
                                    if (Data[i][j + 1] > tCurrent || Data[i][j + 1] == tCurrent)
                                    {
                                        Console.WriteLine("Level = " + i + " tCurrent " + tCurrent + " tNext: " + tNext);
                                        tSafe += 1;
                                    }
                                }
                                if (tSafe > 1)
                                {
                                    tSafe = 0;
                                    down = false;
                                    break;
                                }
                            }                            
                        }
                    }
                    if (j == Data[i].Count - 1)
                    {
                        tNext = tNext;
                        tCurrent = tCurrent;
                        up = false;
                        down = false;
                        numbOfResult += 1;
                    }

                }
            }
            Console.WriteLine("Numbers = " + numbOfResult);
        }
    }
}
