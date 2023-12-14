using System.Collections;

class Day05
{
    public static void Solve(string[] input)
    {
        Console.WriteLine("DAY05");

        List<long> seeds = input[0].Substring("seeds: ".Length)
            .Split(' ')
            .Where(s => long.TryParse(s, out _))
            .Select(long.Parse)
            .ToList();
        int index = 3;
        ArrayList seedToSoil = method(input, index, out index);
        ArrayList soilToFertilizer = method(input, index, out index);
        ArrayList fertilizerToWater = method(input, index, out index);
        ArrayList waterToLight = method(input, index, out index);
        ArrayList ligthToTemperature = method(input, index, out index);
        ArrayList temperatureToHumidity = method(input, index, out index);
        ArrayList humidityToLocation = method(input, index, out index);
        // PART 1
        int sum = 0;
        Console.WriteLine($"Part1: {sum}");

        // PART 2
        Console.WriteLine($"Part2: {sum}");
    }

    static ArrayList method(string[] input, int index, out int i) 
    {
        i = index;
        ArrayList map = new ArrayList();
        while (i < input.Length && input[i] != "")
        {
            map.Add(input[i]
                .Split(' ')
                .Where(s => long.TryParse(s, out _))
                .Select(long.Parse)
                .ToList());
            i++;
        }
        i += 2;
        return map;
    }
}
