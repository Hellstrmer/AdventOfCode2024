using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode._2015
{
    public class Day3(HelperClass helper)
    {
        private Point pos;
        private Point posRob;
        string Example = "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2015\\Day3\\Example.txt";
        string Input = "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2015\\Day3\\Input.txt";
        bool example = false;
        //3798106
        
        public void FirstStar()
        {
            string input = example? helper.ReadFileString(Example) : helper.ReadFileString(Input);
            int result = 0;
            char north = '^';
            char east = '>';
            char south = 'v';
            char west = '<';
            List<Point> Visits = new List<Point>();
            pos = new Point(0, 0);
            Visits.Add(pos);
            List<Point> VisitsRob = new List<Point>();
            posRob = new Point(0, 0);
            VisitsRob.Add(posRob);
            int start = 0;

            foreach (var item in input)
            {
                start ++;
                if (item == north)
                {                    
                    if (start % 2 == 0)
                    {
                        pos.X += 1;
                    } else
                    {
                        posRob.X += 1;
                    }
                }   
                else if (item == east)
                {
                    if (start % 2 == 0)
                    {
                        pos.Y += 1;
                    }
                    else
                    {
                        posRob.Y += 1;
                    }
                }
                else if (item == south)
                {
                    if (start % 2 == 0)
                    {
                        pos.X -= 1;
                    }
                    else
                    {
                        posRob.X -= 1;
                    }
                }
                else if (item == west)
                {
                    if (start % 2 == 0)
                    {
                        pos.Y -= 1;
                    }
                    else
                    {
                        posRob.Y -= 1;
                    }
                }

                if (!Visits.Contains(pos))
                {
                    Visits.Add(pos);
                }
                if (!Visits.Contains(posRob))
                {
                    Visits.Add(posRob);
                }
            }
            result = Visits.Count;
            
            Console.WriteLine("Result: " + result);
        }       
    }
}
