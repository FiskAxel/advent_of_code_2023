using System.Text.RegularExpressions;

class Day01
{
    private static Dictionary<string, char> numbers = new Dictionary<string, char>
    {
        { "one", '1' },
        { "two", '2' },
        { "three", '3' },
        { "four", '4' },
        { "five", '5' },
        { "six", '6' },
        { "seven", '7' },
        { "eight", '8' },
        { "nine", '9' },
    };

    public static void Solve(string[] input)
    {
        Console.WriteLine("DAY01");

        // PART 1
        int sum = 0;
        Regex regexFirstNum = new Regex(@"^\D*(\d)");
        Regex regexLastNum = new Regex(@"(\d)\D*$");
        foreach (string line in input)
        {
            Match m1 = regexFirstNum.Match(line);
            Match m2 = regexLastNum.Match(line);
            string num = m1.Groups[1].Value + m2.Groups[1].Value;
            sum += int.Parse(num);
        }
        Console.WriteLine($"Part1: {sum}");

        // PART 2
        sum = 0;
        foreach (string line in input)
        {
            char[] num = { GetFirstNumber(line), GetLastNumber(line) };
            sum += int.Parse(new string(num));
        }
        Console.WriteLine($"Part2: {sum}");
    }

    private static char GetFirstNumber(string line)
    {
        char number = ' ';
        int i = 0;
        foreach (char c in line)
        {
            if (int.TryParse(c.ToString(), out int _))
            {
                number = c;
                break;
            }
            i++;
        }

        foreach (string key in numbers.Keys)
        {
            string revKey = Utility.Reverse(key);
            if (line.Contains(key) && line.IndexOf(key) < i)
            {
                number = numbers[key];
                i = line.IndexOf(key);
            }
            if (line.Contains(revKey) && line.IndexOf(revKey) < i)
            {
                number = numbers[key];
                i = line.IndexOf(revKey);
            }
        }
        return number;
    }

    private static char GetLastNumber(string line)
    {
        return GetFirstNumber(Utility.Reverse(line));
    }
}
