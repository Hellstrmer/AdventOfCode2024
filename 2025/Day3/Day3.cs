using AdventOfCode.Helpers;
namespace AdventOfCode._2025
{
    internal class Day3() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        int foundPos = 0;
        public void FirstStar()
        {
            Solution(2);
        }
        public void SecondStar()
        {
            Solution(12);
        }
        void Solution(int numbs)
        {
            List<String> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            ulong res = 0;
            foreach (var s in Inputs)
            {
                List<ulong> Total = new List<ulong>();  
                int BiggestPos = s.Length - numbs + 1;
                int start = 0;
                while (Total.Count < numbs)
                {                    
                    Total.Add(findBiggest(start, BiggestPos, s));
                    start = foundPos + 1;
                    BiggestPos++;
                }           
                res += ulong.Parse(String.Join("", Total));
            }
            Console.WriteLine(res);
        }
        ulong findBiggest(int start, int end, string s)
        {
            ulong Biggest = 0;
            for (int i = start; i < end; i++)
            {       
                ulong n = (ulong)(s[i] - '0');             
                if (n > Biggest)                    
                {                        
                    Biggest = n;                        
                    foundPos = i;                    
                }                
            }
            return Biggest;
        }
    }
}
