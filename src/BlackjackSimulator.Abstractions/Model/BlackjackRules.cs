namespace BlackjackSimulator.Abstractions.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BlackjackRules
    {
        public bool DealerHitsSoft17 { get; set; } = true;

        public bool SurrenderAllowed { get; set; } = true;

        public bool DoubleAfterSplit { get; set; } = true;

        public bool OneCardSplitAces { get; set; } = true;

        public double BlackjackPays { get; set; } = 1.5;            // 3:2
    }
}
