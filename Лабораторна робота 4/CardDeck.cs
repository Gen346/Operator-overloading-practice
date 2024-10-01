namespace Лабораторна_робота_4
{
    public class CardDeck
    {
        private List<Card> _cards;


        public CardDeck()
        {
            _cards = CardDeck.CreateDeck();
        }

        public static List<Card> CreateDeck()
        {

            List<Card> deck = new List<Card>();

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (string name in Card.names)
                {

                    int value;
                    if (int.TryParse(name, out value))
                        value = int.Parse(name);
                    else if (name == "A")
                        value = 11;
                    else
                        value = 10;

                    deck.Add(new Card(name, suit, value));
                }
            }


            return deck;
        }

        public static void _ShuffleDeck(List<Card> deck)
        {
            Random random = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }
        public List<Card> GetCards()
        {
            return _cards;
        }

        public void Shuffle()
        {
            CardDeck._ShuffleDeck(_cards);
            Console.WriteLine("Deck has been shuffled.");
        }

        public void PrintDeck()
        {
            Console.WriteLine("Deck contents:");
            foreach (var card in _cards)
            {
                Console.WriteLine($"{card.Name} of {card.Suit}");
            }
        }

        public Card DealCard()
        {
            if (_cards.Count == 0)
            {
                Console.WriteLine("The deck is empty!");
                return null;
            }

            Card card = _cards[0];
            _cards.RemoveAt(0);
            Console.WriteLine($"Dealt card: {card.Name} of {card.Suit}");
            return card;
        }

        public List<Card> DealHand(int numCards)
        {
            if (_cards.Count < numCards)
            {
                Console.WriteLine("Not enough cards in the deck!");
                return null;
            }

            List<Card> hand = new List<Card>();
            Console.WriteLine($"Dealing a hand of {numCards} cards:");
            for (int i = 0; i < numCards; i++)
            {
                Card card = _cards[0];
                hand.Add(card);
                _cards.RemoveAt(0);
                Console.WriteLine($"Card {i + 1}: {card.Name} of {card.Suit}");
            }

            return hand;
        }


        public void PrintCardsByNumber(string number)
        {
            var matchingCards = _cards.Where(card => card.Name == number);
            if (matchingCards.Any())
            {
                Console.WriteLine($"Cards with number {number}:");
                foreach (var card in matchingCards)
                {
                    Console.WriteLine($"Card '{card.Name}' of {card.Suit}");
                }
            }
            else
            {
                Console.WriteLine($"No cards found with number {number}.");
            }
        }



        //public static int CompareDecks(CardDeck deck1, CardDeck deck2)
        //{
        //    int countComparison = deck1._cards.Count.CompareTo(deck2._cards.Count);
        //    if (countComparison != 0)
        //        return countComparison;
        //    for (int i = 0; i < deck1._cards.Count; i++)
        //    {
        //        if (deck1._cards[i] != deck2._cards[i])
        //            return -1;
        //    }

        //    return 0;
        //}

        public static CardDeck operator +(CardDeck deck1, CardDeck deck2)
        {
            deck1._cards.AddRange(deck2._cards);
            deck2.ClearDeck();
            Console.WriteLine("Decks have been combined.");
            return deck1;
        }


        public void ClearDeck()
        {
            _cards.Clear();
        }
        public static bool operator >(CardDeck deck1, CardDeck deck2)
        {
            return deck1.GetCards().Count > deck2.GetCards().Count;
        }

        public static bool operator <(CardDeck deck1, CardDeck deck2)
        {
            return deck1.GetCards().Count < deck2.GetCards().Count;
        }
    }
}
