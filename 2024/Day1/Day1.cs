
namespace AdventOfCode._2024
{
    internal class Day1
    {
        public List<string> ReadFile()
        {
            bool example = false;
            string input = File.ReadAllText(example
                ? "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day4\\Example.txt".Trim()
                : "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day4\\Input.txt").Trim();
            List<string> Inputs = input.Split("\r\n").ToList();
            return Inputs;
        }

        public void FirstStar()
        {
            List<string> Inputs = ReadFile();
            List<int> First = new List<int>();
            List<int> Second = new List<int>();
            List<int> Result = new List<int>();
            int ResultInt = 0;

            foreach (string d in Inputs)
            {
                string f = d.Substring(0, d.IndexOf(' ')).Trim();
                string l = d.Substring(d.IndexOf(' ') + 1).Trim();
                First.Add(Int32.Parse(f));
                Second.Add(Int32.Parse(l));
            }
            First.Sort();
            Second.Sort();

            for (int i = 0; i < First.Count; i++)
            {
                if (First[i] < Second[i])
                {
                    Result.Add(Second[i] - First[i]);
                }
                else if (First[i] > Second[i])
                {
                    Result.Add(First[i] - Second[i]);
                } else if (First[i] == Second[i])
                {
                    Result.Add(0);
                }
            }
            foreach (int i in Result)
            {
                ResultInt += i;
            }
            Console.WriteLine(ResultInt);

        }

        public void SecondStar()
        {
            List<string> Inputs = ReadFile();
            List<int> First = new List<int>();
            List<int> Second = new List<int>();
            List<int> Result = new List<int>();
            int ResultInt = 0;
            int NumberOfMatch;

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
