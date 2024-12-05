
namespace AdventOfCode._2024
{
    internal class Day5
    {
        public List<string> ReadFile()
        {
            bool example = false;
            string input = File.ReadAllText(example
                ? "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day5\\Example.txt".Trim()
                : "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day5\\Input.txt").Trim();
            List<string> Inputs = input.Split("\r\n").ToList();
            return Inputs;
        }
        public void FirstStar()
        {
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
        }

        public int sortList(bool part1, List<string> Input, List<int> First, List<int> Second)
        {
            int Total = 0;
            int Intenum = 0;
            bool SecondOk = false;
            foreach (string s in Input)
            {
                Intenum++;
                int t = Int32.Parse(s);
                int FirstIndex = 0;
                for (int i = 0; i < First.Count; i++)
                {
                    if (t == First[i])
                    {
                        for (int j = 0; j < Input.Count - 1; j++)
                        {
                            if (Second[i] == Int32.Parse(Input[j]))
                            {
                                FirstIndex = i;
                                SecondOk = LoopForSecond(Input, FirstIndex, Intenum - 1, Second);
                            }
                        }
                    }
                }
                if (SecondOk && s == Input[Input.Count - 1])
                {
                    int tNumb = Int32.Parse(Input[Input.Count / 2]);
                    Total += tNumb;
                }
                else if (!SecondOk)
                {
                    break;
                }
            }            
            return Total;
        }

        public bool LoopForSecond(List<string> Input, int FirstIndex, int IntEnum, List<int> Second)
        {
            bool RowOk = false;
            for (int i = 0; i < Input.Count; i++)
            {
                if (Int32.Parse(Input[i]) == Second[FirstIndex]
                    || i == Input.Count - 1)
                {
                    if (IntEnum < Input.IndexOf(Second[FirstIndex].ToString()) || Input.IndexOf(Second[FirstIndex].ToString()) < 0)
                    {
                        RowOk = true;
                        break;
                    }
                }
            }
            return RowOk;
        }

        public int FindZero(List<string> Input, int index)
        {
            List<int> Numbers = new List<int>();
            int result = 0;
            foreach (string s in Input)
            {
                Numbers.Add(Int32.Parse(s));
            }
            if (Numbers.Count == Input.Count)
            {
                Numbers.Sort();
                result = Numbers[Numbers.Count / 2];
            }
            return result;
        }

        public void SecondStar()
        {
            //Inte alls färdig, tänkte helt fel.
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
                    //Console.WriteLine("Res: " + f + " | " + l);
                    //Console.WriteLine("Last: " + l);
                }
                else if (d.IndexOf(",") != -1)
                {
                    List<string> tPath = d.Split(',').ToList();
                    ResultInt += sortList(false, tPath, First, Second);
                    Path.Add(tPath);

                }
            }
            Console.WriteLine("Result: " + ResultInt);
        }
    }
}
