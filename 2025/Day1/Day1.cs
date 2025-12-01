using AdventOfCode.Helpers;

namespace AdventOfCode._2025
{
    internal class Day1(HelperClass helper)
    {
        string Example = "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2025\\Day1\\Example.txt";
        string Input = "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2025\\Day1\\Input.txt";
        bool example = false;

        public void FirstStar()
        {
            List<string> Inputs = example ? helper.ReadFileList(Example) : helper.ReadFileList(Input);            
            
            int res = 50;
            int timesZero = 0;
            foreach (string Input in Inputs)
            {
                string dir = Input.Substring(0, 1);
                int distance = Int32.Parse(Input.Substring(1));
                if (dir == "L")                
                    res = (res - distance % 100 + 100) % 100;
                
                else if (dir == "R")                
                    res = (res + distance % 100 + 100) % 100;
                
                if (res == 0)                
                    timesZero++;                
            }
            Console.WriteLine(timesZero);
        }
        public void SecondStar()
        {
            List<string> Inputs = example ? helper.ReadFileList(Example) : helper.ReadFileList(Input);
            int res = 50;
            int timesZero = 0;
            foreach (string Input in Inputs)
            {
                string dir = Input.Substring(0, 1);
                int distance = Int32.Parse(Input.Substring(1));                
                if (dir == "L")
                {
                    int t = ((res - distance));
                    int count = 0;
                    for (int i = res; i >= t; i--)
                    {
                        if (i % 100 == 0 && count != 0)                         
                            timesZero += 1;                        
                        count++;
                    }
                    res = (res - distance % 100 + 100) % 100;
                }
                else if (dir == "R")
                {
                    int t = (res + distance);
                    int count = 0;
                    for (int i = res; i <= t;i++)
                    {    
                        if (i % 100 == 0 && count != 0)                        
                            timesZero += 1;                        
                        count++;
                    }
                    res = (res + distance % 100 + 100) % 100;
                }
            }
            Console.WriteLine(timesZero);
        }
    }
}
