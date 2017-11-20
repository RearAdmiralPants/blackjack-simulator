using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator.Simulators.Rules
{
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

        public int NumberOfShoes
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

        public bool SurrenderAllowed
        {
            get
            {
                return true;
            }
        }
    }
}
