using System.Text.RegularExpressions;

class Day06
{
    public static void Solve(string[] input)
    {
        Console.WriteLine("DAY06");

        // PART 1
        long[] times = Parse1(input[0]);
        long[] recordDistances = Parse1(input[1]);
        int result = 1;
        for (int i = 0; i < times.Length; i++)
        {
            result *= numberOfWins(times[i], recordDistances[i]);
        }
        Console.WriteLine($"Part1: {result}");

        // PART 2
        long time = Parse2(input[0]);
        long recordDistance = Parse2(input[1]);
        Console.WriteLine($"Part2: {numberOfWins(time, recordDistance)}");
    }

    static int numberOfWins(long time, long recordDistance)
    {
        int wins = 0;
        for (int i = 1; i < time; i++)
            if ((time - i) * i > recordDistance) wins++;
        return wins;
    }

    static long[] Parse1(string input)
    {
        return Regex.Matches(input, @"\d+")
            .Cast<Match>()
            .Select(m => long.Parse(m.Value))
            .ToArray();
    }

    static long Parse2(string input)
    {
        List<string> m = Regex.Matches(input, @"\d+")
                            .Cast<Match>()
                            .Select(m => m.Value)
                            .ToList();
        return long.Parse(string.Join("", m));
    }
}
