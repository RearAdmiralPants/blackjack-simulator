namespace BlackjackSimulator.Abstractions.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represent's the player's entire turn, which may consist of multiple hands.
    /// </summary>
    public class PlayerTurn
    {
        /// <summary>
        /// Gets the player's current hands. The player may have multiple hands due to split(s).
        /// </summary>
        public List<BlackjackHand> PlayerHands { get; private set; } = new List<BlackjackHand>();
    }
}
