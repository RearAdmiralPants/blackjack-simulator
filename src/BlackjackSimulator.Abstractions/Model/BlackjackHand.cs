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
        /// Gets the valid values of the current hand. If there are no aces in the hand, there will only
        /// be one value. The number of values in this collection is equal to the number of aces in the hand
        /// plus one.
        /// </summary>
        public HashSet<int> Values { get; private set; } = new HashSet<int>();

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

        public bool SingleValue()
        {
            return (this.Values.Count == 1);
        }

        /// <summary>
        /// Calculates the <see cref="Values"/> property of the current <see cref="BlackjackHand"/>.
        /// </summary>
        private void CalculateValues()
        {
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
        }
    }
}
