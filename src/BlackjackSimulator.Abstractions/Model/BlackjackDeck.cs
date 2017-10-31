using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator.Abstractions.Model
{
    public class BlackjackDeck : CardDeck
    {
        public BlackjackDeck()
        {
            this.Initialize();
        }

        public void Reset()
        {
            this.ResetDeck();
            this.Initialize();
        }

        private void Initialize()
        {
            foreach (var typedSuit in Enum.GetValues(typeof(Suit)).Cast<Suit>())
            {
                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.Two,
                    Value = 2,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.Three,
                    Value = 3,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.Four,
                    Value = 4,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.Five,
                    Value = 5,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.Six,
                    Value = 6,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.Seven,
                    Value = 7,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.Eight,
                    Value = 8,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.Nine,
                    Value = 9,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.Ten,
                    Value = 10,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.Jack,
                    Value = 10,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.Queen,
                    Value = 10,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.King,
                    Value = 10,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = CardName.Ace,
                    Value = 11,
                    Suit = typedSuit
                });
            }

            this.CompleteInitialAddingCards();
        }
    }
}
