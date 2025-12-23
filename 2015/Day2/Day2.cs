using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode._2015
{
    public class Day2(HelperClass helper)
    {     
        string Example = "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2015\\Day2\\Example.txt";
        string Input = "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2015\\Day2\\Input.txt";
        bool example = false;
        //3798106
        
        public void FirstStar()
        {
            List<string> input = example? helper.ReadFileList(Example) : helper.ReadFileList(Input);
            int result = 0;

            foreach (string item in input)
            {
                IList<int> sides = [];
                int t = item.LastIndexOf('x');
                int tx = item.IndexOf('x');
                int lw = Int32.Parse(item.Substring(0, tx));
                int wh = Int32.Parse(item.Substring(tx + 1, t- tx - 1));
                int hl = Int32.Parse(item.Substring(t + 1));
                int a = lw * wh;
                int b = wh * hl;
                int c = lw * hl;
                sides.Add(a);
                sides.Add(b);
                sides.Add(c);
                int smallest = sides.Min();

                int res = 2 * a + 2 * b + 2 * c + smallest;

                result += res;
            }
            
            Console.WriteLine("Result: " + result);
        }
        public void SecondStar()
        {
            List<string> input = example ? helper.ReadFileList(Example) : helper.ReadFileList(Input);
            int result = 0;

            foreach (string item in input)
            {
                IList<int> sides = [];
                int t = item.LastIndexOf('x');
                int tx = item.IndexOf('x');
                int lw = Int32.Parse(item.Substring(0, tx));
                int wh = Int32.Parse(item.Substring(tx + 1, t - tx - 1));
                int hl = Int32.Parse(item.Substring(t + 1));
                sides.Add(lw);
                sides.Add(wh);
                sides.Add(hl);
                int smallest = sides.Min();
                List<int> smallside = sides.OrderBy(s => s).ToList();
                int ribbon = (smallside[0] + smallside[0] + smallside[1] + smallside[1]) + (lw * wh * hl);

                result += ribbon;
            }

            Console.WriteLine("Result: " + result);
        }

    }
}
