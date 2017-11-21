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
        private int consideredPlayerValue;
        private int consideredDealerValue;

        /// <summary>
        /// Gets the current player's hand
        /// </summary>
        public BlackjackHand PlayerHand { get; set; }

        /// <summary>
        /// Gets the current dealer's hand
        /// </summary>
        public BlackjackHand DealerHand { get; set; }

        public IBlackjackRules Rules { get; set; }

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
        //// TODO: Verify these actions with basic strategy cards.
        public BlackjackAction GetNextAction()
        {
            // First, special cases

            // Always split aces (?)
            if (this.PlayerHand.IsSplittable && this.PlayerHand.Cards[0].Name == CardName.Ace)
            {
                return BlackjackAction.Split;
            }

            // Always stand on 21
            if (this.consideredPlayerValue == 21)
            {
                return BlackjackAction.Stand;
            }

            // Next, more general cases
            // Always hit with 11 or less
            if (this.consideredPlayerValue <= 11)
            {
                return BlackjackAction.Hit;
            }


            throw new NotImplementedException("Not implemented yet.");
        }

        private void CalculateConsideredValues()
        {
            if (this.DealerHand.Values.Count > 1)
            {
                if (this.Rules.DealerHitsSoft17)
                {
                    if (this.DealerHand.Values.Contains(17))
                    {
                        this.consideredDealerValue = 17;
                    }
                }
            }
        }
    }

}
