using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Helpers;
using System.Security.Cryptography;

namespace AdventOfCode._2015
{
    public class Day4(HelperClass helper)
    {
        MD5 md5;
        string Example = "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2015\\Day4\\Example.txt";
        string Input = "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2015\\Day4\\Input.txt";
        bool example = false;
        //3798106
        
        public void FirstStar()
        {
            string input = example? helper.ReadFileString(Example) : helper.ReadFileString(Input);
            int result = 0;
            int number = 0;

            while (true)
            {
                number++;

                string inpu = input + number;
                byte[] tmpSource;
                byte[] tmpHash;

                tmpSource = ASCIIEncoding.ASCII.GetBytes(inpu);
                tmpHash = md5.ComputeHash(tmpSource);

                string hashString = BitConverter.ToString(tmpHash).Replace("-", "").ToLower();

                if (hashString.StartsWith("000000"))
                {
                   Console.WriteLine("Result: " + number);
                    break;
                }
            }
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
