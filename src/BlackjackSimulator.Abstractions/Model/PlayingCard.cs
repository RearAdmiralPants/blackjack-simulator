namespace BlackjackSimulator.Abstractions.Model
{
    using System;

    public class PlayingCard : IEquatable<PlayingCard>
    {
        /// <summary>
        /// Gets or sets the name of the card.
        /// </summary>
        public CardName Name { get; set; }

        /// <summary>
        /// Gets or sets the suit of the card.
        /// </summary>
        public Suit Suit { get; set; }

        /// <summary>
        /// Gets or sets the value of the card.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// TODO: May need to be deprecated
        /// </summary>
        public Func<object, int> DeterminedValue { get; set; }

        public override int GetHashCode()
        {
            var toHash = this.Name + this.Suit.ToString();
            return toHash.GetHashCode();
        }

        public bool Equals(PlayingCard comp)
        {
            if (this.Name == comp.Name && this.Suit == comp.Suit)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            PlayingCard card = obj as PlayingCard;
            if (card != null)
            {
                return this.Equals(card);
            }
            return false;
        }

        public override string ToString()
        {
            return this.Name + " of " + this.Suit.ToString();
        }
    }
}
