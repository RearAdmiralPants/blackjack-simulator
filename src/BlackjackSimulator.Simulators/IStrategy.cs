namespace BlackjackSimulator.Simulators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BlackjackSimulator.Abstractions.Model;
    using BlackjackSimulator.Abstractions;

    public interface IStrategy
    {
        //// TODO: Continue consideration of this implementation

        /// <summary>
        /// Get the cards that the player knows he's seen and have been played.
        /// </summary>
        List<PlayingCard> KnownCards { get; }

        /// <summary>
        /// Gets or sets the current player's hand.
        /// </summary>
        Abstractions.Model.BlackjackHand PlayerHand { get; set; }

        /// <summary>
        /// Gets or sets the current dealer's hand.
        /// </summary>
        Abstractions.Model.BlackjackHand DealerHand { get; set; }

        /// <summary>
        /// Gets or sets the current rule set.
        /// </summary>
        IBlackjackRules Rules { get; set; }

        /// <summary>
        /// Gets the action that the player should take given the streategy.
        /// </summary>
        /// <returns></returns>
        BlackjackAction GetNextAction();
    }
}
