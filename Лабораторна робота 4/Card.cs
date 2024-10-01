namespace Лабораторна_робота_4
{
    public enum CardSuit
    {
        Spades,
        Clubs,
        Diamonds,
        Hearts
    }

    public class Card
    {
        private string _name;
        private CardSuit _suit;
        private int _value;
        public readonly static string[] names = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public string Name
        {
            get => _name;
            protected set
            {
                if (!names.Contains(value))
                    throw new ArgumentException("Card doesn't exist!");
                _name = value;
            }
        }

        public CardSuit Suit => _suit;

        public int Value => _value;


        public Card(string name, CardSuit suit, int value)
        {
            Name = name;
            _suit = suit;
            _value = value;
        }




        public static bool operator ==(Card card1, Card card2)
        {
            if (ReferenceEquals(card1, card2))
                return true;
            if (card1 is null || card2 is null)
                return false;
            return card1.Name == card2.Name && card1.Suit == card2.Suit && card1.Value == card2.Value;
        }

        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }
    }
}
