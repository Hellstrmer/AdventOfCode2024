using AdventOfCode.Helpers;
using System.Linq;
namespace AdventOfCode._2025
{
    internal class Day6() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = true;
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
            var Inp = Inputs.Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToList();

            List<string> Operation = Inp.Last().ToList();
            List<ulong> Results = new List<ulong>();
            List<ulong> Cephalopod = new List<ulong>();
            List<List<string>> sign = new List<List<string>>();
            List<List<string>> resSign = new List<List<string>>();

            for (int i = 0; i < Inp.Count; i++)
            {
                ulong Numb = 0;
                Cephalopod.Clear();
                int longest = 0;
                resSign.Add(new List<string>());
                for (int j = 0; j < Inp[i].Length; j++)
                {
                    if (resSign.Count < Inp[i].Length)
                    {
                        resSign.Add(new List<string>());
                    }

                    sign.Add(new List<string>());
                    var t = Inp[i];
                    if (ulong.TryParse(Inp[i][j].ToString(), out Numb))
                    {
                        if (Inp[i][j].Count() > longest)
                        {
                            longest = Inp[i][j].Count();
                        }
                        Inp[i] = Fillempty(Inp[i], longest, Operation[j]);
                        var b = Inp[i][j];

                        sign[j].Clear();
                        for (int m = 0; m < b.Count(); m++)
                        {
                            sign[j].Add(b[m].ToString());
                        }


                        Cephalopod.Add(Numb);
                    }
                }
                for (int k = 0; k < Operation.Count; k++)
                {
                    for (int n = 0; n < sign[k].Count; n++)
                    {
                        if (resSign[k].Count < sign[k].Count)
                        {
                            if (Operation[k] == "*")
                            {
                                resSign[k].Add("");
                            } 
                            else
                            {
                                resSign[k].Add("");
                            }
                        }                        
                        if (Operation[k] == "*")
                        {
                            resSign[k][n] += sign[k][n].ToString();
                            var t = ulong.Parse(sign[k][n].ToString());
                        }
                        else
                        {
                            resSign[k][n] += sign[k][n].ToString();
                            var t = ulong.Parse(sign[k][n].ToString());
                        }

                    }

                    if (Results.Count < Operation.Count)
                        Results.Add((ulong)(Operation[k] == "*" ? 1 : 0));
                    if (Cephalopod.Count > 0)
                        Results[k] = Operation[k] == "+" ? Results[k] += Cephalopod[k] : Results[k] *= Cephalopod[k];
                }
            }
            Console.WriteLine(resSign);
            Console.WriteLine(Results.Sum(r => (decimal)r));
        }

        public string[] Fillempty(string[] fillArr, int length, string Operation)
        {
            for (int i = 0; i < fillArr.Length; i++)
            {
                if (fillArr[i].Length > length)
                {
                    length = fillArr[i].Length;
                }
            }
            for (int i = 0; i < fillArr.Length; i++)
            {
                if (fillArr[i].Length < length)
                {
                    if (Operation == "*")
                    {
                        fillArr[i] = fillArr[i].Insert(0, "");
                    } 
                    else
                    {
                        fillArr[i] = fillArr[i].Insert(0, "");
                    }
                }
            }
            return fillArr;
        }
    }
}
