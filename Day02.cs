using System.Text.RegularExpressions;

class Day02
{
    public static void Solve(string[] input)
    {
        Console.WriteLine("DAY02");
        int numberOfRedCubes = 12;
        int numberOfGreenCubes = 13;
        int numberOfBlueCubes = 14;

        // PART 1
        int sum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (largestNumberOfCubes(input[i], "red") <= numberOfRedCubes &&
                largestNumberOfCubes(input[i], "green") <= numberOfGreenCubes &&
                largestNumberOfCubes(input[i], "blue") <= numberOfBlueCubes)
            {
                sum += i + 1;
            }
        }
        Console.WriteLine($"Part1: {sum}");

        // PART 2
        sum = 0;
        foreach (string game in input)
        {
            sum += largestNumberOfCubes(game, "red") * 
                   largestNumberOfCubes(game, "green") * 
                   largestNumberOfCubes(game, "blue");
        }
        Console.WriteLine($"Part2: {sum}");
    }

    private static int largestNumberOfCubes(string line, string color)
    {
        Regex regex = new Regex(@$"(\d+) {color}");
        int maxNum = 0;
        foreach (Match match in regex.Matches(line))
        {
            int num = int.Parse(match.Groups[1].Value);
            if (maxNum < num) maxNum = num;
        }
        return maxNum;
    }
}
