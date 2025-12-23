using AdventOfCode.Helpers;
using System;
using System.Drawing;
namespace AdventOfCode._2016
{
    internal class Day1() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        public void FirstStar()
        {
            var Inputs = example ? ReadFileString(Example) : ReadFileString(Input);
            var inp = Inputs.Split(',').ToList();
            int x = 0;
            int y = 0;
            int direction = 0;
            foreach (var Input in inp)
            {
                var str = Input.Trim();
                var dir = str[0].ToString().Trim();
                var distance = Int32.Parse(str.Substring(1));

                if ( dir == "R") 
                    direction = (direction +1 ) % 4;
                else                
                    direction = (direction -1 + 4) % 4;

                if (direction == 0)
                    y += distance;
                else if (direction == 1)
                    x += distance;
                else if (direction == 2)
                    y -= distance;
                else 
                    x -= distance;      
            }            
            Console.WriteLine(Math.Abs(x) + Math.Abs(y));
        }


        public void SecondStar()
        {
            var Inputs = example ? ReadFileString(Example) : ReadFileString(Input);
            var inp = Inputs.Split(',').ToList();
            int x = 0;
            int y = 0;
            List<string> xList = new List<string>();
            List<string> yList = new List<string>();
            int direction = 0;
            foreach (var Input in inp)
            {
                var str = Input.Trim();
                var dir = str[0].ToString().Trim();
                var distance = Int32.Parse(str.Substring(1));

                if (dir == "R")
                    direction = (direction + 1) % 4;
                else
                    direction = (direction - 1 + 4) % 4;

                if (direction == 0)
                {
                    y += distance;
                    yList.Add(str);
                }

                else if (direction == 1)
                {
                    x += distance;
                    xList.Add(str);
                }
                else if (direction == 2)
                {
                    y -= distance;
                    yList.Add(str);
                }
                else
                {
                    x -= distance;
                    xList.Add(str);
                }
            }
            Console.WriteLine(Math.Abs(x) + Math.Abs(y));
        }
    }
}
