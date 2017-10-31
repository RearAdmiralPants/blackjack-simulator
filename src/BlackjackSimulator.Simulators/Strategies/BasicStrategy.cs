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
        public BlackjackAction GetNextAction()
        {
            throw new NotImplementedException();
        }

        public void SetCurrentHand(Simulators.BlackjackHand playerHand, Simulators.BlackjackHand dealerHand)
        {
            throw new NotImplementedException();
        }

        public void SetKnownCard(PlayingCard knownCard)
        {
            throw new NotImplementedException();
        }
    }
}
