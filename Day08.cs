using System.Collections;

class Day08
{
    public static void Solve(string[] input)
    {
        Console.WriteLine("DAY08");

        string instructions = input[0];
        Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        List<string> positions = new List<string>();
        for (int i = 2; i < input.Count(); i++)
        {
            string k = input[i].Substring(0, 3);
            string L = input[i].Substring(7, 3);
            string R = input[i].Substring(12, 3);
            nodes[k] = new Node(L, R);
            if (k.Last() == 'A') positions.Add(k);
        }

        // PART 1
        long steps = 0;
        int ins = 0;
        string current = "AAA";
        while (current != "ZZZ")
        {
            steps++;
            current = instructions[ins] switch
            {
                'L' => nodes[current].L,
                'R' => nodes[current].R,
                _ => "ERROR"
            };
            ins = (ins + 1) % instructions.Length;
        }
        Console.WriteLine($"Part1: {steps}");

        // PART 2
        steps = 0;
        Stack<long> l = new Stack<long>();
        foreach (string position in positions)
        {
            l.Push(Steps(nodes, instructions, position));
        }
        Console.WriteLine($"Part2: {LCM(l)}");
    }

    static int Steps(Dictionary<string, Node> nodes, string instructions, string current)
    {
        int steps = 0;
        int ins = 0;
        while (current.Last() != 'Z')
        {
            steps++;
            current = instructions[ins] switch
            {
                'L' => nodes[current].L,
                'R' => nodes[current].R,
                _ => "ERROR"
            };
            ins = (ins + 1) % instructions.Length;
        }
        return steps;
    }

    static long LCM(Stack<long> l)
    {
        while (l.Count > 1)
        {
            l.Push(lcm(l.Pop(), l.Pop()));
        }
        return l.Pop();
    }

    static long lcm(long a, long b)
    {
        return (a / gcf(a, b)) * b;
    }
    
    static long gcf(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public class Node
    {
        public string L;
        public string R;
        public Node(string L, string R)
        {
            this.L = L;
            this.R = R;
        }
    }
}
