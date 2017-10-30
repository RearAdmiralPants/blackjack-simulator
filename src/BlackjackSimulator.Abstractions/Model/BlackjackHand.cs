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
            throw new NotImplementedException();
        }

        public bool SingleValue()
        {
            return (this.Values.Count == 1);
        }
    }
}
