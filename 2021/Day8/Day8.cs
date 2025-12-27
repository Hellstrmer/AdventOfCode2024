using AdventOfCode.Helpers;
namespace AdventOfCode._2021
{
    internal class Day8() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = true;
        public void FirstStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            var Digits = Inputs
                .Select(s => s.Split('|'))
                .Select(s => s[1])
                .Select(s => s.Split(" ", StringSplitOptions.RemoveEmptyEntries))                
                .ToList();
            var numbers = new Dictionary<string, int>
            {
                ["0"] = 6, // Problem 6
                ["1"] = 2,
                ["2"] = 5, // Problem 5
                ["3"] = 5, // Problem 5
                ["4"] = 4,
                ["5"] = 5, // Problem 5
                ["6"] = 6, // Problem 6
                ["7"] = 3,
                ["8"] = 7,
                ["9"] = 6, // Problem 6
            };
            int Res = 0;

            foreach (var numb in Digits)
            {
                foreach (var c in numb)
                {
                    if (c.Length == numbers["1"] || c.Length == numbers["4"] || c.Length == numbers["7"] || c.Length == numbers["8"])
                    {
                        Res++;
                    }
                }
            }


            Console.WriteLine(Res);
        }
        public void SecondStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            var Digits = Inputs
                .Select(s => s.Split('|'))
                .Select(s => s[1])
                .Select(s => s.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                .ToList();
            var DigitsDecode = Inputs
                .Select(s => s.Split('|'))
                .Select(s => s[0])
                .Select(s => s.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                .ToList();
            var numbers = new Dictionary<string, string>
            {
                ["0"] = "cagedb", // Problem 6
                ["1"] = "ab",
                ["2"] = "gcdfa", // Problem 5
                ["3"] = "fbcad", // Problem 5
                ["4"] = "eafb",
                ["5"] = "cdfbe", // Problem 5
                ["6"] = "cdfgeb", // Problem 6
                ["7"] = "dab",
                ["8"] = "acedgfb",
                ["9"] = "cefabd", // Problem 6
            };
            int Res = 0;

            for (int i = 0; i < DigitsDecode.Count; i ++)
            {
                DigitsDecode[i] = DigitsDecode[i]
                    .OrderBy(s => s.Length).ToArray();
                numbers["1"] = DigitsDecode[i][0];
                numbers["7"] = DigitsDecode[i][1];
                numbers["4"] = DigitsDecode[i][2];
                numbers["8"] = DigitsDecode[i][9];
                foreach (var t in DigitsDecode[i])
                {
                    if (t.Contains(numbers["4"][0]) && t.Length == 5)
                    {
                        numbers["5"] = t;
                    } 
                    else if (t.Contains(numbers["4"][3]) && t.Length == 5)
                    {
                        numbers["3"] = t;
                    }
                    else if (t.Contains(numbers["7"][0]) && t.Contains(numbers["7"][1]) && t.Length == 5)
                    {
                        numbers["2"] = t;
                    }
                    else if (t.Contains(numbers["5"][4]) && t.Length == 6)
                    {
                        numbers["9"] = t;
                    }
                    else if (t.Contains(numbers["2"][2]) && t.Length == 6)
                    {
                        numbers["6"] = t;
                    }
                    else if (t.Contains(numbers["5"][4]) && t.Contains(numbers["2"][2]) && t.Length == 6)
                    {
                        numbers["0"] = t;
                    }
                }
                foreach (var numb in Digits)
                {
                    foreach (var c in numb)
                    {
                        string decoded = "";
                        foreach (var d in numbers)
                        {
                            if (c == d.Value)
                            {
                                decoded += d.Key;
                            }
                        }
                        Res += Int32.Parse(decoded);
                    }
                }
            }



          

            Console.WriteLine(Res);
        }
    }
}
