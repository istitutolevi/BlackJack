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
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
namespace BlackJack
{

    /// <summary>
    /// Definition Of Card Deck Class
    /// @Stores A Stack Of (54 or 52 without jokers) Cards
    /// </summary>
    public class CardDeck : IEnumerable
    {
        private class CardDeckError : ApplicationException
        {
            public CardDeckError() : base() { }
            public CardDeckError(string msg) : base(msg) { }
        }
        private Card[] cstack;
        private int top = 0;
        private int limit = 54;// maximum number of cards allowed(One Deck)

        public enum CardDeckType { WithJokers, WithoutJokers };
        public CardDeckType DeckType { get; set; }
        public Card RedJoker
        {
            get
            {
                return new Card.MutableCard(Card.SuitType.Joker, Color.Red);
            }
            private set { }
        }
        public Card BlackJoker
        {
            get
            {
                return new Card.MutableCard(Card.SuitType.Joker, Color.Black);
            }
            private set { }
        }
        public int Size
        {
            get { return top; }
            private set { }
        }
        public CardDeck()
        {
            cstack = new Card[limit];
            DeckType = CardDeckType.WithJokers;
            FillDeck();
        }
        public CardDeck(CardDeckType newDeckType)
        {
            cstack = new Card[limit];
            DeckType = newDeckType;
            FillDeck();
        }

        private void FillDeck()
        {
            switch (DeckType)
            {
                case CardDeckType.WithJokers:
                    for (int s = 1; s < 5; s++)//do 1-4
                    {
                        for (int v = 1; v < 14; v++)//do 1-13
                        {
                            Add(new Card(Card.ToSuitType(s), v));
                        }
                    }
                    Add(RedJoker);
                    Add(BlackJoker);
                    break;
                case CardDeckType.WithoutJokers:
                    for (int s = 1; s < 5; s++)//do 1-4
                    {
                        for (int v = 1; v < 14; v++)//do 1-13
                        {
                            Add(new Card(Card.ToSuitType(s), v));
                        }
                    }
                    break;
                default:
                    throw new CardDeckError("Invalid Deck Type");
            }
        }

        public Card TopCard()//@Peeks the top card on the card deck
        {
            if (Size > 0) return cstack[top - 1];
            return null;
        }
        public Card BottomCard()//@Peek the last card on the card deck
        {
            if (Size > 0) return cstack[0];
            return null;
        }
        public Card Peek(int position)//@Peeks the card at a position on the card deck
        {
            position = position < 0 ? -position : position;
            if (!IsEmpty() && position < top) return cstack[Size - position];
            return null;
        }
        public Card Pull(int position)//@Pull (OUT) the card at a position on the card deck
        {
            position = position < 0 ? -position : position;
            if (!IsEmpty() && position < top)
            {
                Card requestedCard = Peek(position);
                for (int i = Size - position; i < Size; i++)
                {
                    cstack[i] = cstack[i + 1];
                }
                --top;
                return requestedCard;
            }
            else
            {
                throw new CardDeckError("Attempting To Access A Non Existing Location On Card Deck!");
            }
        }
        public Card Pop()//@Pop (OUT) the top card of the card deck
        {
            if (Size > 0)
            {
                return cstack[top-- - 1];
            }
            else
            {
                throw new CardDeckError("Attempting To Access Empty Card Deck!");
            }
        }
        public void Add(Card newcard)//@Adds a card to the card deck
        {
            // @allow extra joker for joker decks
            if (CardExist(newcard) || ((newcard == BlackJoker || newcard == RedJoker) && DeckType != CardDeckType.WithJokers))
            {
                throw new CardDeckError("Card Already Exist In Deck Or Doesn't Match To Deck Type!");
            }
            else
            {
                if (!IsFull()) cstack[++top - 1] = newcard;
                else throw new CardDeckError("CardDeck Limit Reached!");
            }
        }
        public void Add(object newcard)//@Converts object to card if possible and adds it to the card deck
        {
            Card ncard = newcard as Card;
            Add(ncard);
        }
        public void Place(Card newcard, int position)//@Converts object to card if possible and adds it to the card deck
        {
            position = position < 0 ? -position : position;
            if (!IsEmpty() && position < top)
            {
                Card requestedCard = Peek(position);
                for (int i = Size - position; i < Size; i++)
                {
                    cstack[i] = cstack[i + 1];
                }
                ++top;
            }
            else
            {
                throw new CardDeckError("Attempting To Access A Non Existing Location On Card Deck!");
            }
        }
        public bool CardExist(Card newcard)//@Checks if a card exists in the card deck
        {
            foreach (Card card in this)
            {
                if (card == newcard) return true;
            }
            return false;
        }
        public bool IsFull()//@Checks if the card deck is full
        {
            if (Size == limit) return true;
            else return false;
        }
        public bool IsEmpty()//@Checks if the card deck is empty
        {
            if (Size == 0) return true;
            else return false;
        }
        public void Invert()//@Inverts the card deck order
        {
            Card safe = null;
            int handle = 0;
            for (int i = Size; i >= Size / 2; i--)
            {
                safe = cstack[i - 1];
                cstack[i - 1] = cstack[handle];
                cstack[handle] = safe;
                ++handle;
            }
        }
        public void Shuffle(int loop = 1)//@Shuffles the card deck
        {
            loop = loop > 10 ? 10 : loop;
            Card safe = null;
            int nint;
            for (int l = 0; l < loop; l++)
            {
                for (int i = 0; i < Size; i++)
                {
                    nint = Randomizer.Next(0, Size - 1);
                    while (nint == i) nint = Randomizer.Next(0, Size - 1);
                    safe = cstack[i];
                    cstack[i] = cstack[nint];
                    cstack[nint] = safe;
                }
            }
        }
        public void ExtremeShuffle()//@Estremely shuffles the card deck
        {
            for (int i = 0; i < 7; i++)
            {
                Shuffle(3);
                Invert();
            }
        }
        public IEnumerator GetEnumerator()//@GetEnumerator for (foreach) operation  
        {
            for (int i = Size; i > 0; i--)
            {
                yield return cstack[i - 1];
            }
        }


        int bimgcollected = 0;
        public PictureBox BackPicture()
        {
            PictureBox cardpicture = new PictureBox();
            cardpicture.BackgroundImage = Properties.Resources.back4;
            cardpicture.BackgroundImageLayout = ImageLayout.Stretch;
            cardpicture.Location = new Point(75, 238);
            cardpicture.Name = "backimage_"+bimgcollected++;
            cardpicture.Size = new Size(120, 160);
            cardpicture.TabStop = false;
            return cardpicture;
        }
    }
}
