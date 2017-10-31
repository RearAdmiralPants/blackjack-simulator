namespace BlackjackSimulator.Test
{
    using System;
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
    using BlackjackSimulator.Abstractions;
    using BlackjackSimulator.Abstractions.Model;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a series of unit tests for Blackjack Hands.
    /// </summary>
    [TestClass]
    public class BlackjackHandTest
    {
        [TestMethod]
        public void BlackjackHand_CalculatedProperly()
        {
            var firstCard = new PlayingCard
            {
                Suit = Suit.Clubs,
                Name = CardName.Eight,
                Value = 8
            };

            var secondCard = new PlayingCard
            {
                Suit = Suit.Diamonds,
                Name = CardName.Ace,
                Value = 11
            };

            var hand = new BlackjackHand();

            hand.Cards.Add(firstCard);
            hand.Cards.Add(secondCard);

            var expectedValues = new HashSet<int>();
            expectedValues.Add(19);
            expectedValues.Add(9);

            foreach (var value in hand.Values)
            {
                expectedValues.Remove(value);
            }

            Assert.AreEqual(expectedValues.Count, 0);
        }
    }
}
