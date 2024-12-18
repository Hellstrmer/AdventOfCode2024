using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace AdventOfCode._2024
{
    internal class Day11
    {      
        public List<string> ReadFile()
        {
            bool example = false;
            string input = File.ReadAllText(example
                ? "C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day11\\Example.txt".Trim()
                : "C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day11\\Input.txt").Trim();
            List<string> Inputs = input.Split(" ").ToList();
            return Inputs;
        }
        public void FirstStar()
        {
            List<string> list = ReadFile();
            int NumberOfBlinks = 75;
            List<string> ReturnList = new List<string>();
            for (int i = 0; i < NumberOfBlinks; i++)
            {
                ReturnList = Blink(list);
            }
            Console.WriteLine("Stones: " + ReturnList.Count);
        }

        private List<string> Blink(List<string> list)
        {
            ulong Multiply = 2024;
            for (int i = 0; i < list.Count; i++)
            {
                int MOD = list[i].Length % 2;
                if (ulong.Parse(list[i]) == 0)
                {
                    list[i] = "1";
                    i++;
                    MOD = list[i].Length % 2;
                }
                if (MOD == 0)
                {
                    string rem = list[i].Remove(list[i].Length / 2);
                    string end = list[i].Remove(0, list[i].Length / 2);
                    ulong remInt = ulong.Parse(rem);
                    ulong endInt = ulong.Parse(end);
                    list[i] = remInt.ToString();
                    list.Insert(i + 1, endInt.ToString());
                    i++;
                }
                else
                {
                    ulong t = ulong.Parse(list[i]) * Multiply;
                    list[i] = t.ToString();
                }
            }
            return list;
        }
       
    }
}
