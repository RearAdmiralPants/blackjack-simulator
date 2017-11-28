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

            Assert.AreEqual(hand.Value, 19);
            Assert.IsTrue(hand.IsSoft);
        }

        [TestMethod]
        public void BlackjackHands_CorrectProperties()
        {
            var first = new PlayingCard
            {
                Suit = Suit.Clubs,
                Name = CardName.Five,
                Value = 5
            };

            var second = new PlayingCard
            {
                Suit = Suit.Clubs,
                Name = CardName.Ace,
                Value = 11
            };

            var third = new PlayingCard
            {
                Suit = Suit.Hearts,
                Name = CardName.Ace,
                Value = 11
            };

            var fourth = new PlayingCard
            {
                Suit = Suit.Diamonds,
                Name = CardName.Ace,
                Value = 11
            };

            var fifth = new PlayingCard
            {
                Suit = Suit.Spades,
                Name = CardName.Queen,
                Value = 10
            };

            var hand = new BlackjackHand();
            hand.Cards.Add(second);
            hand.Cards.Add(third);

            Assert.AreEqual(hand.Value, 12);
            Assert.IsTrue(hand.IsSoft);

            hand.Cards.Add(fourth);

            Assert.AreEqual(hand.Value, 13);
            Assert.IsTrue(hand.IsSoft);

            hand.Cards.Add(first);

            Assert.AreEqual(hand.Value, 18);
            Assert.IsTrue(hand.IsSoft);

            hand.Cards.Add(fifth);

            Assert.AreEqual(hand.Value, 18);
            Assert.IsFalse(hand.IsSoft);            
        }
    }
}
