class Day11
{
    public static void Solve(string[] input)
    {
        Console.WriteLine("DAY11");
        List<int> emptyRows = GetEmptyRows(input);
        List<int> emptyCols = GetEmptyColumns(input);

        // PART 1
        List<Position> galaxies = GetGalaxies(input, emptyRows, emptyCols, 2);
        Console.WriteLine($"Part1: {SumOfLengths(galaxies)}");

        // PART 2
        List<Position> galaxies2 = GetGalaxies(input, emptyRows, emptyCols, 1000000);
        Console.WriteLine($"Part2: {SumOfLengths(galaxies2)}");
    }

    static List<int> GetEmptyRows(string[] input)
    {
        List<int> rows = new List<int>();
        for (int i = 0; i < input.Length; i++)
        {
            if (!input[i].Contains('#'))
            {
                rows.Add(i);
            }
        }
        return rows;
    }

    static List<int> GetEmptyColumns(string[] input)
    {
        HashSet<int> cols = new HashSet<int>();
        for (int i = 0; i < input[0].Length; i++)
        {
            cols.Add(i);
        }

        for (int i = 0; i < input.Length; i++)
        {
            List<int> remove = new List<int>();
            foreach (int j in cols)
            {
                if (input[i][j] == '#')
                {
                    remove.Add(j);
                }
            }
            foreach (int n in remove)
            {
                cols.Remove(n);
            }
        }

        return cols.ToList();
    }
    
    static List<Position> GetGalaxies(string[] input, List<int> rows, List<int> cols, int galaxyOldness)
    {
        List<Position> positions = new List<Position>();
        int yOffset = 0;
        for (int y = 0; y < input.Length; y++)
        {
            if (rows.Contains(y))
                yOffset += galaxyOldness - 1;
            int xOffset = 0;
            for (int x = 0; x < input[y].Length; x++)
            {
                if (cols.Contains(x))
                    xOffset += galaxyOldness - 1;
                if (input[y][x] == '#')
                    positions.Add(new Position(x + xOffset, y + yOffset));
            }
        }
        return positions;
    }
    
    static long SumOfLengths(List<Position> galaxies)
    {
        long sum = 0;
        for (int i = 0; i < galaxies.Count; i++)
        {
            for (int j = i + 1; j < galaxies.Count; j++)
            {
                sum += Manhattan(galaxies[i], galaxies[j]);
            }
        }
        return sum;
    }

    static long Manhattan(Position a, Position b)
    {
        return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
    }

    class Position
    {
        public long x;
        public long y;
        public Position(long x, long y) { this.x = x; this.y = y; }
    }
}
