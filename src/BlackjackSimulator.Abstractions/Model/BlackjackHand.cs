namespace BlackjackSimulator.Abstractions.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BlackjackHand
    {
        /// <summary>
        /// Represents the cards in the hand.
        /// </summary>
        //// TODO: Can this be unordered? E.g. HashSet?
        public EventList<PlayingCard> Cards { get; private set; } = new EventList<PlayingCard>();

        /// <summary>
        /// Gets or sets the visible card if this is the dealer's hand.
        /// </summary>
        public PlayingCard DealerVisibleCard { get; set; }

        /// <summary>
        /// Gets or sets the value of the hand.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value of the hand is soft (contains one or more aces such that the hand could
        /// be considered to have a value of n - 10 where n is the <see cref="Value"/> of the hand).
        /// </summary>
        public bool IsSoft { get; set; } = false;

        /// <summary>
        /// Gets or sets the bet of this hand. Only valid for player hands; dealers do not bet.
        /// </summary>
        public decimal Bet { get; set; }

        public BlackjackHand()
        {
            this.Cards.ItemAdded += Cards_ItemAdded;
        }

        public bool IsSplittable
        {
            get
            {
                return this.Cards.Count == 2 && this.Cards[0].Name == this.Cards[1].Name;
            }
        }

        private void Cards_ItemAdded(object sender, EventArgs e)
        {
            this.CalculateValues();
        }

        /// <summary>
        /// Calculates the <see cref="Values"/> property of the current <see cref="BlackjackHand"/>.
        /// </summary>
        private void CalculateValues()
        {
            var lowestValue = 0;
            var highestValue = 0;
            var aces = 0;

            foreach (var card in this.Cards)
            {
                if (card.Name != CardName.Ace)
                {
                    lowestValue += card.Value;
                    highestValue += card.Value;
                }
                else
                {
                    lowestValue++;
                    highestValue += 11;
                    aces++;
                }
            }

            if (aces == 0)
            {
                this.Value = highestValue;
                this.IsSoft = false;
                return;
            }

            if (highestValue <= 21)
            {
                this.Value = highestValue;
                this.IsSoft = true;
                return;
            }

            while (aces > 0)
            {
                highestValue = highestValue - 10;
                aces--;

                if (highestValue <= 21)
                {
                    this.IsSoft = aces > 0;
                    this.Value = highestValue;
                    break;
                }
            }
            
            /*
            this.Values.Clear();

            var aces = 0;
            var maxValue = 0;

            foreach (var card in this.Cards)
            {
                if (card.Name == CardName.Ace) { aces++; }
                maxValue += card.Value;
            }

            this.Values.Add(maxValue);

            while (aces > 0)
            {
                var newValue = 0;
                var foundAce = false;
                foreach (var card in this.Cards)
                {
                    if (card.Name == CardName.Ace && !foundAce)
                    {
                        foundAce = true;
                        newValue++;
                    }
                    else
                    {
                        newValue += card.Value;
                    }
                }

                this.Values.Add(newValue);
                aces--;
            }
            */
        }
    }
}
