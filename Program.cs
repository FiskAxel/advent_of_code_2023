class Program
{
    public static void Main()
    {
        Day01.Solve(GetInput("input01.txt")); // 55130      54985
        Day02.Solve(GetInput("input02.txt")); // 2204       71036
        Day03.Solve(GetInput("input03.txt")); // 550064     123456
        Day04.Solve(GetInput("input04.txt")); // 20117      13768818 
        //Day05.Solve(GetInput("input05.txt")); // 
        Day06.Solve(GetInput("input06.txt")); // 227850     42948149
        Day07.Solve(GetInput("input07.txt")); // 252052080  252898370
        Day08.Solve(GetInput("input08.txt")); // 20093      22103062509257
        Day09.Solve(GetInput("input09.txt")); // 1868368343 1022
        //Day10.Solve(GetInput("input10.txt")); // 
        Day11.Solve(GetInput("input11.txt")); // 9609130    702152204842
        //Day12.Solve(GetInput("input12.txt")); // 
        //Day13.Solve(GetInput("input13.txt")); // 
        //Day14.Solve(GetInput("input14.txt")); // 
        //Day15.Solve(GetInput("input15.txt")); // 
        //Day16.Solve(GetInput("input16.txt")); // 
        //Day17.Solve(GetInput("input17.txt")); // 
        //Day18.Solve(GetInput("input18.txt")); // 
        //Day19.Solve(GetInput("input19.txt")); // 
        //Day20.Solve(GetInput("input20.txt")); // 
        //Day21.Solve(GetInput("input21.txt")); // 
        //Day22.Solve(GetInput("input22.txt")); // 
        //Day23.Solve(GetInput("input23.txt")); // 
        //Day24.Solve(GetInput("input24.txt")); // 
        //Day25.Solve(GetInput("input25.txt")); // 
    }

    public static string[] GetInput(string fileName)
    {
        try
        {
            StreamReader reader = new StreamReader($"../../../{fileName}");
            string[] input = reader.ReadToEnd().Trim().Split("\r\n");
            return input;
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
            return new string[1];
        }
    } 
}