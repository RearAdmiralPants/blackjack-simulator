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

        BlackjackAction GetNextAction();


    }
}
