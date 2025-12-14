using AdventOfCode.Helpers;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
namespace AdventOfCode._2025
{
    internal class Day8() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = true;

        public void FirstStar()
        {
            var Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            var Coordinates = Inputs
                .Where(s => s.Contains(','))
                .Select(s => s.Split(','))
                .Select(Coordinate => (X: double.Parse(Coordinate[0]), Y: double.Parse(Coordinate[1]), Z: double.Parse(Coordinate[2])))
                .ToList();
            int res = 0;

            var DistanceList = new List<(int id1, int id2, double distance)>();
            var Circuits = new List<List<(int id1, int id2, double distance)>>();

            for (int i = 0; i < Coordinates.Count; i++)
            {
                for (int j = i + 1; j < Coordinates.Count; j++)
                {
                    double dist = GetDistance(Coordinates[i], Coordinates[j]);
                    DistanceList.Add((i, j, dist));
                }
            }
            DistanceList = DistanceList.OrderBy(p => p.distance).ToList();
           
            foreach (var d in DistanceList)
            {
                if (Circuits.Count == 0)
                {
                    Circuits.Add(new List<(int id1, int id2, double distance)>());
                    Circuits[0].Add(d);
                    continue;
                }
                bool match = false;
                foreach (var c in Circuits)
                {
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (Circuits.Count == 10)
                        {
                            return;
                        }
                        if (d.id1 == c[i].id1)
                        {
                            c.Add(d);
                            match = true;
                            break;
                        }
                    }  
                    if (!match)
                    {
                        Circuits.Add(new List<(int id1, int id2, double distance)>());
                        Circuits.Last().Add(d);
                        break;
                    }
                }                
            }            
        }

        public double GetDistance((double X, double Y, double Z) First, (double X, double Y, double Z) Second)
        {
            return Math.Sqrt(
                    Math.Pow(First.X - Second.X, 2) +
                    Math.Pow(First.Y - Second.Y, 2) +
                    Math.Pow(First.Z - Second.Z, 2));
        }

        public void SecondStar()
        {
            int res = 0;            
            Console.WriteLine(res);
        }
       
    }
}
