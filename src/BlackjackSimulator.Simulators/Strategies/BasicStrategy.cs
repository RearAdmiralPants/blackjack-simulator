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
        ///  Gets the current player's hand
        /// </summary>
        public BlackjackHand PlayerHand { get; private set; }

        /// <summary>
        /// Gets the current dealer's hand
        /// </summary>
        public BlackjackHand DealerHand { get; private set; }

        /// <summary>
        /// Gets the next action that the player will take using this strategy.
        /// </summary>
        /// <returns>The next <see cref="BlackjackAction"/> the player should perform using this strategy.</returns>
        public BlackjackAction GetNextAction()
        {
            throw new NotImplementedException();
        }

        public void SetCurrentHand(BlackjackHand playerHand, BlackjackHand dealerHand)
        {
            this.PlayerHand = playerHand;
            this.DealerHand = dealerHand;
        }

        public void SetKnownCard(PlayingCard knownCard)
        {
            // Basic strategy doesn't care about history
            return;
        }

    }

}
