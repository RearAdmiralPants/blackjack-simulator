using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator.Abstractions
{
    public interface IBlackjackRules
    {
        /// <summary>
        /// Gets a value indicating whether the dealer has to hit a soft 17 (Ace-6).
        /// </summary>
        bool DealerHitsSoft17 { get; }

        /// <summary>
        /// Gets a value indicating how much of the player's bet is retained when he surrenders.
        /// If the value is 0, no surrender is permitted.
        /// </summary>
        decimal SurrenderValue { get; }

        /// <summary>
        /// Gets a value indicating how much a Blackjack pays the player vs. a dealer non-Blackjack.
        /// </summary>
        decimal BlackjackPays { get; }

        /// <summary>
        /// Gets a value indicating whether a continuous shuffle mechanism is used (equivalent to very
        /// low penetration).
        /// </summary>
        bool ContinuousShuffle { get; }

        /// <summary>
        /// Gets a value indicating whether the player may double down after a split.
        /// </summary>
        bool DoubleAfterSplitAllowed { get; }

        /// <summary>
        /// Gets a list of values of hands for which doubling down is permitted. If the list is empty,
        /// the player may double on any hand.
        /// </summary>
        List<int> DoubleableHands { get; }

        /// <summary>
        /// Gets a value indicating what happens when the player splits aces. if true, one card is issued
        /// to each ace and the turn ends. If false, one card is issued to each ace and the player may continue
        /// making decisions on those separate hands according to the rules.
        /// </summary>
        bool OneCardAfterSplittingAces { get; }

        /// <summary>
        /// Gets a value indicating how many times the player may split aces. If 0, it is unlimited. This value
        /// is only applicable if <see cref="OneCardAfterSplittingAces"/> is false.
        /// </summary>
        int AcesCanBeSplitInARow { get; }

        /// <summary>
        /// Gets a value indicating how many decks are in a shoe.
        /// </summary>
        int NumberOfDecks { get; }
    }
}
