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

//        public class UnionFind
//{
//    private Dictionary<int, int> parent;
//    private Dictionary<int, int> size;
    
//    public UnionFind(int n)
//    {
//        parent = new Dictionary<int, int>();
//        size = new Dictionary<int, int>();
//        for (int i = 0; i < n; i++)
//        {
//            parent[i] = i;
//            size[i] = 1;
//        }
//    }
    
//    public int Find(int x)
//    {
//        if (parent[x] != x)
//        {
//            parent[x] = Find(parent[x]); // Path compression
//        }
//        return parent[x];
//    }
    
//    public bool Union(int x, int y)
//    {
//        int rootX = Find(x);
//        int rootY = Find(y);
        
//        if (rootX == rootY)
//        {
//            return false; // Already in same set
//        }
        
//        // Union by size
//        if (size[rootX] < size[rootY])
//        {
//            parent[rootX] = rootY;
//            size[rootY] += size[rootX];
//        }
//        else
//        {
//            parent[rootY] = rootX;
//            size[rootX] += size[rootY];
//        }
//        return true;
//    }
    
//    public int GetSize(int x)
//    {
//        return size[Find(x)];
//    }
    
//    public List<int> GetAllCircuitSizes()
//    {
//        var roots = new HashSet<int>();
//        foreach (var key in parent.Keys)
//        {
//            roots.Add(Find(key));
//        }
//        return roots.Select(r => size[r]).ToList();
//    }
//}

//public void FirstStar()
//{
//    var Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
//    var Coordinates = Inputs
//        .Where(s => s.Contains(','))
//        .Select(s => s.Split(','))
//        .Select(Coordinate => (X: double.Parse(Coordinate[0]), Y: double.Parse(Coordinate[1]), Z: double.Parse(Coordinate[2])))
//        .ToList();
    
//    // Skapa alla möjliga par med deras avstånd
//    var pairs = new List<(int idx1, int idx2, double distance)>();
    
//    for (int i = 0; i < Coordinates.Count; i++)
//    {
//        for (int j = i + 1; j < Coordinates.Count; j++)
//        {
//            double dist = GetDistance(Coordinates[i], Coordinates[j]);
//            pairs.Add((i, j, dist));
//        }
//    }
    
//    // Sortera par efter avstånd
//    pairs = pairs.OrderBy(p => p.distance).ToList();
    
//    // Använd Union-Find för att hålla koll på kretsar
//    var uf = new UnionFind(Coordinates.Count);
    
//    int connections = 0;
//    int maxConnections = example ? 10 : 1000; // 10 för example, 1000 för riktiga input

//            // Gå igenom par i ordning från kortast avstånd
//            foreach (var pair in pairs)
//            {
//                if (connections >= maxConnections)
//                    break;

//                bool connected = uf.Union(pair.idx1, pair.idx2);
//                connections++; // <- Räkna ALLTID

//                if (connected)
//                {
//                    Console.WriteLine($"Connected {pair.idx1} and {pair.idx2}");
//                }
//                else
//                {
//                    Console.WriteLine($"Already connected: {pair.idx1} and {pair.idx2}");
//                }
//            }

//            // Få storleken på alla kretsar
//            var circuitSizes = uf.GetAllCircuitSizes();
    
//    // Multiplicera de 3 största
//    int result = circuitSizes
//        .OrderByDescending(s => s)
//        .Take(3)
//        .Aggregate(1, (acc, size) => acc * size);
    
//    Console.WriteLine($"\nCircuit sizes: {string.Join(", ", circuitSizes.OrderByDescending(s => s))}");
//    Console.WriteLine($"Result: {result}");
//}

//public double GetDistance((double X, double Y, double Z) First, (double X, double Y, double Z) Second)
//{
//    return Math.Sqrt(
//        Math.Pow(First.X - Second.X, 2) +
//        Math.Pow(First.Y - Second.Y, 2) +
//        Math.Pow(First.Z - Second.Z, 2));
//}

        public void FirstStar()
        {
            var Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            var Coordinates = Inputs
                .Where(s => s.Contains(','))
                .Select(s => s.Split(','))
                .Select(Coordinate => (X: double.Parse(Coordinate[0]), Y: double.Parse(Coordinate[1]), Z: double.Parse(Coordinate[2])))
                .ToList();
            int res = 0;
            //int FirstIndex = 0;
            //int SecondIndex = 0;
            //var Circuits = new List<List<(double X, double Y, double Z)>>();
            //var TempCircuits = new List<(double X, double Y, double Z)>();

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
                        //else if (i == c.Count -1)
                        //{
                        //    Circuits.Add(new List<(int id1, int id2, double distance)>());
                        //    Circuits.Last().Add(d);
                        //    break;
                        //}
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

        //    double Smallest = GetDistance(Coordinates[0], Coordinates[1]);
        //    double Answer = 0;
        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (Circuits.Count > 0)
        //        {
        //            TempCircuits = new List<(double X, double Y, double Z)>();
        //            for (int k = 0; k < Circuits.Count; k++)
        //            {
        //                for (int c = 0; c < Circuits[k].Count; c++)
        //                {
        //                    for (int v = 0; v < Coordinates.Count; v++)
        //                    {
        //                        Answer = GetDistance(Circuits[k][c], Coordinates[v]);
        //                        if (Answer < Smallest || Smallest == 0)
        //                        {
        //                            Smallest = Answer;
        //                            TempCircuits.Clear();
        //                            TempCircuits.Add(Circuits[k][c]);
        //                            TempCircuits.Add(Coordinates[v]);
        //                            FirstIndex = c;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        for (int j = i + 1; j < Coordinates.Count; j++)
        //        {
        //            Answer = GetDistance(Coordinates[i], Coordinates[j]);
        //            if (Answer < Smallest && Answer != 0)
        //            {
        //                Smallest = Answer;
        //                TempCircuits.Clear();

        //                TempCircuits.Add(Coordinates[i]);
        //                TempCircuits.Add(Coordinates[j]);
        //                FirstIndex = i;
        //                SecondIndex = j;
        //            }
        //        }
        //        for (int index = 0; index < Circuits.Count; index++)
        //        {
        //            if (Circuits[index].Contains(TempCircuits[0]) || Circuits[index].Contains(TempCircuits[1]))
        //            {
        //                Circuits[index].Add(TempCircuits[1]);
        //                break;
        //            }
        //            if (index == Circuits.Count - 1)
        //            {
        //                Circuits.Add(TempCircuits);
        //                break;
        //            }
        //        }
        //        if (Circuits.Count == 0)
        //        {
        //            Circuits.Add(TempCircuits);
        //        }
        //        FirstIndex = Coordinates.IndexOf(TempCircuits[0]);
        //        SecondIndex = Coordinates.IndexOf(TempCircuits[1]);
        //        if (FirstIndex >= 0)
        //        {
        //            Coordinates[FirstIndex] = (X: 0, Y: 0, Z: 0);
        //        }
        //        else
        //        {
        //            Coordinates[0] = (X: 0, Y: 0, Z: 0);
        //        }
        //        Coordinates[SecondIndex] = (X: 0, Y: 0, Z: 0);
        //        foreach (var cor in Coordinates)
        //        {
        //            Console.WriteLine(cor);
        //        }
        //        Console.WriteLine(" ");

        //        Smallest = 0;
        //    }
        //    res = Circuits
        //        .OrderByDescending(list => list.Count)
        //        .Take(3)
        //        .Select(list => list.Count)
        //        .Aggregate(1, (acc, count) => acc * count);

        //    Console.WriteLine(res);
        //}

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
