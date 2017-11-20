namespace BlackjackSimulator.Simulators.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BlackjackSimulator.Abstractions.Model;

    /// <summary>
    /// An <see cref="IStrategy"/> representing Blackjack Basic Strategy 
    /// </summary>
    public class BasicStrategy : IStrategy
    {
        /// <summary>
        /// Gets the current player's hand
        /// </summary>
        public BlackjackHand PlayerHand { get; set; }

        /// <summary>
        /// Gets the current dealer's hand
        /// </summary>
        public BlackjackHand DealerHand { get; set; }

        public BlackjackRules Rules { get; set; }

        /// <summary>
        /// Gets the list of known cards. Basic strategy has no memory.
        /// </summary>
        public List<PlayingCard> KnownCards
        {
            get
            {
                return new List<PlayingCard>();
            }
        }

        /// <summary>
        /// Gets the next action that the player will take using this strategy.
        /// </summary>
        /// <returns>The next <see cref="BlackjackAction"/> the player should perform using this strategy.</returns>
        public BlackjackAction GetNextAction()
        {
            var consideredDealerValue = this.DealerHand.Values.FirstOrDefault();
            var consideredPlayerValue = this.PlayerHand.Values.FirstOrDefault();

            if (this.DealerHand.Values.Count > 1)
            {
               
            }

            throw new NotImplementedException("Not implemented yet.");
        }
    }

}
