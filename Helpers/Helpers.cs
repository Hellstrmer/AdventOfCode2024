namespace AdventOfCode.Helpers
{
    public class HelperClass
    {
        
        public List<string> ReadFileList(string name, [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "")
        {
            string dayFolder = Path.GetDirectoryName(sourceFilePath);
            string file = Path.Combine(dayFolder, name);
            string input = File.ReadAllText(file.Trim());
            List<string> inputs = input.Split("\r\n").ToList();
            return inputs;
        }
        public string ReadFileString(string name, [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "")
        {
            string dayFolder = Path.GetDirectoryName(sourceFilePath);
            string file = Path.Combine(dayFolder, name);
            string input = File.ReadAllText(file.Trim());
            return input;
        }
        public string[] ReadFileArr(string name, [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "")
        {
            string dayFolder = Path.GetDirectoryName(sourceFilePath);
            string file = Path.Combine(dayFolder, name);
            string[] input = File.ReadAllLines(file);
            return input;
        }

        public (char[,] grid, int width, int height) Readgrid(String[] Inputs)
        {
            char[,]? grid;
            int width = Inputs[0].Length;
            int height = Inputs.Length;
            grid = new char[height, width];
            for (var y = 0; y < height; y++)
            {
                var line = Inputs[y];
                for (var x = 0; x < width; x++)
                {
                    var character = line[x];
                    grid[y, x] = character;
                }
            }
            return (grid, width, height);
        }

        public void ShowGrid(char[,] grid)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    Console.Write(grid[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
