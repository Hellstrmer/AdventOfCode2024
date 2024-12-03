
using System.Text.RegularExpressions;

namespace AdventOfCode._2024
{
    internal class Day3
    {
        public string ReadFile()
        {
            string input = "";
            bool example = true;
            if (example)
            {
                input = File.ReadAllText("C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day3\\Example.txt");
            } 
            else
            {
                input = File.ReadAllText("C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day3\\Input.txt");
            }

            input = input.Trim();
            return input;
        }

        public void FirstStar()
        {
            string message = ReadFile();

            //Console.WriteLine(message[0]);
            //string data = Input.ToString();
            List<string> list = new List<string>();
            List<List<string>> NumberList = new List<List<string>>();
            Regex TestMatch = new Regex(@"(?:mul)");
            MatchCollection result = TestMatch.Matches(message);
            int numbers = 0;
            int level = 0;
            foreach (Match match in result)
            {
                int back = 0;
                //Console.WriteLine(match);
                //Console.WriteLine(match.Index);
                for (int i = match.Index + 1; i < match.Index + 12; i++)
                {
                    if (i > message.Length - 1)
                    {
                        break;
                    }
                    if (message[i].ToString() == ")")
                    {
                        back = i + 1;
                    }
                    else if (i == match.Index + 12)
                    {
                        break;
                    }
                }
                if (back > 0 && back < message.Length - 1)
                {
                    list.Add(message.Substring(match.Index, back - match.Index).ToString());
                }
                else if (back > 0)
                {
                    list.Add(message.Substring(match.Index, message.Length - 1 - match.Index).ToString());
                }
            }

            foreach (string str in list)
            {
                level += 1;
                NumberList.Add(new List<string>());
                int firstMatch = str.IndexOf("(");
                int SecondMatch = str.IndexOf(",");
                int firstMatch2 = str.IndexOf("(");
                int SecondMatch2 = str.IndexOf(","); 
                bool tryP = false;
                //Console.WriteLine(str);
                NumberList[level - 1].Add(Int32.TryParse(str.Substring(firstMatch +1, SecondMatch - firstMatch - 1)));
                NumberList[level - 1].Add(str.Substring(firstMatch2 +1, SecondMatch2 - firstMatch2 - 1));
                Console.WriteLine("numb: " + str.Substring(firstMatch +1, SecondMatch - firstMatch -1));

                tryP = Int32.TryParse(str[i].ToString(), out numbers);
                if (tryP)
                {
                    Console.WriteLine(str[i]);
                    NumberList[level - 1].Add(str[i].ToString());
                }
                /*                for (int i = 0; i < str.Length; i++)
                                {


                                    tryP = Int32.TryParse(str[i].ToString(), out numbers);
                                    if (tryP)
                                    {
                                        Console.WriteLine(str[i]);
                                        NumberList[level - 1].Add(str[i].ToString());
                                    }
                                }*/
            }
            /*foreach (List<string> l in NumberList)
            {
                int numb = 0;
                int nextNumb = 0;
                string all = "";
                foreach (string str in l)
                {
                    all += str;
                    numb = Int32.Parse(str);
                }
                numb = Int32.Parse(all);
            }*/

        }


        public void SecondStar()
        {
            string message = ReadFile();

            List<string> Inputs = message.Split("\r\n").ToList();

        }
    }
}
