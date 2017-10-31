using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator.Abstractions.Model
{
    /// <summary>
    /// Represents a "shoe" of cards, consisting of one or more decks.
    /// </summary>
    public abstract class CardShoe
    {
        private int penetration = 0;
        private int cardToDeal = 0;             // NOTE: This index will generally stay at 0, as cards are removed from the beginning of the deck
        private int cardsDealt = 0;
        private Random randomGen = new Random();

        public int TotalDecks { get; private set; }

        protected List<PlayingCard> Cards = new List<PlayingCard>();

        public CardShoe(int totalDecks)
        {
            this.TotalDecks = totalDecks;
        }

        /// <summary>
        /// Gets or sets a value indicating how deeply in the shoe the shoe will end. The value should be the index of the card in the shoe
        /// at which the shoe will end (any cards of a higher index will not be used and thus ignored).
        /// </summary>
        public int Penetration
        {
            get
            {
                return this.penetration;
            }
            set
            {
                if (value > this.Cards.Count)
                {
                    throw new InvalidOperationException("Can not set penetration to a value higher than the number of cards in the deck.");
                }
                this.penetration = value;
            }
        }

        public void SetMaxPenetration()
        {
            this.Penetration = this.Cards.Count;
        }

        public void Shuffle()
        {
            lock (this.Cards)
            {
                var shuffledDeck = new List<PlayingCard>();

                while (this.Cards.Any())
                {
                    var randomIndex = this.randomGen.Next(0, this.Cards.Count - 1);
                    shuffledDeck.Add(this.Cards[randomIndex]);
                    this.Cards.RemoveAt(randomIndex);
                }

                this.Cards = shuffledDeck;
            }
        }

        public List<PlayingCard> GetCards(int cardsToRetrieve)
        {
            if (this.Penetration - cardsDealt < cardsToRetrieve)
            {
                throw new Exceptions.NotEnoughCardsRemainingException();
            }
            var retrievedCards = this.Cards.GetRange(this.cardToDeal, cardsToRetrieve);
            this.Cards.RemoveRange(this.cardToDeal, cardsToRetrieve);
            this.cardsDealt += cardsToRetrieve;

            return retrievedCards;
        }

        public List<PlayingCard> PeekCards(int cardsToSkip, int cardsToPeek)
        {
            if (this.Penetration - cardsDealt - cardsToSkip < cardsToPeek)
            {
                throw new Exceptions.NotEnoughCardsRemainingException();
            }
            var retrievedCards = this.Cards.GetRange(this.cardToDeal + cardsToSkip, cardsToPeek);

            return retrievedCards;
        }

        public List<PlayingCard> GetAllRemainingCards()
        {
            return this.GetCards(this.Penetration - this.cardsDealt - this.cardToDeal);
        }
    }
}
