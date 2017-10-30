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

        public HashSet<int> Values { get; private set; } = new HashSet<int>();

        public BlackjackHand()
        {
            this.Cards.ItemAdded += Cards_ItemAdded;
        }

        private void Cards_ItemAdded(object sender, EventArgs e)
        {
            this.CalculateValues();
        }

        public bool SingleValue()
        {
            return (this.Values.Count == 1);
        }

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
