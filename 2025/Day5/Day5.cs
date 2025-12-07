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
        public void SecondStar()
        {
            List<String> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            ulong res = 0;
            List<List<ulong>> IDs = new List<List<ulong>>();
            List<ulong> FreshIDStart = new List<ulong>();
            List<ulong> FreshIDEnd = new List<ulong>();
            List<ulong> resID = new List<ulong>();
            ulong sID = 0;
            ulong eID = 0;
            List<ulong> StartID = new List<ulong>();
            List<ulong> EndID = new List<ulong>();
            var Ranges = new List<(ulong Start, ulong End)>();
            var FreshRanges = new List<(ulong Start, ulong End)>();
            foreach (String s in Inputs)
            {
                if (s.Contains('-'))
                {
                    var start = ulong.Parse(s.Substring(0, s.IndexOf('-')));
                    var end = ulong.Parse(s.Substring(s.IndexOf('-') + 1));
                    Ranges.Add((start, end));
                }
            }
            Ranges = Ranges.OrderBy(r => r.Start).ToList();
            FreshRanges.Add(Ranges[0]);
            //FreshIDEnd.Add(Ranges[0].End);
            FreshIDStart.Add(Ranges[0].Start);
            FreshIDEnd.Add(Ranges[0].End);

            //for (int i = 1; i < Ranges.Count; i++)
            //{
            //    for (int j = 0; j < FreshRanges.Count; j++)
            //    {
            //        if (Ranges[i].Start > FreshRanges[j].Start && Ranges[i].Start < FreshRanges[j].End && Ranges[i].End > FreshRanges[j].End)
            //        {
            //            var resl = (FreshRanges[j].Start, Ranges[i].End);
            //            FreshRanges[j] = resl;
            //            break;
            //        }
            //        else
            //        {
            //            FreshRanges.Add(Ranges[i]);
            //            break;
            //        }
            //    }

            //}

            for (int i = 0; i < Ranges.Count; i++)
            {
                for (int k = 0; k < FreshIDStart.Count; k++)
                {

                    if (Ranges[i].Start < FreshIDStart[k] && EndID[i] <= FreshIDStart[k])
                    {
                        FreshIDStart.Add(Ranges[i].Start);
                        FreshIDEnd.Add(Ranges[i].End);
                        break;
                    }
                    if (Ranges[i].Start > FreshIDStart[k] && Ranges[i].End >= FreshIDStart[k])
                    {
                        FreshIDStart.Add(Ranges[i].Start);
                        FreshIDEnd.Add(Ranges[i].End);
                        break;
                    }


                    //if (StartID[i] > FreshIDStart[k] && EndID[i] > FreshIDStart[k])
                    //{
                    //    FreshIDStart.Add(StartID[i]);
                    //    FreshIDEnd.Add(EndID[i]);
                    //    break;
                    //}

                    //for (ulong j = StartID[i]; j <= EndID[i]; j++)
                    //{

                    //    //if (!Fresh.Contains(j))
                    //    //{
                    //    //    Fresh.Add(j);
                    //    //}
                    //}
                }

            }

            for (int i = 0; i < FreshIDStart.Count; i++)
            {
                for (ulong j = FreshIDStart[i]; j <= FreshIDEnd[i]; j++)
                {
                    if(!resID.Contains(j))
                        resID.Add(j);
                }
            }
            Console.WriteLine(resID.Count);
        }       
    }
}
