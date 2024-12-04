
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode._2024
{
    internal class Day4
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
            int TotalFinds = 0;

            for (int x = 0; x < Inputs.Count; x++)
            {
                for (int y = 0; y < Inputs.Count; y++)
                {
                    if (Inputs[x][y] == 'X')
                        TotalFinds += find(Inputs, x, y);               
                }                
            }
            Console.WriteLine("Numbers: " + TotalFinds);
        }

        public void SecondStar()
        {
            List<string> Inputs = ReadFile();
            int TotalFinds = 0;
            for (int x = 0; x < Inputs.Count; x++)
            {
                for (int y = 0; y < Inputs.Count; y++)
                {
                    if (Inputs[x][y] == 'A')                    
                        TotalFinds += findMas(Inputs, x, y);                    
                }
            }
            Console.WriteLine("Numbers: " + TotalFinds);
        }

        public int find(List <string> Input, int x, int y)
        {
            int NumberOfFinds = 0;
            if (y < Input[x].Length - 3
                && Input[x][y + 1] == 'M'
                && Input[x][y + 2] == 'A'
                && Input[x][y + 3] == 'S')
            {
                NumberOfFinds++;
            }
            if (y > 2
                && Input[x][y - 1] == 'M'
                && Input[x][y - 2] == 'A'
                && Input[x][y - 3] == 'S')
            {
                NumberOfFinds++;
            }
            if (x < Input.Count - 3
                && Input[x + 1][y] == 'M'
                && Input[x + 2][y] == 'A'
                && Input[x + 3][y] == 'S')
            {
                NumberOfFinds++;
            }
            if (x > 2
                && Input[x - 1][y] == 'M'
                && Input[x - 2][y] == 'A'
                && Input[x - 3][y] == 'S')
            {
                NumberOfFinds++;
            }
            //Snett upp Vänster
            if (x > 2 && y > 2
                && Input[x - 1][y - 1] == 'M'
                && Input[x - 2][y - 2] == 'A'
                && Input[x - 3][y - 3] == 'S')
            {
                NumberOfFinds++;
            }
            //Snett Upp höger
            if (x > 2 && y < Input[x].Length - 3
                && Input[x - 1][y + 1] == 'M'
                && Input[x - 2][y + 2] == 'A'
                && Input[x - 3][y + 3] == 'S')
            {
                NumberOfFinds++;
            }
            //Snett ner vänster
            if (x < Input.Count - 3 && y > 2
                && Input[x + 1][y - 1] == 'M'
                && Input[x + 2][y - 2] == 'A'
                && Input[x + 3][y - 3] == 'S')
            {
                NumberOfFinds++;
            }
            //Snett ner höger
            if (x < Input.Count - 3 && y < Input[x].Length - 3
                && Input[x + 1][y + 1] == 'M'
                && Input[x + 2][y + 2] == 'A'
                && Input[x + 3][y + 3] == 'S')
            {
                NumberOfFinds++;
            }
            return NumberOfFinds;
        }

        public int findMas(List<string> Input, int x, int y)
        {
            int NumberOfFinds = 0;
            if (y > 0 && x > 0 && y < Input[x].Length - 1 && x < Input.Count - 1)
            {
                // M , S
                if (Input[x - 1][y - 1] == 'M' 
                    && Input[x - 1][y + 1] == 'S'
                    && Input[x + 1][y - 1] == 'M'
                    && Input[x + 1][y + 1] == 'S')
                {
                    NumberOfFinds++;
                }
                // M, M
                if (Input[x - 1][y + 1] == 'M'
                    && Input[x + 1][y - 1] == 'S'
                    && Input[x - 1][y - 1] == 'M'
                    && Input[x + 1][y + 1] == 'S')
                {
                    NumberOfFinds++;
                }
                // S , M
                if (Input[x - 1][y - 1] == 'S'
                    && Input[x - 1][y + 1] == 'M'
                    && Input[x + 1][y - 1] == 'S'
                    && Input[x + 1][y + 1] == 'M')
                {
                    NumberOfFinds++;
                }
                //S , S
                if (Input[x - 1][y + 1] == 'S'
                    && Input[x + 1][y - 1] == 'M'
                    && Input[x - 1][y - 1] == 'S'
                    && Input[x + 1][y + 1] == 'M')
                {
                    NumberOfFinds++;
                }
            }
            return NumberOfFinds;
        }       
    }
}
