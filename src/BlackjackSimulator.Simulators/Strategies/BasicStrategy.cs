namespace BlackjackSimulator.Simulators.Strategies
{
    using System;
    using System.Collections.Generic;
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

        public IBlackjackRules Rules { get; set; }

        /// <summary>
        /// Stores the assocation between the dealer's face-up card (11 is ace), the player's hand, and the action that
        /// should be performed.
        /// </summary>
        private Dictionary<int, Dictionary<BlackjackHand, BlackjackAction>> strategyData = new Dictionary<int, Dictionary<BlackjackHand, BlackjackAction>>();

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
            if (this.Rules.NumberOfDecks >= 4)
            {
                return this.GetNextAction_FourOrMoreDecks();
            }

            throw new NotImplementedException("Not implemented yet.");
        }

        private BlackjackAction GetNextAction_FourOrMoreDecks()
        {
            // First, special cases

            // Always split aces (?)
            if (this.PlayerHand.IsSplittable && this.PlayerHand.Cards[0].Name == CardName.Ace)
            {
                return BlackjackAction.Split;
            }

            // Always stand on 21
            if (this.PlayerHand.Value == 21)
            {
                return BlackjackAction.Stand;
            }

            // Next, more general cases
            // Always hit with 11 or less
            if (this.PlayerHand.Value <= 11 && !this.PlayerHand.IsSoft)
            {
                return BlackjackAction.Hit;
            }



            /*
            switch (this.Rules.DealerHitsSoft17)
            {
                case true:
                    switch (this.PlayerHand.IsSoft)
                    {
                        case true:
                            switch (this.PlayerHand.Value)
                            {
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                    switch (this.DealerHand.DealerVisibleCard.Value)
                                    {
                                        case 2:
                                        case 3:
                                        case 4:
                                            return BlackjackAction.Hit;
                                            break;
                                        case 5:
                                        case 6:
                                            return BlackjackAction.DoubleDown;
                                            break;
                                        case 7:
                                        case 8:
                                        case 9:
                                        case 10:
                                        case 11:
                                            break;
                                    }
                                    break;
                            }
                            break;

                        default:        // False
                            break;
                    }

                    break;
                default:        // False
                    break;
            }
            switch (this.PlayerHand.IsSoft)
            {
                case true:
                    switch (this.PlayerHand.Value)
                    {
                        case 2:
                            break;
                    }
                    break;

                default:        // False
                    break;
            }
            */

            throw new NotImplementedException("Not implemented yet.");
        }
    }

}
