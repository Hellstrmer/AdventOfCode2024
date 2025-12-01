using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2025
{
    internal class _2025Day1
    {
        public List<string> ReadFile()
        {
            // 2867 to low
            bool example = true;
            string input = File.ReadAllText(example
                ? "C:\\Users\\clj608\\source\\repos\\Hellstrmer\\AdventOfCode2025\\2025\\Day1\\Example.txt".Trim()
                : "C:\\Users\\clj608\\source\\repos\\Hellstrmer\\AdventOfCode2025\\2025\\Day1\\Input.txt").Trim();
            List<string> Inputs = input.Split("\r\n").ToList();
            return Inputs;
        //C: \Users\clj608\Source\Repos\Hellstrmer\AdventOfCode2025\2025\Day1\Example.txt
        }

        public void FirstStar()
        {
            List<string> Inputs = ReadFile();
            string dir = "";
            int distance = 0;
            int res = 50;
            int timesZero = 0;
            foreach (string Input in Inputs)
            {
                dir = Input.Substring(0, 1);
                distance = Int32.Parse(Input.Substring(1));

                if (dir == "L")
                {
                    res = (res - distance % 100 + 100) % 100;
                }
                else if (dir == "R")
                {
                    res = (res + distance % 100 + 100) % 100;
                }
                if (res == 0)
                {
                    timesZero++;
                }
            }
            Console.WriteLine(timesZero);
        }
        public void SecondStar()
        {
            List<string> Inputs = ReadFile();
            string dir = "";
            int distance = 0;
            int res = 50;
            int resWithZero = 50;
            int timesZero = 0;
            foreach (string Input in Inputs)
            {
                dir = Input.Substring(0, 1);
                distance = Int32.Parse(Input.Substring(1));

                if (dir == "L")
                {
                    int t = ((res - distance) * 10) / 100;
                    if (t <= 0)
                    {
                        Console.WriteLine("Left: " + distance + " " + (t * -1).ToString());
                        timesZero += t * -1;
                    }
                    res = (res - distance % 100 + 100) % 100;
                }
                else if (dir == "R")
                {
                    int t = (res + distance) / 100;
                    if (t >= 1)
                    {
                        //Console.WriteLine("Left: " + ((res - distance) / 100).ToString());
                        Console.WriteLine("Right: " + distance + " "  + (t).ToString());
                        timesZero += t;
                    }
                    res = (res + distance % 100 + 100) % 100;
                }
                //if (res == 0)
                //{
                //    timesZero++;
                //}
            }
            Console.WriteLine(timesZero);
        }

    }
}
