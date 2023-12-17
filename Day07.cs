class Day07
{
    public static void Solve(string[] input)
    {
        Console.WriteLine("DAY07");

        List<Hand> hands = new List<Hand>();
        foreach (string s in input)
        {
            string[] parse = s.Split(' ');
            string cards = parse[0];
            int bet = int.Parse(parse[1]);
            hands.Add(new Hand(cards, GetHandType(cards), bet));
        }

        // PART 1
        SortByStrength(hands, false);
        hands = hands.OrderBy(h => h.type).ToList();
        Console.WriteLine($"Part1: {TotalWinnings(hands)}");

        // PART 2
        foreach (Hand hand in hands)
        {
            hand.type = GetHandType2(hand.cards);

        }
        SortByStrength(hands, true);
        hands = hands.OrderBy(h => h.type).ToList();
        Console.WriteLine($"Part2: {TotalWinnings(hands)}");
    }

    static int GetHandType(string cards)
    {
        Dictionary<char, int> cardCount = new Dictionary<char, int>()
        {
            { 'A', 0 }, { 'K', 0 }, { 'Q', 0 }, { 'J', 0 }, { 'T', 0 },
            { '9', 0 }, { '8', 0 }, { '7', 0 }, { '6', 0 }, { '5', 0 }, { '4', 0 }, { '3', 0 }, { '2', 0 }
        };
        foreach (char c in cards)
        {
            cardCount[c]++;
        }

        Dictionary<int, int> cardCountSum = new Dictionary<int, int>()
        {
            { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }
        };
        foreach (int value in cardCount.Values)
        {
            cardCountSum[value]++;
        }

        if (cardCountSum[5] == 1) return 7; // "Five of a kind"
        if (cardCountSum[4] == 1) return 6; // "Four of a kind"
        if (cardCountSum[3] == 1 &&
            cardCountSum[2] == 1) return 5; // "Full house"
        if (cardCountSum[3] == 1) return 4; // "Three of a kind"
        if (cardCountSum[2] == 2) return 3; // "Two pair"
        if (cardCountSum[2] == 1) return 2; // "One pair"
        if (cardCountSum[1] == 5) return 1; // "High card"

        return 0;
    }

    static int GetHandType2(string cards)
    {
        Dictionary<char, int> cardCount = new Dictionary<char, int>()
        {
            { 'A', 0 }, { 'K', 0 }, { 'Q', 0 }, { 'J', 0 }, { 'T', 0 },
            { '9', 0 }, { '8', 0 }, { '7', 0 }, { '6', 0 }, { '5', 0 }, { '4', 0 }, { '3', 0 }, { '2', 0 }
        };
        int j = 0;
        foreach (char c in cards)
        {
            if (c == 'J')
            {
                j++; continue;
            }
            cardCount[c]++;
        }

        Dictionary<int, int> cardCountSum = new Dictionary<int, int>()
        {
            { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }
        };
        foreach (int value in cardCount.Values)
        {
            cardCountSum[value]++;
        }
        cardCountSum[0] = 1;

        if (cardCountSum[5 - j] == 1)       return 7; // "Five of a kind"
        if (cardCountSum[4 - j] >= 1)       return 6; // "Four of a kind"
        if (cardCountSum[3] == 1 
            && cardCountSum[2] == 1 ||
            cardCountSum[2] == 2 && j == 1) return 5; // "Full house"
        if (cardCountSum[3 - j] >= 1)       return 4; // "Three of a kind"
        if (cardCountSum[2] == 2)           return 3; // "Two pair"
        if (cardCountSum[2] == 1 || j == 1) return 2; // "One pair"
        if (cardCountSum[1] == 5)           return 1; // "High card"

        return 0;
    }

    static void SortByStrength(List<Hand> hands, bool part2)
    {
        for (int i = 0; i < hands.Count - 1; i++)
        {
            for (int j = 0; j < hands.Count - 1 - i; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    int a = 0; int b = 0;
                    if (!part2)
                    {
                        a = ConvertToNum(hands[j].cards[k]);
                        b = ConvertToNum(hands[j + 1].cards[k]);
                    }
                    else if (part2)
                    {       
                        a = ConvertToNum2(hands[j].cards[k]);
                        b = ConvertToNum2(hands[j + 1].cards[k]);
                    }
                    if (a > b)
                    {
                        Hand temp = hands[j];
                        hands[j] = hands[j + 1];
                        hands[j + 1] = temp;
                        break;
                    }
                    else if (a < b) break;
                }
            }
        }
    }

    static int ConvertToNum(char c)
    {
        return c switch
        {
            'T' => 10,
            'J' => 11,
            'Q' => 12,
            'K' => 13,
            'A' => 14,
            _ => int.Parse(c.ToString())
        };
    }

    static int ConvertToNum2(char c)
    {
        return c switch
        {
            'T' => 10,
            'J' => 1,
            'Q' => 12,
            'K' => 13,
            'A' => 14,
            _ => int.Parse(c.ToString())
        };
    }

    static int TotalWinnings(List<Hand> hands)
    {
        int sum = 0;
        for (int i = 0; i < hands.Count; i++)
        {
            sum += hands[i].bet * (i + 1);
        }
        return sum;
    }

    public class Hand
    {
        public string cards;
        public int type;
        public int bet;

        public Hand(string cards, int type, int bet)
        {
            this.cards = cards;
            this.type = type;
            this.bet = bet;
        }
    }
}
