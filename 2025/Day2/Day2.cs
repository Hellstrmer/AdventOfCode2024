using AdventOfCode.Helpers;
namespace AdventOfCode._2025
{
    internal class Day2(HelperClass helper)
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        public void FirstStar()
        {
            string Inputs = example ? helper.ReadFileString(Example) : helper.ReadFileString(Input);
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
        //public void SecondStar()
        //{
        //    string Inputs = example ? helper.ReadFileString(Example) : helper.ReadFileString(Input);
        //    List<String> Inp = Inputs.Split(',').ToList();
        //    ulong res = 0;
        //    foreach (var s in Inp)
        //    {
        //        ulong firstID = ulong.Parse(s.Substring(0, s.IndexOf("-")));
        //        ulong secondID = ulong.Parse(s.Substring(s.IndexOf("-") + 1));

        //        for (ulong i = firstID; i <= secondID; i++)
        //        {
        //            string t = i.ToString();
        //            //if (t.Length % 2 == 0)
        //            //{
        //            for (int j = 0; j < t.Length; j+=2)
        //            {
        //                string match = t.Substring(j, 1);
        //                string rest = t.Substring(j + 1);
        //                if (t.Length > 2 && j < t.Length -1)
        //                {
        //                    match = t.Substring(j, 2);
        //                    rest = t.Substring(j + 1);
        //                }
        //                if (rest.Contains(match))
        //                {
        //                    Console.WriteLine(t);
        //                    res += i;
        //                    break;
        //                }
                          

        //            }
                    
        //                //ulong firsthalf = ulong.Parse(t.Substring(0, t.Length / 2));
        //                //ulong secondhalf = ulong.Parse(t.Substring(t.Length / 2));
        //                //if (firsthalf == secondhalf)
        //                //    res += i;
        //            //}
        //        }
        //    }
        //    Console.WriteLine(res);
        //}
    }
}
