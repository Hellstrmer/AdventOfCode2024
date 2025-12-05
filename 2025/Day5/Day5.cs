using AdventOfCode.Helpers;
namespace AdventOfCode._2025
{
    internal class Day5() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        public void FirstStar()
        {
            Solution();
        }
        public void SecondStar()
        {
            Solution();            
        }
        public void Solution()
        {
            List<String> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            int res = 0;
            List<ulong> StartID = new List<ulong>();
            List<ulong> EndID = new List<ulong>();
            List<ulong> ID = new List<ulong>();
            foreach (String s in Inputs)
            {
                if (s.Contains('-'))
                {
                    StartID.Add(ulong.Parse(s.Substring(0, s.IndexOf('-'))));
                    EndID.Add(ulong.Parse(s.Substring(s.IndexOf('-') + 1)));
                }
                else if (!s.Contains("-") && s.Length > 0)       
                    ID.Add(ulong.Parse(s));       
            }

            for (int i = 0; i < ID.Count; i++)
            {        
                for (int j = 0; j < StartID.Count; j++)                    
                {                                           
                            
                    if (ID[i] >= StartID[j] && ID[i] <= EndID[j])                            
                    {                                
                        res++; break;                           
                    }  
                }
            }
            Console.WriteLine(res);
        }       
    }
}
