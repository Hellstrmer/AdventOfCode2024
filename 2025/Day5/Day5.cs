using AdventOfCode.Helpers;
namespace AdventOfCode._2025
{
    internal class Day5() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        public void FirstStar()
        {
            var (Ranges, ID) = GetInput();
            Console.WriteLine(ID.Count(fresh => Ranges.Any(r => fresh >= r.Start && fresh <= r.End)));            
        }
        public void SecondStar()
        {
            var (Ranges, ID) = GetInput();
            var FreshRanges = new List<(ulong Start, ulong End)>();
            FreshRanges.Add(Ranges[0]);
            for (int i = 1; i < Ranges.Count; i++)
            {
                for (int j = 0; j < FreshRanges.Count; j++)
                {
                    var actual = FreshRanges[j];
                    if (Ranges[i].End > FreshRanges[j].End && Ranges[i].Start <= FreshRanges[j].End)
                    {
                        actual.End = Ranges[i].End;
                        if (!FreshRanges.Contains(actual))
                            FreshRanges[j] = actual;
                    }
                    else if (j == FreshRanges.Count - 1 && !(Ranges[i].Start >= FreshRanges[j].Start && Ranges[i].End <= FreshRanges[j].End))
                        FreshRanges.Add(Ranges[i]);
                }
            }
            Console.WriteLine(FreshRanges.Sum(r => (decimal)r.End - r.Start + 1));
        }
        public (List<(ulong Start, ulong End)> Ranges, List<ulong> ID) GetInput()
        {
            var Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            var Ranges = Inputs
                .Where(s => s.Contains('-'))
                .Select(s => s.Split('-'))
                .Select(IDs => (Start: ulong.Parse(IDs[0]), End: ulong.Parse(IDs[1])))
                .OrderBy(s => s.Start)
                .ToList();
            var ID = Inputs.Where(s => !s.Contains('-') && s.Length > 0)
                .Select(s => ulong.Parse(s))
                .ToList();
            return (Ranges, ID);
        }
    }
}
