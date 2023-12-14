using System.Security.Cryptography;

class Day09
{
    public static void Solve(string[] input)
    {
        Console.WriteLine("DAY09");

        int sum1 = 0;
        int sum2 = 0;
        foreach (string line in input)
        {
            List<List<int>> history = new List<List<int>>();
            history.Add(line.Split(' ')
                            .Select(int.Parse)
                            .ToList());
            while (history[history.Count - 1].Sum() != 0)
            {
                history.Add(NextHistory(history[history.Count - 1]));
            }

            sum1 += CalculateNextSequence(history);
            sum2 += CalculatePreviousSequence(history);
        }
        Console.WriteLine($"Part1: {sum1}");
        Console.WriteLine($"Part2: {sum2}");
    }

    static List<int> NextHistory(List<int> prevHistory)
    {
        List<int> nextHistory = new List<int>();
        for (int i = 0; i < prevHistory.Count - 1; i++)
        {
            nextHistory.Add(prevHistory[i + 1] - prevHistory[i]);
        }
        return nextHistory;
    }

    static int CalculateNextSequence(List<List<int>> history)
    {
        for (int i = history.Count - 1;  --i >= 0;)
        {
            int nextSequence = history[i].Last() + history[i + 1].Last();
            history[i].Add(nextSequence);
        }
        return history[0].Last();
    }

    static int CalculatePreviousSequence(List<List<int>> history)
    {
        for (int i = history.Count - 1; --i >= 0;)
        {
            int previousSequence = history[i][0] - history[i + 1][0];
            history[i].Insert(0, previousSequence);
        }
        return history[0][0];
    }
}
