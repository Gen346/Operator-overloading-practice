using Лабораторна_робота_4;

class Program
{
    static List<CardDeck> decks = new List<CardDeck>();
    

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\tMenu");
            Console.WriteLine("1. Create a new deck");
            Console.WriteLine("2. Show all decks");
            Console.WriteLine("3. Shuffle all decks");
            Console.WriteLine("4. Deal one card from each deck");
            Console.WriteLine("5. Deal six cards from deck");
            Console.WriteLine("6. Find card by name in all decks");
            Console.WriteLine("7. Compare all decks");
            Console.WriteLine("8. Combine all decks");
            Console.WriteLine("9. Clear all decks");
            Console.WriteLine("10. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewDeck();
                    break;
                case "2":
                    ShowAllDecks();
                    break;
                case "3":
                    ShuffleAllDecks();
                    break;
                case "4":
                    DealOneCardFromEachDeck();
                    break;
                case "5":
                    DealFiveCardsFromEachDeck();
                    break;
                case "6":
                    FindCardByNameInAllDecks();
                    break;
                case "7":
                    CompareAllDecks();
                    break;
                case "8":
                    CombineAllDecks();
                    break;
                case "9":
                    ClearAllDecks();
                    break;
                case "10":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }

    }

    static void CreateNewDeck()
    {
        decks.Add(new CardDeck());
        Console.WriteLine("New deck created.");
    }

    static void ShowAllDecks()
    {
        int deckNumber = 1;
        foreach (var deck in decks)
        {
            Console.WriteLine($"Deck {deckNumber++}:");
            deck.PrintDeck();
        }
    }

    static void ShuffleAllDecks()
    {
        foreach (var deck in decks)
        {
            deck.Shuffle();
        }
        Console.WriteLine("All decks have been shuffled.");
    }

    static void DealOneCardFromEachDeck()
    {
        foreach (var deck in decks)
        {
            deck.DealCard();
        }
    }

    static void DealFiveCardsFromEachDeck()
    {
        foreach (var deck in decks)
        {
            deck.DealHand(6);
        }
    }

    static void FindCardByNameInAllDecks()
    {
        Console.WriteLine("Enter card name to find:");
        string cardName = Console.ReadLine();
        bool cardFound = false;
        foreach (var deck in decks)
        {
            deck.PrintCardsByNumber(cardName);
        }
    }



    static void CompareAllDecks()
    {
        if (decks.Count < 2)
        {
            Console.WriteLine("Need at least two decks to compare.");
            return;
        }

        for (int i = 0; i < decks.Count - 1; i++)
        {
            if (decks[i] > decks[i + 1])
            {
                Console.WriteLine("The first deck has more cards than the second one.");
                return;
            }
            else if (decks[i] < decks[i + 1])
            {
                Console.WriteLine("The first deck has fewer cards than the second one.");
                return;
            }
        }
        Console.WriteLine("Decks have the same number of cards.");
    }


    private static void CombineAllDecks()
    {
        List<int> indexesToRemove = new List<int>();

        for (int i = 0; i < decks.Count; i++)
        {

            if (decks[i] != decks[0])
            {
                indexesToRemove.Add(i);
            }
            else
            {
                decks[0].GetCards().AddRange(decks[i].GetCards());
            }
        }

        foreach (int index in indexesToRemove.OrderByDescending(x => x))
        {
            decks.RemoveAt(index);
        }
    }


    static void ClearAllDecks()
    {
        decks.Clear();
        Console.WriteLine("All decks cleared.");
    }
}
