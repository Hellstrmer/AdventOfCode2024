using AdventOfCode.Helpers;
using System.Linq;
namespace AdventOfCode._2025
{
    internal class Day6() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        public void FirstStar()
        {
            List<String> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            var Inp = Inputs.Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToList();
            Inp.Reverse();
            List<string> Operation = Inp[0].ToList();
            List<ulong> Results = new List<ulong>();
            List<ulong> Cephalopod = new List<ulong>();

            for (int i = 0; i < Inp.Count; i ++)
            {
                ulong Numb = 0;
                Cephalopod.Clear();
                for (int j = 0; j < Inp[i].Length; j++)
                {
                    var t = Inp[i];
                    bool te = ulong.TryParse(Inp[i].ToString(), out Numb);
                    if (ulong.TryParse(Inp[i][j].ToString(), out Numb))
                        Cephalopod.Add(Numb);                    
                }
                for (int k = 0; k < Operation.Count; k++)
                {
                    if (Results.Count < Operation.Count)
                        Results.Add((ulong)(Operation[k] == "*" ? 1 : 0));
                    if (Cephalopod.Count > 0)                    
                        Results[k] = Operation[k] == "+" ? Results[k] += Cephalopod[k] : Results[k] *= Cephalopod[k];  
                } 
            }
            Console.WriteLine(Results.Sum(r => (decimal)r));
        }
        public void SecondStar()
        {
            List<String> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            List<char[]> Inp = Inputs.Select(x => x.ToCharArray()).ToList();
            List<string> resList = new List<string>();            
            List<String> Operations = new List<string>();
            List<ulong> Res = new List<ulong>();
            int Index = 0;
            foreach (char c in Inp.Last())
            {
                if (c == '*' || c == '+')                
                    Operations.Add(c.ToString());                
            }
            for (int i = 0; i < Inp.Count -1; i++)
            {
                for (int j = 0; j < Inp[i].Length; j++)
                {
                    if (i == 0)                    
                        resList.Add(Inp[i][j].ToString());                    
                    else 
                        resList[j] += Inp[i][j].ToString();
                }                
            }
            Res.Add(1);
            for (int i = 0; i < resList.Count; i++)
            {
                if (!ulong.TryParse(resList[i], out ulong resUlong))
                {
                    Index++;
                    Res.Add(Operations[Index] == "*" ? (ulong)1 : (ulong)0);
                    continue;
                }
                Res[Index] = Operations[Index] == "*" ? Res[Index] * resUlong : Res[Index] + resUlong;                        
            }
            Console.WriteLine(Res.Sum(r => (decimal)r));
        }        
    }
}
