using AdventOfCode.Helpers;
namespace AdventOfCode._2021
{
    internal class Day4() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        int Rows = 5;
        public void FirstStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            List<string> Numbers = Inputs[0].Split(',').ToList();
            List<List<string[]>> Boards = new List<List<string[]>>();
            List<string[]> Board = Inputs
                .Where(s => s.Contains(' '))
                .Select(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .ToList();

            int index = 0;
            int boardIndex = -1;
            Boards.Add(new List<string[]>());
            for (int i = 0; i < Board.Count; i++)            
            {
                if (index % Rows == 0 && index < Board.Count - Rows +1) 
                {
                    Boards.Add(new List<string[]>());
                    boardIndex++;
                }
                Boards[boardIndex].Add(Board[i]);
                index++;
            }
            int resNumb = 0;
            foreach (var numb in Numbers)
            {
                resNumb = Int32.Parse(numb);
                for (int i = 0; i < Boards.Count; i++)            
                {                
                    for (int j = 0; j < Boards[i].Count; j++)                
                    {
                        for (int k = 0; k < Boards[i][j].Length; k++)                        
                        {
                            if (Boards[i][j][k] == numb)                            
                                Boards[i][j][k] = "-1";                            
                        }
                    }                
                }
                int resboard = BingoSearch(Boards);
                if (resboard != -1)
                {
                    int t = BingoBadge(Boards[resboard]);
                    Console.WriteLine(t * resNumb);
                    break;
                }
            }
        }
        public void SecondStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input); ;
           
           // Console.WriteLine((Convert.ToInt32(Oxygen, 2) * Convert.ToInt32(C02, 2)).ToString());
        }

        public int BingoSearch(List<List<string[]>> Board)
        {
            int index = 0;
            bool BingoFound = true;
            foreach (var B in Board)
            {
                foreach (var row in B)
                {
                    BingoFound = true;
                    foreach (var numb in row)
                    {
                        if (numb != "-1")
                        {
                            BingoFound = false;
                            continue;
                        }
                        /*else
                        {
                            if (BingoFound)
                            {
                                BingoFound = true;
                            }
                        }*/
                        
                    }
                    if (BingoFound)
                        return index;                    
                }
                index++;
            }
            return -1;
        }

        public int BingoBadge(List<string[]> bagde)
        {
            int res = 0;
            foreach (var row in bagde)
            {
                foreach (var numb in row)
                {
                    if (numb != "-1")                    
                        res += Int32.Parse(numb);                    
                }
            }
            return res;
        }
    }
}
