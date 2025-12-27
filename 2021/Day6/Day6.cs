using AdventOfCode.Helpers;
using System.Drawing;
namespace AdventOfCode._2021
{
    internal class Day6() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        public void FirstStar()
        {
            string Inputs = example ? ReadFileString(Example) : ReadFileString(Input);
            var Lanternfish = Inputs.Split(',')       
                .Select(int.Parse)
                .ToList();
            int days = 0;
            while (days < 80)
            {
                var fish = Lanternfish.ToList();
                for (int i = 0; i < fish.Count; i++)
                {
                    Lanternfish[i] -= 1;
                    if (Lanternfish[i] < 0)
                    {
                        Lanternfish[i] = 6;
                        Lanternfish.Add(8);
                    }
                }
                days++;
            }            
            Console.WriteLine(Lanternfish.Count);
        }
        public void SecondStar()
        {
            string Inputs = example ? ReadFileString(Example) : ReadFileString(Input);
            List<int> Lanternfish = Inputs.Split(',')
                .Select(int.Parse)
                .ToList();
            long[] FishCount = new long[9];
            foreach (var fish in Lanternfish)
                FishCount[fish] += 1;
            for (int day = 0; day < 256; day++)
            {
                long NewFish = FishCount[0];
                for (int i = 0; i < 8; i++)                
                    FishCount[i] = FishCount[i + 1];                
                FishCount[6] += NewFish;
                FishCount[8] = NewFish;
            }
            Console.WriteLine(FishCount.Sum());
        }
    }
}
