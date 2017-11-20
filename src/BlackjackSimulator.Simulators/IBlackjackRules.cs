using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator.Simulators
{
    public interface IBlackjackRules
    {
        bool DealerHitsSoft17 { get; }
        bool SurrenderAllowed { get; }
        decimal BlackjackPays { get; }
        bool ContinuousShuffle { get; }
        bool DoubleAfterSplitAllowed { get; }
        List<int> DoubleableHands { get; }
        bool OneCardAfterSplittingAces { get; }
        int AcesCanBeSplitInARow { get; }
        int NumberOfShoes { get; }
    }
}
