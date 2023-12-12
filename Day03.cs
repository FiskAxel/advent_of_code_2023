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
                    gears.Add(new Position(y, x));
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
            if (NumberOfAdjacentPartNums(p, input) == 2)
            {
                //int gearRatio = num1 * num2;
                sum += 1; // gear ratio
            }
        }
        Console.WriteLine($"Part2: {sum}");
    }

    static int NumberOfAdjacentPartNums(Position p, string[] input)
    {   
        string a = "";
        string b = input[p.y].Substring(p.x - 1, 3);
        string c = "";
        if (p.y != 0) 
            a = input[p.y - 1].Substring(p.x - 1, 3);
        if (p.y < input.Length - 1) 
            c = input[p.y + 1].Substring(p.x - 1, 3);

        int num = 0;
        num += regexNumber.Matches(a).Count();
        num += regexNumber.Matches(b).Count();
        num += regexNumber.Matches(c).Count();
        return num;
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
