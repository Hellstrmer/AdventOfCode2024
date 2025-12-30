using AdventOfCode.Helpers;
using System.Text.RegularExpressions;
namespace AdventOfCode._2021
{
    internal class Day12() : HelperClass
    {
        string Example = "Example.txt";
        string Input = "Input.txt";
        bool example = true;
        public void FirstStar()
        {
            List<string> Inputs = example ? ReadFileList(Example) : ReadFileList(Input);
            List<(string Start, string End)> Paths = Inputs
                .Where(s => s.Contains('-'))
                .Select(s => s.Split('-'))
                .Select((p => (Start: p[0], End: p[1])))
                .ToList();

            List<string> parts = new List<string>();
            foreach (var s in Paths)
            {
                if (!parts.Contains(s.Start))
                    parts.Add(s.Start);
                if (!parts.Contains(s.End))
                    parts.Add(s.End);

            }

            List<int> Res = dfs(Paths);
            Console.WriteLine("Flashes: ");
        }

        public void dfsRec(List<(string Start, string End)> adj, bool[] visited, int s, List<int> res, string last)
        {
            visited[s] = true;
            res.Add(s);

            for (int i = 0; i < adj.Count; i++)
            {
                Regex Lower = new Regex(@"(?:[a-z])");
                Regex Upper = new Regex(@"(?:[A-Z])");
                MatchCollection resultLower = Lower.Matches(adj[i].End);
                MatchCollection resultUpper = Upper.Matches(adj[i].End);
                if (!visited[i] && adj[i].Start == last && resultLower.Count > 0)
                {
                    last = adj[i].End;
                    dfsRec(adj, visited, i, res, last);
                } 
                else if (adj[i].Start == last && resultUpper.Count > 0)
                {
                    last = adj[i].End;
                    dfsRec(adj, visited, i, res, last);
                }
            }
        }

        public List<int> dfs(List<(string Start, string End)> adj)
        {
            bool[] visited = new bool[adj.Count];
            List<int> res = new List<int>();
            string last = "";
            dfsRec(adj, visited, 0, res, last);
            return res;
        }
        public void SecondStar()
        {

        }
    }
}
