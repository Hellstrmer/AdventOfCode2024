using AdventOfCode.Helpers;
namespace AdventOfCode._2021
{
    internal class Day3() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        public void FirstStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            (string Gamma, string Epsilon) = FindAns(Inputs);
            Console.WriteLine((Convert.ToInt32(Gamma, 2) * Convert.ToInt32(Epsilon, 2)).ToString());
        }
        public void SecondStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);;
            (string Gamma, string Epsilon) = FindAns(Inputs);            
            string Oxygen = Rating(Inputs, Gamma, false);
            string C02 = Rating(Inputs, Epsilon, true);
            Console.WriteLine((Convert.ToInt32(Oxygen, 2) * Convert.ToInt32(C02, 2)).ToString());
        }

        private (string Gamma, string Epsilon) FindAns(List<string> Inputs)
        {
            string Gamma = "";
            string Epsilon = "";
            List<int> CommonBitsOne = new List<int>();
            List<int> CommonBitsZero = new List<int>();
            foreach (var s in Inputs)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (CommonBitsOne.Count < s.Length)
                    {
                        CommonBitsOne.Add(0);
                        CommonBitsZero.Add(0);
                    }
                    if (s[i] == '0')
                        CommonBitsZero[i] += 1;
                    else
                        CommonBitsOne[i] += 1;
                }
            }
            for (int i = 0; i < CommonBitsZero.Count; i++)
            {
                Gamma += CommonBitsOne[i] > CommonBitsZero[i] ? "1" : "0";                
                Epsilon += CommonBitsOne[i] < CommonBitsZero[i] ? "1" : "0";
            }
            return (Gamma, Epsilon);
        }
        private string GammaFind(List<string> search, bool find)
        {
            string Gamma = "";
            List<int> CommonBitsOne = new List<int>();
            List<int> CommonBitsZero = new List<int>();
            foreach (var s in search)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (CommonBitsOne.Count < s.Length)
                    {
                        CommonBitsOne.Add(0);
                        CommonBitsZero.Add(0);
                    }
                    if (s[i] == '0')
                        CommonBitsZero[i] += 1;
                    else
                        CommonBitsOne[i] += 1;
                }
            }
            for (int i = 0; i < CommonBitsZero.Count; i++)
            {
                if (!find)                
                    Gamma += CommonBitsOne[i] >= CommonBitsZero[i] ? "1" : "0";                    
                else                
                    Gamma += CommonBitsZero[i] <= CommonBitsOne[i] ? "0" : "1";
            }
            return Gamma;
        }
        private string Rating(List<string> Inputs, string Gamma, bool find)
        {
            List<string> Oxygen = new List<string>();
            foreach (var s in Inputs)
            {
                if (s[0] == Gamma[0])                
                    Oxygen.Add(s);                
            }
            int index = 1;
            while (true)
            {
                Gamma = GammaFind(Oxygen, find);
                foreach (var s in Oxygen.ToList())
                {
                    if (Oxygen.Count == 1 && index > 0)
                        return Oxygen[0];
                    if (s[index] != Gamma[index])                    
                        Oxygen.Remove(s);                    
                }    
                index++;
            }
        }
    }
}
