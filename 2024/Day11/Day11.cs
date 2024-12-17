using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace AdventOfCode._2024
{
    internal class Day11
    {
        int Multiply = 2024;

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
            //string message = ReadFile();
            List<string> list = ReadFile();
            int NumberOfBlinks = 25;
            List<string> ReturnList = new List<string>();
            //ReturnList = Blink(list);
            for (int i = 0; i < NumberOfBlinks; i++)
            {
                ReturnList = Blink(list);
            }

            Console.WriteLine("Stones: " + ReturnList.Count);

            /*foreach (string input in ReturnList)
            {
                Console.WriteLine("Input: " + input);
            }*/

        }

        private List<string> Blink(List<string> list)
        {
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
                    ulong t = ulong.Parse(list[i]) * 2024;
                    list[i] = t.ToString();
                }
            }
            return list;
        }
        public void SecondStar()
        {
            
        }
       
    }
}
