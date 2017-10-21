namespace BlackjackSimulator.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class CardDeck
    {
        private int penetration = 0;
        private int cardToDeal = 0;             // NOTE: This index will generally stay at 0, as cards are removed from the beginning of the deck
        private int cardsDealt = 0;
        private int totalCards = 0;

        private List<PlayingCard> Cards = new List<PlayingCard>();

        public void ResetDeck()
        {
            this.penetration = 0;
            this.cardToDeal = 0;
            this.cardsDealt = 0;
            this.totalCards = 0;
            this.Cards.Clear();
        }

        public void Shuffle()
        {
            lock (this.Cards)
            {
                var shuffledDeck = new List<PlayingCard>();
                var randomGen = new Random();
                while (this.Cards.Any())
                {
                    var randomIndex = randomGen.Next(0, this.Cards.Count - 1);
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
            if (this.Penetration - cardsDealt - cardsToSkip < cardsToPeek) {
                throw new Exceptions.NotEnoughCardsRemainingException();
            }
            var retrievedCards = this.Cards.GetRange(this.cardToDeal + cardsToSkip, cardsToPeek);

            return retrievedCards;
        }

        public void AddCardToEndOfDeck(PlayingCard card)
        {
            this.Cards.Add(card);
        }

        public void RemoveCards(List<PlayingCard> cardsToRemove)
        {
            cardsToRemove.ForEach(card => this.Cards.Remove(card));
        }


        public void RemoveCard(PlayingCard cardToRemove)
        {
            this.Cards.Remove(cardToRemove);
        }

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

        public int CardCount
        {
            get
            {
                return this.totalCards;
            }
        }

        public int CardsRemaining
        {
            get
            {
                return this.Cards.Count;
            }
        }

        public void SetMaxPenetration()
        {
            this.Penetration = this.Cards.Count;
        }

        public void CompleteInitialAddingCards()
        {
            this.totalCards = this.Cards.Count;
        }

        public List<PlayingCard> GetAllRemainingCards()
        {
            return this.GetCards(this.Penetration - this.cardsDealt - this.cardToDeal);
        }
    }
}
