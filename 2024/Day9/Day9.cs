using System.Text;

namespace AdventOfCode._2024
{
    internal class Day9
    {
        public string ReadFile()
        {
            bool example = true;
            string input = File.ReadAllText(example
                ? "C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day9\\Example.txt".Trim()
                : "C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day9\\Input.txt").Trim();
            //List<string> Inputs = input.Split("\r\n").ToList();
            return input;
        }
        public void FirstStar()
        {
            //
            // 90885620042 är för lågt
            //
            string Inputs = ReadFile();
            string ReturnString = "";
            string ID = "";
            int Block = 0;
            int BlockPlace = 1;
            for (int i = 0; i < Inputs.Length; i++)
            {
                int MOD = i % 2;
                BlockPlace++;
                for (int j = 0; j < Int32.Parse(Inputs[i].ToString()); j++) 
                {
                    if (MOD == 0 && Inputs[i].ToString() != "0")
                    {
                        ReturnString += Block.ToString();
                    } else
                    {
                        ReturnString += ".";
                    }
                }
                if (MOD == 1)
                {
                    Block++;
                }
            }

            //Console.WriteLine("Numbers: " + ReturnString);
            BuildCorrectString(ReturnString);
        }

        public void BuildCorrectString(string Input)
        {
            string Res = Input;
            StringBuilder sbInput = new StringBuilder(Input);
            int Dot = 0;
            string LastChar = "";
            int LastCharIndex = 0;
            for (int i = 0; Input.Length > 0; i++)
            {
                if (i > Input.Length -1)
                {                    
                        Console.WriteLine("Sorted: " + sbInput);
                        Checksum(sbInput);
                        return;
                    
                }
                if (Input[i] == '.')
                {
                    Dot = i;
                    LastChar = sbInput[sbInput.Length - 1].ToString();
                    LastCharIndex = sbInput.Length - 1;
                    if (LastChar == ".")
                    {
                        for (int j = sbInput.Length - 1; j >= 0; j--)
                        {
                            if (sbInput[j] != '.')
                            {
                                LastChar = sbInput[j].ToString();
                                LastCharIndex = j;
                                break;
                            }
                        }
                    }
                    if (LastChar != ".")
                    {
                        for (int k = 0; k < sbInput.Length; k++)
                        {
                            if(sbInput[k].ToString() == ".")
                            {
                                sbInput[Dot] = Input[LastCharIndex];
                                sbInput.Remove(LastCharIndex, sbInput.Length - LastCharIndex);
                                break;
                            }
                            else if (k == sbInput.Length - 1)
                            {
                                Console.WriteLine("Sorted:" + sbInput);
                                Checksum(sbInput);
                                return;
                            }
                        }                        
                    } 
                }
            }
        }

        public void Checksum(StringBuilder sbInput)
        {
            ulong Result = 0;
            for (int i = 0; i < sbInput.Length; i++)
            {
                Result += Convert.ToUInt64(i) * ulong.Parse(sbInput[i].ToString());
            }
            Console.WriteLine("Checksum: " + Result);
        }

       
    }
}

