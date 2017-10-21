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
            var allCards = this.GetAllRemainingCards();
            System.Diagnostics.Debug.WriteLine("Cards in deck (unshuffled): " + allCards.Count);
            foreach (var card in allCards)
            {
                System.Diagnostics.Debug.WriteLine("Card: " + card.Name + " of " + card.Suit.ToString());
            }

            this.ResetDeck();

            this.Initialize();
            this.Shuffle();
            System.Diagnostics.Debug.WriteLine("Cards in deck (unshuffled): " + allCards.Count);
            for (var iterTest = 0; iterTest < 14; iterTest++) {
                try
                {
                    var fiveCards = this.GetCards(5);
                    System.Diagnostics.Debug.WriteLine("FIVE CARDS:");
                    foreach (var card in fiveCards)
                    {
                        System.Diagnostics.Debug.WriteLine("Card: " + card.Name + " of " + card.Suit.ToString());
                    }
                }
                catch (Exceptions.NotEnoughCardsRemainingException)
                {
                    System.Diagnostics.Debug.WriteLine("Not enough cards remain in deck to retrieve 5 cards (" + this.CardsRemaining + " remain)");
                    var remainder = this.GetAllRemainingCards();
                    foreach (var card in remainder)
                    {
                        System.Diagnostics.Debug.WriteLine("Remaining: " + card.Name + " of " + card.Suit.ToString());
                    }
                    iterTest = 20;
                }
            }
        }


        private void Initialize()
        {
            foreach (var typedSuit in Enum.GetValues(typeof(Suit)).Cast<Suit>())
            {
                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "Two",
                    Value = 2,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "Three",
                    Value = 3,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "Four",
                    Value = 4,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "Five",
                    Value = 5,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "Six",
                    Value = 6,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "Seven",
                    Value = 7,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "Eight",
                    Value = 8,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "Nine",
                    Value = 9,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "Ten",
                    Value = 10,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "Jack",
                    Value = 10,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "Queen",
                    Value = 10,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "King",
                    Value = 10,
                    Suit = typedSuit
                });

                this.AddCardToEndOfDeck(new PlayingCard
                {
                    Name = "Ace",
                    Value = 11,
                    Suit = typedSuit
                });

                this.SetMaxPenetration();
            }
        }
    }
}
