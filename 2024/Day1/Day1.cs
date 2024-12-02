
namespace AdventOfCode._2024
{
    internal class Day1
    {
        public string ReadFile()
        {
            string input = "";
            bool example = false;
            if (example)
            {
                input = File.ReadAllText("C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day1\\Example.txt");
            } 
            else
            {
                input = File.ReadAllText("C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day1\\Input.txt");
            }

            input = input.Trim();
            return input;
        }

        public void FirstStar() 
        {
            string message = ReadFile();

            List<string> Inputs = message.Split("\r\n").ToList();

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
