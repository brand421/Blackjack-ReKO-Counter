Console.WriteLine(
    $"REKO 6-Deck Card Counter\n------------\nPress the 'x' key to exit at any time\n\nPlease enter how much your baseline bet is:\n\n"
);
string? baseBet = Console.ReadLine();
int initBet = Int32.Parse(baseBet);
int betAmount;
decimal decks = 6m;
int cardCount = 312;
int count = -20;
int tens = 120;
decimal tensProb = Convert.ToDecimal(tens) / cardCount;

Console.Write($"Current Count: {count}\n\n");
bool exit = false;
do
{
    ConsoleKeyInfo inf = Console.ReadKey(true);
    if (
        inf.Key == ConsoleKey.D2
        || inf.Key == ConsoleKey.D3
        || inf.Key == ConsoleKey.D4
        || inf.Key == ConsoleKey.D5
        || inf.Key == ConsoleKey.D6
        || inf.Key == ConsoleKey.D7
    )
    {
        count += 1;
    }
    else if (inf.Key == ConsoleKey.D1 || inf.Key == ConsoleKey.A)
    {
        count -= 1;
        tens -= 1;
    }
    else if (inf.Key == ConsoleKey.X)
    {
        exit = true;
    }

    switch (count)
    {
        case -3:
        case -2:
            betAmount = initBet * 2;
            break;
        case -1:
        case 0:
        case 1:
            betAmount = initBet * 5;
            break;
        case 2:
        case 3:
            betAmount = initBet * 10;
            break;
        case int n when n >= 4:
            betAmount = initBet * 15;
            break;
        default:
            betAmount = initBet;
            break;
    }

    string cardKey = inf.Key.ToString();
    int cardValue;
    string cardString;
    if (cardKey.Length > 1 && Int32.TryParse(cardKey.Substring(1), out cardValue))
    {
        cardString = cardValue == 1 ? "10" : cardValue.ToString();
    }
    else if (cardKey == "A")
    {
        cardString = "A";
    }
    else
    {
        cardString = "0";
    }
    cardCount -= 1;
    decks = cardCount / 52m;
    tensProb = Convert.ToDecimal(tens) / cardCount;
    Console.WriteLine(
        $"Count: {count}\nCard Played: {cardString}\nChance of Tens/Ace: {tensProb:P2}\nNext Bet: {betAmount}\n"
    );
} while (!exit);
