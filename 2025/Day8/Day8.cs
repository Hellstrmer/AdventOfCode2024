using AdventOfCode.Helpers;
namespace AdventOfCode._2025
{
    internal class Day8() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = false;
        // Union Find
        Dictionary<int, int> Parent = new Dictionary<int, int>();
        Dictionary<int, int> Size = new Dictionary<int, int>();

        public void FirstStar()
        {
            var Coordinates = ParseInput();
            int res = 0;
            var DistanceList = new List<(int id1, int id2, double distance)>();
            for (int i = 0; i < Coordinates.Count; i++)
            {
                for (int j = i + 1; j < Coordinates.Count; j++)
                {
                    double dist = GetDistance(Coordinates[i], Coordinates[j]);
                    DistanceList.Add((i, j, dist));
                }
            }
            DistanceList = DistanceList.OrderBy(p => p.distance).ToList();
            // Setup Union Find
            for (int i = 0; i < Coordinates.Count; i++)
            {
                Parent[i] = i;
                Size[i] = 1;
            }           
            foreach (var d in DistanceList)
            {
                if (res >= 1000)                
                    break;                
                bool Connected = Union(d.id1, d.id2);
                res++;
            }

            List<int> ResList = GetCircuits();
            int results = ResList
                .OrderByDescending(s => s)
                .Take(3)
                .Aggregate(1, (acc, count) => acc * count);
            Console.WriteLine(results);
        }
        public void SecondStar()
        {
            var Coordinates = ParseInput();
            int res = 0;
            var DistanceList = new List<(int id1, int id2, double distance)>();
            for (int i = 0; i < Coordinates.Count; i++)
            {
                for (int j = i + 1; j < Coordinates.Count; j++)
                {
                    double dist = GetDistance(Coordinates[i], Coordinates[j]);
                    DistanceList.Add((i, j, dist));
                }
            }
            DistanceList = DistanceList.OrderBy(p => p.distance).ToList();
            // Setup Union Find
            for (int i = 0; i < Coordinates.Count; i++)
            {
                Parent[i] = i;
                Size[i] = 1;
            }            
            (int id1, int id2) Last = (0,0);
            foreach (var d in DistanceList)
            {
                if (Union(d.id1, d.id2))
                {
                    Last = (d.id1, d.id2);
                    res++; 
                    if (res == Coordinates.Count - 1)
                        break;                    
                }     
            }
            Console.WriteLine((ulong)Coordinates[Last.id1].X * (ulong)Coordinates[Last.id2].X);
        }
        public List<(double X, double Y, double Z)> ParseInput()
        {
            var Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            return Inputs
                .Where(s => s.Contains(','))
                .Select(s => s.Split(','))
                .Select(Coordinate => (X: double.Parse(Coordinate[0]), Y: double.Parse(Coordinate[1]), Z: double.Parse(Coordinate[2])))
                .ToList();
        }
        public int FindUnion(int i)
        {
            if (Parent[i] == i)            
                return i;                   
            return FindUnion(Parent[i]);
        }
        public bool Union(int x, int y)
        {
            int rX = FindUnion(x);
            int rY = FindUnion(y);
            if (rX == rY)            
                return false;

            if (Size[rX] < Size[rY])
            {
                Parent[rX] = rY;
                Size[rY] += Size[rX];
            }
            else
            {
                Parent[rY] = rX;
                Size[rX] += Size[rY];
            }
            return true;
        }
        public List<int> GetCircuits()
        {
            var roots = new HashSet<int>();
            foreach (var k in Parent.Keys)            
                roots.Add(FindUnion(k));            
            return roots.Select(r => Size[r]).ToList();
        }
        public double GetDistance((double X, double Y, double Z) First, (double X, double Y, double Z) Second)
        {
            return Math.Sqrt(
                    Math.Pow(First.X - Second.X, 2) +
                    Math.Pow(First.Y - Second.Y, 2) +
                    Math.Pow(First.Z - Second.Z, 2));
        }
    }
}
