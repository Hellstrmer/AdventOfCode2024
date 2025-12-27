using AdventOfCode.Helpers;
namespace AdventOfCode._2021
{
    internal class Day7() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        public void FirstStar()
        {
            string Inputs = example ? ReadFileString(Example) : ReadFileString(Input);
            var Crabs = Inputs.Split(',')       
                .Select(int.Parse)
                .ToList();
            int Res = 0;
            int Position = 1;
            while (Position < Crabs.Max())
            {
                int Distance = 0;
                for (int i = 0; i < Crabs.Count; i++)                
                    Distance += Math.Abs(Crabs[i] - Position);                
                if (Distance < Res|| Position == 1)                
                    Res = Distance;
                Position++;
            }
            Console.WriteLine(Res);
        }
        public void SecondStar()
        {
            string Inputs = example ? ReadFileString(Example) : ReadFileString(Input);
            var Crabs = Inputs.Split(',')
                .Select(int.Parse)
                .ToList();
            int Res = 0;
            int Position = 1;
            while (Position < Crabs.Max())
            {
                int Distance = 0;
                for (int i = 0; i < Crabs.Count; i++)
                {
                    if (Crabs[i] > Position)
                    {
                        for (int j = Crabs[i]; j > Position; j--)                        
                            Distance += Math.Abs(j - Position);                        
                    }
                    else
                    {
                        for (int j = Crabs[i]; j < Position; j++)                        
                            Distance += Math.Abs(j - Position);
                    }
                }
                if (Distance < Res || Position == 1)
                    Res = Distance;
                Position++;
            }
            Console.WriteLine(Res);
        }
    }
}
