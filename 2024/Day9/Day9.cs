using System.Text;

namespace AdventOfCode._2024
{
    internal class Day9
    {
        public string ReadFile()
        {
            bool example = false;
            string input = File.ReadAllText(example
                ? "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day9\\Example.txt".Trim()
                : "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day9\\Input.txt").Trim();
            return input;
        }
        public void FirstStar()
        {
            string Inputs = ReadFile();
            string ReturnString = "";
            List<int> ReturnInts = new List<int>();
            string ID = "";
            int Block = 0;
            int BlockPlace = 1;
            for (int i = 0; i < Inputs.Length; i++)
            {
                int MOD = i % 2;
                BlockPlace++;
                for (int j = 0; j < Int32.Parse(Inputs[i].ToString()); j++) 
                {
                    if (MOD == 0)
                    {
                        ReturnString += Block.ToString();
                        ReturnInts.Add(Block);
                    } else
                    {
                        ReturnString += ".";
                        ReturnInts.Add(-1);
                    }
                }
                if (MOD == 1)
                {
                    Block++;
                }
            }
            BuildCorrectString(ReturnInts);
        }

        public void BuildCorrectString(List<int> IntInput)
        {
            int Dot = 0;
            int LastChar = 0;
            int Search = -1;
            int LastCharIndex = 0;

            for (int i = 0; IntInput.Count > 0; i++)
            {
                if (i > IntInput.Count - 1)
                {
                    Checksum(IntInput);
                    return;

                }
                if (IntInput[i] == Search)
                {
                    Dot = i;
                    LastChar = IntInput[IntInput.Count - 1];
                    LastCharIndex = IntInput.Count - 1;
                    
                    if (LastChar != Search)
                    {
                        Dot = i;
                        LastChar = IntInput[IntInput.Count - 1];
                        LastCharIndex = IntInput.Count - 1;
                    }

                    if (LastChar == Search || Dot > LastCharIndex)
                    {
                        for (int j = IntInput.Count - 1; j >= 0; j--)
                        {
                            if (IntInput[j] != Search)
                            {
                                LastChar = IntInput[j];
                                LastCharIndex = j;
                                if (Dot > LastCharIndex)
                                {
                                    LastCharIndex = j + Dot - LastCharIndex;
                                }
                                break;
                            }                            
                        }
                    } 
                    if (LastChar != Search)
                    {
                        IntInput[Dot] = IntInput[LastCharIndex];
                        IntInput.RemoveRange(LastCharIndex, IntInput.Count - LastCharIndex);
                    }                
                }
            }
        }            

        public void Checksum(List<int> Inputs)
        {
            ulong Result = 0;
            for (int i = 0; i < Inputs.Count; i++)
            {                
                Result += Convert.ToUInt64(i) * Convert.ToUInt64(Inputs[i]);
            }
            Console.WriteLine("Checksum: " + Result);            
        }

       
    }
}

