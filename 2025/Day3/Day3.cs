using AdventOfCode.Helpers;
namespace AdventOfCode._2025
{
    internal class Day3(HelperClass helper)
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        public void FirstStar()
        {
            List<String> Inputs = example ? helper.ReadFileList(Example) : helper.ReadFileList(Input);            
            int res = 0;

            foreach(var s in Inputs)
            {
                int Biggest = 0;
                int BiggestPos = 0;
                int secondBiggest = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    int n = Int32.Parse(s[i].ToString());
                    if (n > Biggest && i < s.Length -1)
                    {
                        Biggest = n;
                        BiggestPos = i;
                    }
                }
                for (int i = BiggestPos + 1; i < s.Length; i++)
                {
                    int n = Int32.Parse(s[i].ToString());
                    if (n > secondBiggest)                    
                        secondBiggest = n;                    
                }                
                res += Int32.Parse(Biggest.ToString() + secondBiggest.ToString());
            }
            Console.WriteLine(res);
        }
        public void SecondStar()
        {
            List<String> Inputs = example ? helper.ReadFileList(Example) : helper.ReadFileList(Input);
            int res = 0;

            foreach (var s in Inputs)
            {
                int Biggest = 0;
                int BiggestPos = 0;
                int secondBiggest = 0;
                var t = s.ToList();
                var resList = new List<int>();

                for(int i = 0; i < t.Count; i++) {
                    {
                        if (resList.Count <= 12)
                        resList.Add(t.Max());
                    }
                Console.WriteLine(t);
                
                res += Int32.Parse(Biggest.ToString() + secondBiggest.ToString());
            }
            Console.WriteLine(res);
        }
    }
}
