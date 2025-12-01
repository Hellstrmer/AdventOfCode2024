using AdventOfCode.Helpers;

namespace AdventOfCode._2015
{
    public class Day1(HelperClass helper)
    {     
        string Example = "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2015\\Day1\\Example.txt";
        string Input = "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2015\\Day1\\Input.txt";
        bool example = false;
        
        public void FirstStar()
        {
            string input = example? helper.ReadFileString(Example) : helper.ReadFileString(Input);
            int result = 0;
            foreach (var s in input)
            {
                if (s.ToString() == "(")
                {
                    result++;
                }
                else if (s.ToString() == ")")
                {
                    result--;
                }
            }
            Console.WriteLine("Result: " + result);
        }
        public void SecondStar()
        {
            string input = example ? helper.ReadFileString(Example) : helper.ReadFileString(Input);
            int result = 0;
            int basement = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString() == "(")
                {
                    result++;
                }
                else if (input[i].ToString() == ")")
                {
                    result--;
                }
                if (result == -1)
                {
                    basement = i + 1;
                    break;
                }
            }

            Console.WriteLine("Result: " + basement);
        }

    }
}
