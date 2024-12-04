
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode._2024
{
    internal class Day4
    {
        public string ReadFile()
        {
            bool example = false;
            string input = File.ReadAllText(example
                ? "C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day4\\Example.txt"
                : "C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day4\\Input.txt").Trim();
            return input;
        }

        public void FirstStar() 
        {
            string message = ReadFile();

            List<string> Inputs = message.Split("\r\n").ToList();
            bool Found = false;
            int TotalFinds = 0;

            for (int x = 0; x < Inputs.Count; x++)
            {
                //Console.WriteLine(Input);
                for (int y = 0; y < Inputs.Count; y++)
                {
                    if (Inputs[x][y] == 'X')
                    {
                        TotalFinds += find(Inputs, x, y);
                        //Console.WriteLine(Inputs[i][y]);
                        /*if (Found)
                        {
                            //Console.WriteLine("i " + i + " y " + y);
                            Found = false;
                            TotalFinds++;
                        }*/
                    }                    
                }                
            }

            Console.WriteLine("Numbers: " + TotalFinds);
        }

        public int find(List <string> Input, int x, int y)
        {
            bool found = false;
            int NumberOfFinds = 0;
            if (y < Input[x].Length - 3
                            && Input[x][y + 1] == 'M'
                            && Input[x][y + 2] == 'A'
                            && Input[x][y + 3] == 'S')
            {
                found = true;
                NumberOfFinds++;
                Console.WriteLine("Right " + "x " + x + " y " + y);
            }
            if (y > 2
                && Input[x][y - 1] == 'M'
                && Input[x][y - 2] == 'A'
                && Input[x][y - 3] == 'S')
            {
                found = true;
                NumberOfFinds++;
                Console.WriteLine("Left " + "x " + x + " y " + y);
            }
            if (x < Input.Count - 3
                && Input[x + 1][y] == 'M'
                && Input[x + 2][y] == 'A'
                && Input[x + 3][y] == 'S')
            {
                found = true;
                NumberOfFinds++;
                Console.WriteLine("Down " + "i " + x + " y " + y);
            }
            if (x > 2
                && Input[x - 1][y] == 'M'
                && Input[x - 2][y] == 'A'
                && Input[x - 3][y] == 'S')
            {
                found = true;
                NumberOfFinds++;
                Console.WriteLine("Up " + "i " + x + " y " + y);
            }
            //Snett upp Vänster
            if (x > 2 && y > 2
                && Input[x - 1][y - 1] == 'M'
                && Input[x - 2][y - 2] == 'A'
                && Input[x - 3][y - 3] == 'S')
            {
                found = true;
                NumberOfFinds++;
                Console.WriteLine("Snett upp Vänster " + "x " + x + " y " + y);
            }
            //Snett Upp höger
            if (x > 2 && y < Input[x].Length - 3
                && Input[x - 1][y + 1] == 'M'
                && Input[x - 2][y + 2] == 'A'
                && Input[x - 3][y + 3] == 'S')
            {
                found = true;
                NumberOfFinds++;
                Console.WriteLine("Snett upp höger " + "x " + x + " y " + y);
            }
            //Snett ner vänster
            if (x < Input.Count - 3 && y > 2
                && Input[x + 1][y - 1] == 'M'
                && Input[x + 2][y - 2] == 'A'
                && Input[x + 3][y - 3] == 'S')
            {
                found = true;
                NumberOfFinds++;
                Console.WriteLine("Snett ner Vänster " + "x " + x + " y " + y);
            }
            //Snett ner höger
            if (x < Input.Count - 3 && y < Input[x].Length - 3
                && Input[x + 1][y + 1] == 'M'
                && Input[x + 2][y + 2] == 'A'
                && Input[x + 3][y + 3] == 'S')
            {
                found = true;
                NumberOfFinds++;
                Console.WriteLine("Snett ner höger " + "x " + x + " y " + y);
            }

            return NumberOfFinds;
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
               for(int y = 0; y < Second.Count; y++)
                {
                    if (First[i] == Second[y])
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
