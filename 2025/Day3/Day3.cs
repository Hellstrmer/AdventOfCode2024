using AdventOfCode.Helpers;
namespace AdventOfCode._2025
{
    internal class Day3(HelperClass helper)
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        int foundPos = 0;
        public void FirstStar()
        {
            List<String> Inputs = example ? helper.ReadFileList(Example) : helper.ReadFileList(Input);
            int res = 0;

            foreach (var s in Inputs)
            {
                int Biggest = 0;
                int BiggestPos = 0;
                int secondBiggest = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    int n = Int32.Parse(s[i].ToString());
                    if (n > Biggest && i < s.Length - 1)
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
            ulong res = 0;

            foreach (var s in Inputs)
            {
                ulong Biggest = 0;
                List<ulong> Total = new List<ulong>();

                ulong secondBiggest = 0;
                var t = s.ToList();
                var resList = new List<ulong>();
                int BiggestPos = t.Count - 11;
                
                int start = 0;

                while (Total.Count < 12)
                {
                    ulong resNumb = findBiggest(start, BiggestPos, s);
                    Total.Add(resNumb);
                    start = foundPos + 1;
                    BiggestPos++;
                }
                string resString = "";
                foreach (var str in Total)
                {
                    resString += str.ToString();
                }
                res += ulong.Parse(resString);
            }
            Console.WriteLine(res);
        }

        ulong findBiggest(int start, int end, string s)
        {
            ulong Biggest = 0;

            for (int i = start; i < end; i++)
            {
                {
                    ulong n = ulong.Parse(s[i].ToString());
                    //Console.WriteLine("Numb: " + n);
                    if (n > Biggest && i < s.Length)
                    {
                        Biggest = n;
                        foundPos = i;
                    }
                }
            }

            return Biggest;
        }
    }
}
