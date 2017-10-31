namespace BlackjackSimulator.Abstractions.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a single deck of cards. For shuffling and dealing functionality, please see <see cref="CardShoe"/>. 
    /// To shuffle/deal/work with a single deck of cards, simply create a <see cref="CardShoe"/> of a single deck.
    /// </summary>
    public abstract class CardDeck
    {
        private int totalCards = 0;

        private List<PlayingCard> Cards = new List<PlayingCard>();

        protected void ResetDeck()
        {
            this.totalCards = 0;
            this.Cards.Clear();
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

        public void CompleteInitialAddingCards()
        {
            this.totalCards = this.Cards.Count;
        }

    }
}
