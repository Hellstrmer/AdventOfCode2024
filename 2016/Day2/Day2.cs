using AdventOfCode.Helpers;
using System;
using System.Drawing;
namespace AdventOfCode._2016
{
    internal class Day2() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = true;
        public void FirstStar()
        {
            var Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            //var inp = Inputs.Split('').ToList();

            var t = new Dictionary<string, int>();
            var Numbers = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            var start = 4;

            // U = Up
            // D = Down
            // R = Right
            // L = Left
            string Code = "";
            foreach (var input in Inputs)
            {
                foreach (var press in input)
                {
                    if (press == 'U' && start - 3 >= 0)
                    {
                        start -= 3;
                    }
                    else if (press == 'D' && start + 3 <= 8)
                    {
                        start += 3;
                    }
                    else if (press == 'R' && start + 1 <= 8)
                    {
                        start += 1;
                    }
                    else if (press == 'L' && start - 1 >= 0)
                    {
                        start -= 1;
                    }
                }
                Code += Numbers[start].ToString();
            }
                
            Console.WriteLine(Code);
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
            int counter = 0;
            foreach (var Input in inp)
            {
                counter++;
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
                    if (yList.Count == 0)
                        yList.Add(str);
                    if (yList.Contains(str) && yList[yList.Count - 1] != str)
                        break;
                    else
                        yList.Add(str);
                }

                else if (direction == 1)
                {
                    x += distance;
                    if (xList.Count == 0)
                        xList.Add(str);
                    if (xList.Contains(str) && xList[xList.Count - 1] != str)
                        break;
                    else
                        xList.Add(str);
                }
                else if (direction == 2)
                {
                    y -= distance;
                    if (yList.Count == 0)
                        yList.Add(str);
                    if (yList.Contains(str) && yList[yList.Count - 1] != str)
                        break;
                    else
                        yList.Add(str);
                }
                else
                {
                    x -= distance;
                    if (xList.Count == 0)
                        xList.Add(str);
                    if (xList.Contains(str) && xList[xList.Count - 1] != str)
                        break;
                    else
                        xList.Add(str);
                }
            }
            Console.WriteLine(counter);
        }
    }
}
