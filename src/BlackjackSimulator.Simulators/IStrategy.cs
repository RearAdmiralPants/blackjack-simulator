namespace BlackjackSimulator.Simulators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BlackjackSimulator.Abstractions.Model;

    public interface IStrategy
    {
        //// TODO: Continue consideration of this implementation

        /// <summary>
        /// Sets a card that the player is aware has already been played.
        /// </summary>
        /// <param name="knownCard"></param>
        void SetKnownCard(PlayingCard knownCard);

        /// <summary>
        /// Sets the current hands dealt to the player and the dealer.
        /// </summary>
        /// <param name="playerHand"></param>
        /// <param name="dealerHand"></param>
        void SetCurrentHand(Abstractions.Model.BlackjackHand playerHand, Abstractions.Model.BlackjackHand dealerHand);

        /// <summary>
        /// Gets the action that the player should take given the streategy.
        /// </summary>
        /// <returns></returns>
        BlackjackAction GetNextAction();


    }
}
