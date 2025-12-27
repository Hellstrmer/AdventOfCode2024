using AdventOfCode.Helpers;
using System.Runtime.CompilerServices;
namespace AdventOfCode._2021
{
    internal class Day10() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        List<string> InComplete = new List<string>();
        List<List<char>> IncompletedParts = new List<List<char>>();
        public void FirstStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            List<char> Illegal = new List<char>();
            foreach (var line in Inputs)
            {
                List<char> LatestOppener = new List<char>();
                bool Legal = true;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '(' || line[i] == '[' || line[i] == '{' || line[i] == '<')
                    {
                        LatestOppener.Add(line[i]);
                        if (i == line.Length - 1 && Legal)
                        {
                            InComplete.Add(line);
                            IncompletedParts.Add(LatestOppener);
                        }
                        continue;
                    }
                    if (LatestOppener.Last() == '(' && line[i] != ')')
                    {
                        Legal = false;
                        Illegal.Add(line[i]);
                        break;
                    }
                    else if (LatestOppener.Last() == '[' && line[i] != ']')
                    {
                        Legal = false;
                        Illegal.Add(line[i]);
                        break;
                    }
                    else if (LatestOppener.Last() == '{' && line[i] != '}')
                    {
                        Legal = false;
                        Illegal.Add(line[i]);
                        break;
                    }
                    else if (LatestOppener.Last() == '<' && line[i] != '>')
                    {
                        Legal = false;
                        Illegal.Add(line[i]);
                        break;
                    } 
                    if (Legal)                    
                        LatestOppener.RemoveAt(LatestOppener.Count -1);
                    if (i == line.Length - 1 && LatestOppener.Count > 0)
                    {
                        InComplete.Add(line);
                        IncompletedParts.Add(LatestOppener);
                    }
                }
            }
            ulong Res = 0;
            foreach (var l in Illegal)
            {
                if (l == ')')                    
                    Res += 3;
                else if (l == ']')
                    Res += 57;
                else if (l == '}')
                    Res += 1197;
                else if (l == '>')
                    Res += 25137;
            }
            Console.WriteLine(Res);
        }
        public void SecondStar()
        {
            List<ulong> Result = new List<ulong>();
            foreach (var Parts in IncompletedParts)
            {
                ulong Res = 0;
                for (int i = Parts.Count - 1; i >= 0; i--) 
                {
                    Res *= 5;
                    if (Parts[i] == '(')
                        Res += 1;
                    else if (Parts[i] == '[')
                        Res += 2;
                    else if (Parts[i] == '{')
                        Res += 3;
                    else if (Parts[i] == '<')
                        Res += 4;
                }
                Result.Add(Res);
                Result.Sort();
            }
            Console.WriteLine(Result[Result.Count /2]);
        }
    }
}
