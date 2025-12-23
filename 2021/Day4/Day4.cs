using AdventOfCode.Helpers;
using System.Drawing;
namespace AdventOfCode._2021
{
    internal class Day4() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = true;
        int Rows = 5;
        List<Point> FoundPoints = new List<Point>();
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
            foreach (var numb in Numbers)
            {
                for (int i = 0; i < Boards.Count; i++)            
                {                
                    for (int j = 0; j < Boards[i].Count; j++)                
                    {
                        for (int k = 0; k < Boards[i][j].Length; k++)                        
                        {
                            if (Boards[i][j][k] == numb)                            
                                Boards[i][j][k] = "-1";
                            if (findBingo2(i, j, k, Boards))
                            {  
                                Console.WriteLine(BingoBadge(Boards[i]) * Int32.Parse(numb));
                                return;
                            }
                        }
                    }                
                }                
            }
        }
        public void SecondStar()
        {
            //45079 To High
            //1089 To Low
            // Need to check where i've been
            
            FoundPoints = new List<Point>();
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
                if (index % Rows == 0 && index < Board.Count - Rows + 1)
                {
                    Boards.Add(new List<string[]>());
                    boardIndex++;
                }
                Boards[boardIndex].Add(Board[i]);
                index++;
            }
            int resNumb = 0;
            int res = 0;
            foreach (var numb in Numbers)
            {
                resNumb = Int32.Parse(numb);
                if (resNumb == 13)
                {

                }
                for (int i = 0; i < Boards.Count; i++)
                {
                    for (int j = 0; j < Boards[i].Count; j++)
                    {
                        for (int k = 0; k < Boards[i][j].Length; k++)
                        {
                            if (Boards[i][j][k] == numb)
                                Boards[i][j][k] = "-1";
                            if (resNumb == 6)
                            {

                            }
                            if (findBingo2(i, j, k, Boards))
                            {
                                if (res == resNumb)
                                {
                                    //return;
                                }
                                int t = BingoBadge(Boards[i]);
                                res = resNumb;
                                Console.WriteLine(t * resNumb);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public bool findBingo2(int  i, int j, int k, List<List<string[]>> Boards)
        {
            bool BingoFound = true;
            for (int index = 0; index < Rows; index++)
            {
                if (Boards[i][index][k] != "-1")
                {
                    BingoFound = false;
                    break;
                }
            }        
            if (BingoFound) 
                return true;

            BingoFound = true;
            for (int index = 0; index < Rows; index++)
            {
                if (Boards[i][j][index] != "-1")
                {
                    BingoFound = false;
                    return false;
                }
            }
            return true;
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
