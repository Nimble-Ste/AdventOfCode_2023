namespace Day11ConsoleApp
{

    internal class Program
    {

        const int expansion = -1;
        const int expansionValue = 1000000;
        
        class Pair
        {
            public int G1 { get; set; }
            public int G2 { get; set; }
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }


        static async Task Main(string[] args)
        {

           // PartA();
            
            PartB();

        }

        static void PartB()
        {
            string inputFile = "day11bInput.txt";

            string[] lines = File.ReadAllLines(inputFile);
            int galaxyNum = 1;
            List<List<int>> galaxy = new List<List<int>>();
            bool[] galaxyInColumn = new bool[lines[0].Length];

            foreach (string line in lines)
            {
                List<int> newLine = new List<int>();
                bool galaxyInRow = false;

                for (int x = 0; x < line.Length; x++)
                {
                    char character = line[x];

                    if (character == '.')
                    {
                        newLine.Add(0);
                    }
                    else
                    {
                        newLine.Add(galaxyNum);
                        galaxyNum++;
                        galaxyInRow = true;
                        galaxyInColumn[x] = true;
                    }
                }

                if (!galaxyInRow)
                {
                    for (int x = 0; x < line.Length; x++)
                    {
                        newLine[x] = expansion;
                    }
                }

                galaxy.Add(newLine);
            }

            // Expand galaxy columns
            List<List<int>> newGalaxy = new List<List<int>>();
            for (int i = 0; i < galaxy.Count; i++)
            {
                List<int> newGalaxyLine = new List<int>();
                for (int j = 0; j < galaxy[i].Count; j++)
                {
                    if (galaxyInColumn[j])
                    {
                        newGalaxyLine.Add(galaxy[i][j]);
                    }
                    else
                    {
                        newGalaxyLine.Add(expansion);
                    }
                }
                newGalaxy.Add(newGalaxyLine);
            }

            // Set galaxy positions
            Dictionary<int, Point> galaxyPositions = new Dictionary<int, Point>();
            for (int y = 0; y < newGalaxy.Count; y++)
            {
                for (int x = 0; x < newGalaxy[y].Count; x++)
                {
                    if (newGalaxy[y][x] != 0)
                    {
                        galaxyPositions[newGalaxy[y][x]] = new Point { X = x, Y = y };
                    }
                }
            }

            // Get pairs
            List<Pair> pairs = new List<Pair>();
            for (int i = 1; i < galaxyNum; i++)
            {
                for (int j = i + 1; j < galaxyNum; j++)
                {
                    pairs.Add(new Pair { G1 = i, G2 = j });
                }
            }

            // Calculate result
            int output = 0;
            foreach (Pair pair in pairs)
            {
                output += Distance(newGalaxy, galaxyPositions[pair.G1], galaxyPositions[pair.G2]);
            }

            // Print the result
            Console.WriteLine(output);
        }

        static int Distance(List<List<int>> galaxy, Point p1, Point p2)
        {
            int xDiff = 0;
            for (int i = Math.Min(p1.X, p2.X); i < Math.Max(p1.X, p2.X); i++)
            {
                int gridValue = galaxy[p1.Y][i];
                if (gridValue == expansion)
                {
                    xDiff += expansionValue;
                }
                else
                {
                    xDiff += 1;
                }
            }

            int yDiff = 0;
            for (int i = Math.Min(p1.Y, p2.Y); i < Math.Max(p1.Y, p2.Y); i++)
            {
                int gridValue = galaxy[i][p1.X];
                if (gridValue == expansion)
                {
                    yDiff += expansionValue;
                }
                else
                {
                    yDiff += 1;
                }
            }

            return xDiff + yDiff;
        }

        static void PartA()
        {
            // Read input file
            string inputFile = "day11aInput.txt";

            string[] lines = File.ReadAllLines(inputFile);

            int galaxyNum = 1;
            List<List<int>> galaxy = new List<List<int>>();
            bool[] galaxyInColumn = new bool[lines[0].Length];

            foreach (string line in lines)
            {
                List<int> newLine = new List<int>();
                bool galaxyInRow = false;

                for (int y = 0; y < line.Length; y++)
                {
                    char charValue = line[y];
                    if (charValue == '.')
                    {
                        newLine.Add(0);
                    }
                    else
                    {
                        newLine.Add(galaxyNum);
                        galaxyNum++;
                        galaxyInRow = true;
                        galaxyInColumn[y] = true;
                    }
                }

                galaxy.Add(newLine);

                if (!galaxyInRow)
                {
                    List<int> anotherNewLine = new List<int>(newLine);
                    galaxy.Add(anotherNewLine);
                }
            }

            // Expand galaxy columns
            List<List<int>> newGalaxy = new List<List<int>>();
            for (int i = 0; i < galaxy.Count; i++)
            {
                List<int> newGalaxyLine = new List<int>();
                for (int j = 0; j < galaxy[i].Count; j++)
                {
                    newGalaxyLine.Add(galaxy[i][j]);
                    if (!galaxyInColumn[j])
                    {
                        newGalaxyLine.Add(0);
                    }
                }

                newGalaxy.Add(newGalaxyLine);
            }

            // Set galaxy positions
            Dictionary<int, Point> galaxyPositions = new Dictionary<int, Point>();
            for (int y = 0; y < newGalaxy.Count; y++)
            {
                for (int x = 0; x < newGalaxy[y].Count; x++)
                {
                    if (newGalaxy[y][x] != 0)
                    {
                        galaxyPositions[newGalaxy[y][x]] = new Point {X = x, Y = y};
                    }
                }
            }

            // Get pairs
            List<Pair> pairs = new List<Pair>();
            for (int i = 1; i < galaxyNum; i++)
            {
                for (int j = i + 1; j < galaxyNum; j++)
                {
                    pairs.Add(new Pair {G1 = i, G2 = j});
                }
            }

            // Calculate result
            int output = 0;
            foreach (Pair pair in pairs)
            {
                output += CartesianDistance(galaxyPositions[pair.G1], galaxyPositions[pair.G2]);
            }

            // Print the result
            Console.WriteLine(output);
        }


        static int CartesianDistance(Point p1, Point p2)
        {
            int xDiff = Math.Abs(p2.X - p1.X);
            int yDiff = Math.Abs(p2.Y - p1.Y);
            return xDiff + yDiff;
        }


    }
}
