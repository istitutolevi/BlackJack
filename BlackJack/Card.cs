/*
#######################################################
#######################################################
### DEVELOPER       : EFE OMOREGIE ELIJAH           ###
### EMAIL           : DONDDOUG@GMAIL.COM            ###
### COMPLETION DATE : 14/01/2015                    ###
###                                                 ###
### NOTE: ANY CHANGES MADE TO THIS CODE SHOULD BE   ###
###       NOTED AND DESCRIBED AT THE BEGININING OF  ###
###       THE CODE AND POSSIBLY COMMUNICATED TO     ###
###       THE AUTHOR NAME ABOVE                     ###
#######################################################
#######################################################
*/
using BlackJack.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace BlackJack
{

    public class InvalidCardType : ApplicationException
    {
        public InvalidCardType() : base() { }
        public InvalidCardType(string msg) : base(msg) { }
    }
    public class CardMutationError : ApplicationException
    {
        public CardMutationError() : base() { }
        public CardMutationError(string msg) : base(msg) { }
    }

    /// <summary>
    /// Definition Of Card Class
    /// @Stores Card Value And Type
    /// </summary>
    public class Card
    {
        private int _Value;
        private SuitType _Suit;
        private Color _CardColor = Color.Black;

        public enum SuitType
        {
            Clubs, Spades, Hearts, Diamonds, Joker
        }
        public virtual int Value
        {
            get { return _Value; }
        }
        public virtual SuitType Suit
        {
            get { return _Suit; }
        }

        public Card(SuitType suit, Color color)// @ for joker
        {
            if (suit == SuitType.Joker)
            {
                _Suit = suit;
                _Value = 0;
                SuitColor = color;
            }
            else throw new InvalidCardType();
        }
        public Card(int value, SuitType suit)
        {
            _Suit = suit;
            if (value > 14 || value < 1) throw new InvalidCardType();
            else _Value = value;
        }
        public Card(SuitType suit, int value)
        {
            _Suit = suit;
            if (value > 14 || value < 1) throw new InvalidCardType();
            else _Value = value;
        }
        public Card(string s)
        {
            s = s.ToLower();
            if (s == null || s.Length < 2 || s.Length > 3) throw new InvalidCardType();
            switch (s[0])
            {
                case 'c':
                    _Suit = SuitType.Clubs;
                    break;
                case 's':
                    _Suit = SuitType.Spades;
                    break;
                case 'h':
                    _Suit = SuitType.Hearts;
                    break;
                case 'd':
                    _Suit = SuitType.Diamonds;
                    break;
                default:
                    throw new InvalidCardType();
            }

            string ns;
            if (s.Length == 3) ns = s[1].ToString() + s[2].ToString();
            else ns = s[1].ToString();

            int newValue = int.Parse(ns);
            if (newValue > 13 || newValue < 1) throw new InvalidCardType();
            _Value = newValue;
        }

        public static bool operator ==(Card card1, Card card2)
        {
            try
            {
                return (card1.Suit == card2.Suit && card1.Value == card2.Value);
            }
            catch
            {
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            Card newcard = obj as Card;
            if (newcard != null) return (newcard == this);
            return false;
        }
        public override int GetHashCode()
        {
            return Suit.GetHashCode() * Value.GetHashCode();
        }
        public static bool operator !=(Card card1, Card card2)
        {
            try
            {
                return !(card1 == card2);
            }
            catch
            {
                return false;
            }
        }
        public static bool operator <(Card card1, Card card2)
        {
            return (card1.Value < card2.Value);
        }
        public static bool operator <=(Card card1, Card card2)
        {
            return (card1.Value == card2.Value) || (card1 < card2);
        }
        public static bool operator >(Card card1, Card card2)
        {
            return (card1.Value > card2.Value);
        }
        public static bool operator >=(Card card1, Card card2)
        {
            return (card1.Value == card2.Value) || (card1 > card2);
        }

        public string Symbol
        {
            get
            {
                string encodedCard = "";
                switch (Suit)
                {
                    case SuitType.Clubs:
                        encodedCard += '♠';
                        break;
                    case SuitType.Spades:
                        encodedCard += '♣';
                        break;
                    case SuitType.Hearts:
                        encodedCard += '♥';
                        break;
                    case SuitType.Diamonds:
                        encodedCard += '♦';
                        break;
                }
                encodedCard += Value;
                return encodedCard;
            }
            private set { }
        }
        public string Suitsymbol
        {
            get
            {
                string encodedCard = "";
                switch (Suit)
                {
                    case SuitType.Clubs:
                        encodedCard += '♠';
                        break;
                    case SuitType.Spades:
                        encodedCard += '♣';
                        break;
                    case SuitType.Hearts:
                        encodedCard += '♥';
                        break;
                    case SuitType.Diamonds:
                        encodedCard += '♦';
                        break;
                }
                return encodedCard;
            }
            private set { }
        }
        public float SymbolSize
        {
            get
            {
                float s;
                switch (Value)
                {
                    case 13:
                        s = 30;
                        break;
                    case 12:
                        s = 30;
                        break;
                    case 11:
                        s = 30;
                        break;
                    case 9:
                        s = 16;
                        break;
                    case 8:
                        s = 18;
                        break;
                    case 7:
                        s = 21;
                        break;
                    case 3:
                        s = 25;
                        break;
                    case 2:
                        s = 25;
                        break;
                    case 1:
                        s = 25;
                        break;
                    default:
                        s = 20;
                        break;
                }
                return s;
            }
            private set { }
        }
        public virtual Color SuitColor
        {
            get
            {
                var cardcolor = Color.Black;
                switch (Suit)
                {
                    case SuitType.Hearts:
                        cardcolor = Color.Red;
                        break;
                    case SuitType.Diamonds:
                        cardcolor = Color.Red;
                        break;
                }
                return cardcolor;
            }
            private set { }
        }
        public Image CardImage()
        {
            Bitmap img = new Bitmap(0,0);

            switch (Suit)
            {
                case SuitType.Joker:
                    if (SuitColor == Color.Black)
                        img = Properties.Resources.black_joker;
                    else
                        img = Properties.Resources.red_joker;
                    break;
                case SuitType.Spades:
                    switch (Value)
                    {
                        case 1:
                            img = Properties.Resources.ace_of_spades;
                            break;
                        case 2:
                            img = Properties.Resources._2_of_spades;
                            break;
                        case 3:
                            img = Properties.Resources._3_of_spades;
                            break;
                        case 4:
                            img = Properties.Resources._4_of_spades;
                            break;
                        case 5:
                            img = Properties.Resources._5_of_spades;
                            break;
                        case 6:
                            img = Properties.Resources._6_of_spades;
                            break;
                        case 7:
                            img = Properties.Resources._7_of_spades;
                            break;
                        case 8:
                            img = Properties.Resources._8_of_spades;
                            break;
                        case 9:
                            img = Properties.Resources._9_of_spades;
                            break;
                        case 10:
                            img = Properties.Resources._10_of_spades;
                            break;
                        case 11:
                            img = Properties.Resources.jack_of_spades;
                            break;
                        case 12:
                            img = Properties.Resources.queen_of_spades;
                            break;
                        case 13:
                            img = Properties.Resources.king_of_spades;
                            break;
                    }
                    break;
                case SuitType.Diamonds:
                    switch (Value)
                    {
                        case 1:
                            img = Properties.Resources.ace_of_diamonds;
                            break;
                        case 2:
                            img = Properties.Resources._2_of_diamonds;
                            break;
                        case 3:
                            img = Properties.Resources._3_of_diamonds;
                            break;
                        case 4:
                            img = Properties.Resources._4_of_diamonds;
                            break;
                        case 5:
                            img = Properties.Resources._5_of_diamonds;
                            break;
                        case 6:
                            img = Properties.Resources._6_of_diamonds;
                            break;
                        case 7:
                            img = Properties.Resources._7_of_diamonds;
                            break;
                        case 8:
                            img = Properties.Resources._8_of_diamonds;
                            break;
                        case 9:
                            img = Properties.Resources._9_of_diamonds;
                            break;
                        case 10:
                            img = Properties.Resources._10_of_diamonds;
                            break;
                        case 11:
                            img = Properties.Resources.jack_of_diamonds;
                            break;
                        case 12:
                            img = Properties.Resources.queen_of_diamonds;
                            break;
                        case 13:
                            img = Properties.Resources.king_of_diamonds;
                            break;
                    }
                    break;
                case SuitType.Hearts:
                    switch (Value)
                    {
                        case 1:
                            img = Properties.Resources.ace_of_hearts;
                            break;
                        case 2:
                            img = Properties.Resources._2_of_hearts;
                            break;
                        case 3:
                            img = Properties.Resources._3_of_hearts;
                            break;
                        case 4:
                            img = Properties.Resources._4_of_hearts;
                            break;
                        case 5:
                            img = Properties.Resources._5_of_hearts;
                            break;
                        case 6:
                            img = Properties.Resources._6_of_hearts;
                            break;
                        case 7:
                            img = Properties.Resources._7_of_hearts;
                            break;
                        case 8:
                            img = Properties.Resources._8_of_hearts;
                            break;
                        case 9:
                            img = Properties.Resources._9_of_hearts;
                            break;
                        case 10:
                            img = Properties.Resources._10_of_hearts;
                            break;
                        case 11:
                            img = Properties.Resources.jack_of_hearts;
                            break;
                        case 12:
                            img = Properties.Resources.queen_of_hearts;
                            break;
                        case 13:
                            img = Properties.Resources.king_of_hearts;
                            break;
                    }
                    break;
                case SuitType.Clubs:
                    switch (Value)
                    {
                        case 1:
                            img = Properties.Resources.ace_of_clubs;
                            break;
                        case 2:
                            img = Properties.Resources._2_of_clubs;
                            break;
                        case 3:
                            img = Properties.Resources._3_of_clubs;
                            break;
                        case 4:
                            img = Properties.Resources._4_of_clubs;
                            break;
                        case 5:
                            img = Properties.Resources._5_of_clubs;
                            break;
                        case 6:
                            img = Properties.Resources._6_of_clubs;
                            break;
                        case 7:
                            img = Properties.Resources._7_of_clubs;
                            break;
                        case 8:
                            img = Properties.Resources._8_of_clubs;
                            break;
                        case 9:
                            img = Properties.Resources._9_of_clubs;
                            break;
                        case 10:
                            img = Properties.Resources._10_of_clubs;
                            break;
                        case 11:
                            img = Properties.Resources.jack_of_clubs;
                            break;
                        case 12:
                            img = Properties.Resources.queen_of_clubs;
                            break;
                        case 13:
                            img = Properties.Resources.king_of_clubs;
                            break;
                    }
                    break;
            }
            return img;
        }
        public PictureBox CardPicture()
        {

            PictureBox cardpicture = new PictureBox();
            cardpicture.BackColor = Color.Transparent;
            cardpicture.BackgroundImageLayout = ImageLayout.Stretch;
            cardpicture.Size = new Size(120, 160);
            cardpicture.TabStop = false;
            switch (Suit)
            {
                case SuitType.Joker:
                    if (SuitColor == Color.Black)
                        cardpicture.BackgroundImage = Properties.Resources.black_joker;
                    else
                        cardpicture.BackgroundImage = Properties.Resources.red_joker;
                    break;
                case SuitType.Spades:
                    switch (Value)
                    {
                        case 1:
                            cardpicture.BackgroundImage = Properties.Resources.ace_of_spades;
                            break;
                        case 2:
                            cardpicture.BackgroundImage = Properties.Resources._2_of_spades;
                            break;
                        case 3:
                            cardpicture.BackgroundImage = Properties.Resources._3_of_spades;
                            break;
                        case 4:
                            cardpicture.BackgroundImage = Properties.Resources._4_of_spades;
                            break;
                        case 5:
                            cardpicture.BackgroundImage = Properties.Resources._5_of_spades;
                            break;
                        case 6:
                            cardpicture.BackgroundImage = Properties.Resources._6_of_spades;
                            break;
                        case 7:
                            cardpicture.BackgroundImage = Properties.Resources._7_of_spades;
                            break;
                        case 8:
                            cardpicture.BackgroundImage = Properties.Resources._8_of_spades;
                            break;
                        case 9:
                            cardpicture.BackgroundImage = Properties.Resources._9_of_spades;
                            break;
                        case 10:
                            cardpicture.BackgroundImage = Properties.Resources._10_of_spades;
                            break;
                        case 11:
                            cardpicture.BackgroundImage = Properties.Resources.jack_of_spades;
                            break;
                        case 12:
                            cardpicture.BackgroundImage = Properties.Resources.queen_of_spades;
                            break;
                        case 13:
                            cardpicture.BackgroundImage = Properties.Resources.king_of_spades;
                            break;
                    }
                    break;
                case SuitType.Diamonds:
                    switch (Value)
                    {
                        case 1:
                            cardpicture.BackgroundImage = Properties.Resources.ace_of_diamonds;
                            break;
                        case 2:
                            cardpicture.BackgroundImage = Properties.Resources._2_of_diamonds;
                            break;
                        case 3:
                            cardpicture.BackgroundImage = Properties.Resources._3_of_diamonds;
                            break;
                        case 4:
                            cardpicture.BackgroundImage = Properties.Resources._4_of_diamonds;
                            break;
                        case 5:
                            cardpicture.BackgroundImage = Properties.Resources._5_of_diamonds;
                            break;
                        case 6:
                            cardpicture.BackgroundImage = Properties.Resources._6_of_diamonds;
                            break;
                        case 7:
                            cardpicture.BackgroundImage = Properties.Resources._7_of_diamonds;
                            break;
                        case 8:
                            cardpicture.BackgroundImage = Properties.Resources._8_of_diamonds;
                            break;
                        case 9:
                            cardpicture.BackgroundImage = Properties.Resources._9_of_diamonds;
                            break;
                        case 10:
                            cardpicture.BackgroundImage = Properties.Resources._10_of_diamonds;
                            break;
                        case 11:
                            cardpicture.BackgroundImage = Properties.Resources.jack_of_diamonds;
                            break;
                        case 12:
                            cardpicture.BackgroundImage = Properties.Resources.queen_of_diamonds;
                            break;
                        case 13:
                            cardpicture.BackgroundImage = Properties.Resources.king_of_diamonds;
                            break;
                    }
                    break;
                case SuitType.Hearts:
                    switch (Value)
                    {
                        case 1:
                            cardpicture.BackgroundImage = Properties.Resources.ace_of_hearts;
                            break;
                        case 2:
                            cardpicture.BackgroundImage = Properties.Resources._2_of_hearts;
                            break;
                        case 3:
                            cardpicture.BackgroundImage = Properties.Resources._3_of_hearts;
                            break;
                        case 4:
                            cardpicture.BackgroundImage = Properties.Resources._4_of_hearts;
                            break;
                        case 5:
                            cardpicture.BackgroundImage = Properties.Resources._5_of_hearts;
                            break;
                        case 6:
                            cardpicture.BackgroundImage = Properties.Resources._6_of_hearts;
                            break;
                        case 7:
                            cardpicture.BackgroundImage = Properties.Resources._7_of_hearts;
                            break;
                        case 8:
                            cardpicture.BackgroundImage = Properties.Resources._8_of_hearts;
                            break;
                        case 9:
                            cardpicture.BackgroundImage = Properties.Resources._9_of_hearts;
                            break;
                        case 10:
                            cardpicture.BackgroundImage = Properties.Resources._10_of_hearts;
                            break;
                        case 11:
                            cardpicture.BackgroundImage = Properties.Resources.jack_of_hearts;
                            break;
                        case 12:
                            cardpicture.BackgroundImage = Properties.Resources.queen_of_hearts;
                            break;
                        case 13:
                            cardpicture.BackgroundImage = Properties.Resources.king_of_hearts;
                            break;
                    }
                    break;
                case SuitType.Clubs:
                    switch (Value)
                    {
                        case 1:
                            cardpicture.BackgroundImage = Properties.Resources.ace_of_clubs;
                            break;
                        case 2:
                            cardpicture.BackgroundImage = Properties.Resources._2_of_clubs;
                            break;
                        case 3:
                            cardpicture.BackgroundImage = Properties.Resources._3_of_clubs;
                            break;
                        case 4:
                            cardpicture.BackgroundImage = Properties.Resources._4_of_clubs;
                            break;
                        case 5:
                            cardpicture.BackgroundImage = Properties.Resources._5_of_clubs;
                            break;
                        case 6:
                            cardpicture.BackgroundImage = Properties.Resources._6_of_clubs;
                            break;
                        case 7:
                            cardpicture.BackgroundImage = Properties.Resources._7_of_clubs;
                            break;
                        case 8:
                            cardpicture.BackgroundImage = Properties.Resources._8_of_clubs;
                            break;
                        case 9:
                            cardpicture.BackgroundImage = Properties.Resources._9_of_clubs;
                            break;
                        case 10:
                            cardpicture.BackgroundImage = Properties.Resources._10_of_clubs;
                            break;
                        case 11:
                            cardpicture.BackgroundImage = Properties.Resources.jack_of_clubs;
                            break;
                        case 12:
                            cardpicture.BackgroundImage = Properties.Resources.queen_of_clubs;
                            break;
                        case 13:
                            cardpicture.BackgroundImage = Properties.Resources.king_of_clubs;
                            break;
                    }
                    break;
            }
            return cardpicture;
        }
        public static Card Parse(string s)
        {
            return new Card(s);
        }
        public override string ToString()
        {
            if (Suit == SuitType.Joker) return Suit.ToString();

            string cardname = "";
            switch (Value)
            {
                case 11:
                    cardname += "Jack";
                    break;
                case 12:
                    cardname += "Queen";
                    break;
                case 13:
                    cardname += "King";
                    break;
                case 1:
                    cardname += "Ace";
                    break;
                default:
                    cardname += Value;
                    break;
            }
            cardname += " of " + Suit.ToString();
            return cardname;
        }
        public static SuitType ToSuitType(int n)
        {
            SuitType Suit;
            switch (n)
            {
                case 1:
                    Suit = SuitType.Clubs;
                    break;
                case 2:
                    Suit = SuitType.Spades;
                    break;
                case 3:
                    Suit = SuitType.Hearts;
                    break;
                case 4:
                    Suit = SuitType.Diamonds;
                    break;
                case 5:
                    Suit = SuitType.Joker;
                    break;
                default:
                    throw new InvalidCardType();
            }
            return Suit;
        }
        public class MutableCard : Card
        {
            private int _MValue;
            private SuitType _MSuit;
            public new int Value { get { return _MValue; } set { _MValue = value; } }
            public new SuitType Suit { get { return _MSuit; } set { _MSuit = value; } }
            public MutableCard(SuitType suit, Color color) : base(suit, color) { }
            public MutableCard(int value, SuitType suit) : base(value, suit) { }
            public MutableCard(SuitType suit, int value) : base(value, suit) { }
        }
    }


    public class RandomCard
    {
        Card lastcard;
        private Card DoRandom()
        {
            return new Card(Randomizer.Next(1, 14), Card.ToSuitType(Randomizer.Next(1, 4)));
        }
        public Card Next
        {
            get
            {
                Card newcard = DoRandom();
                while (newcard == lastcard)
                {
                    newcard = DoRandom();
                }
                lastcard = newcard;
                return newcard;
            }
            private set { }
        }
        public RandomCard() { }
    }
}
