using AdventOfCode.Helpers;
using System;
namespace AdventOfCode._2025
{
    internal class Day2 : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        public void FirstStar()
        {
            string Inputs = example ? ReadFileString(Example) : ReadFileString(Input);
            var Inp = Inputs.Split(',')
                .Select(s => s.Split('-'))    
                .Select(ID => (First: ulong.Parse(ID[0]), Second: ulong.Parse(ID[1])))    
                .ToList();
            ulong res = 0;
            foreach(var s in Inp)
            {                
                for (ulong i = s.First; i <= s.Second; i++)
                {
                    string ID = i.ToString();
                    if (ID.Length % 2 == 0)
                    {
                        var Splited = ID.Chunk(ID.Length /2)
                            .Select(IDs => ulong.Parse(new string(IDs)))
                            .ToList();
                        ulong firsthalf = Splited[0];
                        ulong secondhalf = Splited[1];
                        if (firsthalf == secondhalf)  
                            res += i;                        
                    }
                }
            }
            Console.WriteLine(res);
        }
        public void SecondStar()
        {
            string Inputs = example ? ReadFileString(Example) : ReadFileString(Input);
            var Inp = Inputs.Split(',')
                .Select(s => s.Split('-'))
                .Select(ID => (First: ulong.Parse(ID[0]), Second: ulong.Parse(ID[1])))
                .ToList();
            List<ulong> ResList = new List<ulong>();
            foreach (var s in Inp)
            {
                for (ulong i = s.First; i <= s.Second; i++)
                {
                    string ID = i.ToString();
                    for (int j = ID.Length; j > 0; j--)
                    {
                        if (ID.Length % j == 0 && j > 1)
                        {
                            var Splited = ID.Chunk(ID.Length / j)
                                .Select(IDs => new string(IDs))
                                .ToList();                             
                            if (Splited.All(ID => ID == Splited[0]))
                            {                    
                                ResList.Add(i);                    
                                break;                
                            }                            
                        }
                    }
                }
            }
            Console.WriteLine(ResList.Sum(r => (decimal)r));
        }
    }
}
