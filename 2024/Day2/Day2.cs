
using System.Text.RegularExpressions;

namespace AdventOfCode._2024
{
    internal class Day2
    {
        public string ReadFile()
        {
            string input = "";
            bool example = true;
            if (example)
            {
                input = File.ReadAllText("C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day2\\Example.txt");
            } 
            else
            {
                input = File.ReadAllText("C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day2\\Input.txt");
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
            int t0 = 0;
            int t1 = 0;

            foreach (string d in Inputs)
            {
                level += 1;
                Data.Add(new List<int>());
               
                find = d.Substring(0, d.IndexOf(" "));
                //Console.WriteLine(findremove);
                //find = d.Substring(d.IndexOf(find), d.IndexOf(" "));


                for (int i = 0; i < d.Length; i++)
                {
                    Numb = false;
                    if (i < d.Length -1)
                    {
                        if (d[i].ToString() != " " && d[i + 1].ToString() != " ")
                        {
                            t += d[i].ToString() + d[i + 1].ToString();
                            i += 1;
                            //Console.WriteLine("Index = " + i + " " + t);
                        } 
                        else
                        {
                            t = d[i].ToString();
                            //Console.WriteLine("Index in else =" + i + " " + t);
                        }
                        
                    } else
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


            for( int i = 0; i < Data.Count; i++)
            {
                up = false;
                down = false;
                t0 = 0;
                t1 = 0;
                for (int j = 0; j < Data[i].Count; j++)
                {                    
                    if (j < Data[i].Count - 1)
                    {
                        if ((j == 0 || up && !down) && Data[i][j + 1] > Data[i][j])
                        {
                            t0 = Data[i][j + 1];
                            t1 = Data[i][j];
                            up = true;
                            if (t0 >= t1 + 3
                                && t0 >= t1 + 1 && up && !down)
                            {
                                //Console.WriteLine(Data[i]);
                                i += 1;
                                j = 0;
                                break;
                            }
                        }
                        else if ((j == 0 || down && !up) &&Data[i][j + 1] < Data[i][j])
                        {
                            t0 = Data[i][j + 1];
                            t1 = Data[i][j];
                            down = true;
                            if (t0 <= t1 -3
                                && t0 <= t1 - 1 && down && !up)
                            {
                                //Console.WriteLine(Data[i]);
                                i += 1;
                                j = 0;
                                break;
                            }
                        }
                    }
                    else if (j == Data[i].Count - 1)
                    {
                        t0 = t0;
                        t1 = t1;
                        up = false;
                        down = false;
                        //Console.WriteLine(Data[i][0]);
                        //Console.WriteLine("Level: " + i + ",: " + Data[i][j]);
                        numbOfResult += 1;
                        Console.WriteLine("Numbers = " + numbOfResult + " Level = " + i + " t0: " + t0 + " t1 " + t1);
                    }

                    //Console.WriteLine("Level: " + i + ",: " + j);

                }
            }

            Console.WriteLine("Numbers = " + numbOfResult);


        }

        public void SecondStar()
        {
            string message = ReadFile();

            List<string> Inputs = message.Split("\r\n").ToList();

            List<int> First = new List<int>();
            List<int> Second = new List<int>();
            List<int> Result = new List<int>();
            int ResultInt = 0;
            int NumberOfMatch = 0;

            foreach (string d in Inputs)
            {
                string f = d.Substring(0, d.IndexOf(' ')).Trim();
                string l = d.Substring(d.IndexOf(' ') + 1).Trim();
                First.Add(Int32.Parse(f));
                Second.Add(Int32.Parse(l));
            }

            for (int i = 0; i < First.Count; i++)
            {
                NumberOfMatch = 0;
               for(int j = 0; j < Second.Count; j++)
                {
                    if (First[i] == Second[j])
                    {
                        NumberOfMatch += 1;
                    }
                }
                Result.Add(First[i] * NumberOfMatch);
            }
            foreach (int i in Result)
            {
                ResultInt += i;
            }
            Console.WriteLine(ResultInt);
        }
    }
}
