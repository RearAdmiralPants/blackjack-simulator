using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator.Abstractions.Model
{
    public class BlackjackShoe : CardShoe
    {
        public BlackjackShoe(int totalDecks) : base(totalDecks)
        {
            this.Initialize();
            this.SetMaxPenetration();
        }

        public void Initialize()
        {
            for (var iterDecks = 0; iterDecks < this.TotalDecks; iterDecks++)
            {
                var deck = new BlackjackDeck();
                this.Cards.AddRange(deck.Cards);
            }
        }

        public void Reset()
        {
            this.Cards.Clear();
            this.Initialize();
        }
    }
}
