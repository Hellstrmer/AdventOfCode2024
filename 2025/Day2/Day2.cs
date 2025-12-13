using AdventOfCode.Helpers;
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
            List<String> Inp = Inputs.Split(',').ToList();
            ulong res = 0;
            foreach(var s in Inp)
            {
                ulong firstID = ulong.Parse(s.Substring(0, s.IndexOf("-")));
                ulong secondID = ulong.Parse(s.Substring(s.IndexOf("-") +1));

                for (ulong i = firstID; i <= secondID; i++)
                {
                    string t = i.ToString();
                    if (t.Length % 2 == 0)
                    {
                        ulong firsthalf = ulong.Parse(t.Substring(0, t.Length /2));
                        ulong secondhalf = ulong.Parse(t.Substring(t.Length / 2));                        
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
            List<String> Inp = Inputs.Split(',').ToList();
            List<ulong> ResList = new List<ulong>();
            foreach (var s in Inp)
            {
                ulong firstID = ulong.Parse(s.Substring(0, s.IndexOf("-")));
                ulong secondID = ulong.Parse(s.Substring(s.IndexOf("-") + 1));
                for (ulong i = firstID; i <= secondID; i++)
                {
                    string ID = i.ToString();
                    for (int j = ID.Length; j > 0; j--)
                    {
                        if (ID.Length % j == 0 && j > 1)
                        {
                            var Splited = ID.Chunk(ID.Length / j)
                                .Select(chars => new string(chars))
                                .ToList();                            
                            bool Match = true;
                            
                            if (Splited.All(ID => ID == Splited[0]))
                            {                    
                                ResList.Add(i);                    
                                break;                
                            }
                            //foreach (var part in Splited)
                            //{
                            //    if (part != Splited[0])
                            //    {
                            //        Match = false;
                            //        break;
                            //    }
                            //}
                            //if (Match)
                            //{
                            //    ResList.Add(i);
                            //    break;
                            //}
                        }
                    }
                }
            }
            Console.WriteLine(ResList.Sum(r => (decimal)r));
        }
    }
}
