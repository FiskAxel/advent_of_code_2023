using System.Text.RegularExpressions;

class Day04
{
    public static void Solve(string[] input)
    {
        Console.WriteLine("DAY04");
        int[] numberOfCards = Enumerable.Repeat(1, input.Length).ToArray();
        int[] winsPerCard = new int[input.Length];

        // PART 1
        int sum = 0;
        Regex regex = new Regex(@"(\d+\s+)+\|");
        int numberOfWinningNumbers = regex.Match(input[0]).Value.TrimEnd('|').TrimEnd(' ').Split(' ').Length;
        regex = new Regex(@"(\d+)( |$)");
        for (int i = 0; i < input.Length; i++)
        {
            MatchCollection matches = regex.Matches(input[i]);
            List<int> allNumbers = matches.Cast<Match>().Select(match => int.Parse(match.Groups[1].Value)).ToList();
            List<int> winningNumbers = allNumbers.Take(numberOfWinningNumbers).ToList();
            List<int> numbers = allNumbers.Skip(numberOfWinningNumbers).ToList();
            int wins = numbers.Intersect(winningNumbers).Count();
            sum += Utility.Power(2, wins - 1);

            winsPerCard[i] = wins;
        }
        Console.WriteLine($"Part1: {sum}");

        // PART 2
        sum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            sum += numberOfCards[i];
            for (int j = 1; j <= winsPerCard[i]; j++)
            {
                if (i + j >= input.Length) break;
                numberOfCards[i + j] += numberOfCards[i];
            }
        }
        Console.WriteLine($"Part2: {sum}");
    }
}
