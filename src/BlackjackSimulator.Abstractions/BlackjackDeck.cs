using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator.Abstractions
{
    public class BlackjackDeck : CardDeck
    {
        public BlackjackDeck()
        {
            this.Initialize();
            System.Diagnostics.Debug.WriteLine("Cards in deck (unshuffled): " + this.Cards.Count);
            foreach (var card in this.Cards)
            {
                System.Diagnostics.Debug.WriteLine("Card: " + card.Name + " of " + card.Suit.ToString());
            }
        }

        private void Initialize()
        {
            foreach (var typedSuit in Enum.GetValues(typeof(Suit)).Cast<Suit>())
            {
                this.Cards.Add(new PlayingCard
                {
                    Name = "Two",
                    Value = 2,
                    Suit = typedSuit
                });

                this.Cards.Add(new PlayingCard
                {
                    Name = "Three",
                    Value = 3,
                    Suit = typedSuit
                });

                this.Cards.Add(new PlayingCard
                {
                    Name = "Four",
                    Value = 4,
                    Suit = typedSuit
                });

                this.Cards.Add(new PlayingCard
                {
                    Name = "Five",
                    Value = 5,
                    Suit = typedSuit
                });

                this.Cards.Add(new PlayingCard
                {
                    Name = "Six",
                    Value = 6,
                    Suit = typedSuit
                });

                this.Cards.Add(new PlayingCard
                {
                    Name = "Seven",
                    Value = 7,
                    Suit = typedSuit
                });

                this.Cards.Add(new PlayingCard
                {
                    Name = "Eight",
                    Value = 8,
                    Suit = typedSuit
                });

                this.Cards.Add(new PlayingCard
                {
                    Name = "Nine",
                    Value = 9,
                    Suit = typedSuit
                });

                this.Cards.Add(new PlayingCard
                {
                    Name = "Ten",
                    Value = 10,
                    Suit = typedSuit
                });

                this.Cards.Add(new PlayingCard
                {
                    Name = "Jack",
                    Value = 10,
                    Suit = typedSuit
                });

                this.Cards.Add(new PlayingCard
                {
                    Name = "Queen",
                    Value = 10,
                    Suit = typedSuit
                });

                this.Cards.Add(new PlayingCard
                {
                    Name = "King",
                    Value = 10,
                    Suit = typedSuit
                });

                this.Cards.Add(new PlayingCard
                {
                    Name = "Ace",
                    Value = 11,
                    Suit = typedSuit
                });
            }
        }
    }
}
