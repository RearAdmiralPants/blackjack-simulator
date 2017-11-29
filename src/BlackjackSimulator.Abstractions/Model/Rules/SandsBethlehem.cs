namespace BlackjackSimulator.Abstractions.Model.Rules
{
    using System.Collections.Generic;

    /// <inheritdoc />
    public class SandsBethlehem : IBlackjackRules
    {
        public int AcesCanBeSplitInARow
        {
            get
            {
                return 1;
            }
        }

        public decimal BlackjackPays
        {
            get
            {
                return 1.5M;
            }
        }

        public bool ContinuousShuffle
        {
            get
            {
                return false;
            }
        }

        public bool DealerHitsSoft17
        {
            get
            {
                return false;
            }
        }

        public List<int> DoubleableHands
        {
            get
            {
                return new List<int>();
            }
        }

        public bool DoubleAfterSplitAllowed
        {
            get
            {
                return true;
            }
        }

        public int NumberOfDecks
        {
            get
            {
                return 8;
            }
        }

        public bool OneCardAfterSplittingAces
        {
            get
            {
                return true;
            }
        }

        public decimal SurrenderValue
        {
            get
            {
                return 0.5M;
            }
        }

        public bool CanDouble(BlackjackHand currentHand)
        {
            return true;
        }

        public bool CanSplit(BlackjackHand currentHand)
        {
            if (currentHand.SplitParent == null)
            {
                return true;
            }

            return !(currentHand.SplitParent.Cards[0].Name == CardName.Ace && currentHand.SplitParent.Cards[1].Name == CardName.Ace);
        }
    }
}
