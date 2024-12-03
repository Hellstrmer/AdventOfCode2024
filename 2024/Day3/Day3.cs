using System.Text.RegularExpressions;
namespace AdventOfCode._2024
{
    internal class Day3
    {
        public string ReadFile()
        {
            bool example = false;
            string input = File.ReadAllText(example 
                ? "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day3\\Example.txt" 
                : "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day3\\Input.txt").Trim();
            return input;
        }
        public void FirstStar()
        {
            string message = ReadFile();
            List<string> list = new List<string>();
            Regex TestMatch = new Regex(@"(?:mul)");
            MatchCollection result = TestMatch.Matches(message);
            foreach (Match match in result)
            {
                int back = 0;
                for (int i = match.Index + 1; i < match.Index + 12; i++)
                {
                    if (i > message.Length - 1 || i == match.Index + 12)
                        break;
                    
                    if (message[i].ToString() == ")")                    
                        back = i + 1;                           
                }
                if (back > 0 && back < message.Length - 1)                
                    list.Add(message.Substring(match.Index, back - match.Index).ToString());                
            }
            sort(list);
        }
        public void SecondStar()
        {
            string message = ReadFile();
            List<string> list = new List<string>();
            List<List<int>> NumberList = new List<List<int>>();
            Regex TestMatch = new Regex(@"(?:mul)|don't|do");
            MatchCollection result = TestMatch.Matches(message);
            bool matchOK = true;
            foreach (Match match in result)
            {
                if (match.ToString() == "do")                
                    matchOK = true;

                else if (match.ToString() == "don't")                
                    matchOK = false;
                
                int back = 0;
                if (matchOK)
                {
                    for (int i = match.Index + 1; i < match.Index + 12; i++)
                    {
                        if (i > message.Length - 1 || i == match.Index + 12 || match.ToString() == "do")
                            break;
                        
                        if (message[i].ToString() == ")")                        
                            back = i + 1;                        
                    }
                }                
                if (back > 0 && back < message.Length - 1)                
                    list.Add(message.Substring(match.Index, back - match.Index).ToString());                
            }
            sort(list);
        }
        public void sort(List<string> list)
        {
            int numbers = 0;
            foreach (string str in list)
            {
                int firstMatch = str.IndexOf("(");
                int SecondMatch = str.IndexOf(",");
                int SecondMatch2 = str.IndexOf(")");
                bool tryP1 = false;
                if (firstMatch > 0 && SecondMatch > 0 && SecondMatch > 0 && SecondMatch2 > 0
                    && SecondMatch > firstMatch && SecondMatch2 > SecondMatch)
                {
                    tryP1 = Int32.TryParse(str.Substring(firstMatch + 1, SecondMatch - firstMatch - 1),  out int f);
                    tryP1 = Int32.TryParse(str.Substring(SecondMatch + 1, SecondMatch2 - SecondMatch - 1), out int l);
                    if (tryP1)                    
                        numbers += f * l;                    
                }
            }
            Console.WriteLine("Numbers: " + numbers);
        }
    }
}
