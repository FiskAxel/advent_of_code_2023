using System.Dynamic;
using System.Numerics;
using System.Text.RegularExpressions;

class Day03
{
    static Regex regexNumber = new Regex(@"(\d+)");

    public static void Solve(string[] input)
    {
        Console.WriteLine("DAY03");

        Regex regexNumber = new Regex(@"(\d+)");
        Regex regexSymbol = new Regex(@"[^\d.]");
        List<Number> numbers = new List<Number>();
        HashSet<string> symbolAdjecentPositions = new HashSet<string>();
        List<Position> gears = new List<Position>();
        for (int y = 0; y < input.Length; y++)
        {
            foreach (Match match in regexNumber.Matches(input[y]))
            {
                numbers.Add(new Number(
                    int.Parse(match.Groups[1].Value),
                    match.Index,
                    y,
                    match.Index + match.Groups[1].Value.Length));
            }

            foreach (Match match in regexSymbol.Matches(input[y]))
            {
                int x = match.Index;
                symbolAdjecentPositions.Add($"{y - 1},{x - 1}");
                symbolAdjecentPositions.Add($"{y - 1},{x}");
                symbolAdjecentPositions.Add($"{y - 1},{x + 1}");
                symbolAdjecentPositions.Add($"{y},{x - 1}");
                symbolAdjecentPositions.Add($"{y},{x + 1}");
                symbolAdjecentPositions.Add($"{y + 1},{x - 1}");
                symbolAdjecentPositions.Add($"{y + 1},{x}");
                symbolAdjecentPositions.Add($"{y + 1},{x + 1}");

                if (match.Groups[0].Value == "*")
                {
                    gears.Add(new Position(x, y));
                }
            }
        }

        // PART 1
        int sum = 0;
        foreach (var n in numbers)
        {
            bool partNumber = false;
            for (int x = n.x; x < n.x2; x++)
            {
                if (symbolAdjecentPositions.Contains($"{n.y},{x}"))
                {
                    partNumber = true;
                    break;
                }
            }
            if (partNumber)
            {
                sum += n.num;
            }
        }
        Console.WriteLine($"Part1: {sum}");

        // PART 2
        sum = 0;
        foreach (Position p in gears)
        {
            string a = "";
            string b = input[p.y].Substring(p.x - 1, 3);
            string c = "";
            if (p.y != 0)
                a = input[p.y - 1].Substring(p.x - 1, 3);
            if (p.y < input.Length - 1)
                c = input[p.y + 1].Substring(p.x - 1, 3);
            MatchCollection m1 = regexNumber.Matches(a);
            MatchCollection m2 = regexNumber.Matches(b);
            MatchCollection m3 = regexNumber.Matches(c);
            int num = m1.Count() + m2.Count() + m3.Count();
            if (num == 2)
            {
                int gearRatio = 1;
                foreach (Match m in m1)
                    gearRatio *= GetGearRatio(p.x - 1 + m.Index, input[p.y - 1]);
                foreach (Match m in m2)
                    gearRatio *= GetGearRatio(p.x - 1 + m.Index, input[p.y]);
                foreach (Match m in m3)
                    gearRatio *= GetGearRatio(p.x - 1 + m.Index, input[p.y + 1]);
                sum += gearRatio;
            }
        }
        Console.WriteLine($"Part2: {sum}");
    }

    static int GetGearRatio(int index, string row)
    {
        int i = index;
        string num = "";
        while (i >= 0 && Char.IsDigit(row[i]))
        {
            num = row[i] + num;
            i--;
        }
        i = index + 1;
        while (i < row.Length && Char.IsDigit(row[i]))
        {
            num += row[i];
            i++;
        }
        return int.Parse(num);
    }

    class Number
    {
        public int num;
        public int x;
        public int y;
        public int x2;

        public Number(int num, int x, int y, int x2)
        {
            this.num = num;
            this.x = x;
            this.y = y;
            this.x2 = x2;
        }
    }

    class Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
