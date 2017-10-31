namespace BlackjackSimulator.Test
{
    using System;
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
    using BlackjackSimulator.Abstractions;
    using BlackjackSimulator.Abstractions.Model;
    using System.Linq;
    using System.Collections.Generic;

    [TestClass]
    public class BlackjackShoeTest
    {
        private const int SHUFFLE_CARDS_TO_TEST = 5;
        private const int SHUFFLES_TO_TEST_RANDOMNESS = 10000;
        private const double SHUFFLES_RANDOMNESS_ACCEPTABLE_MATCHES = 0.05;

        /// <summary>
        /// Test the Shuffle() method by ensuring that at least one of the first five cards differs after a shuffle.
        /// 
        /// NOTE: There is a small chance that this test will fail due to simple statistics. 
        /// ////TODO: Find a fix for the above NOTE.
        /// </summary>
        [TestMethod]
        public void ShoeShuffle_CardChanges()
        {
            // Create a new deck, and look at the first card
            var newShoe = new BlackjackShoe(8);
            var firstCardsUnshuffled = newShoe.PeekCards(0, SHUFFLE_CARDS_TO_TEST);
            var unshuffledTest = new List<PlayingCard>();
            var shuffledTest = new List<PlayingCard>();

            Assert.IsNotNull(firstCardsUnshuffled);
            Assert.AreEqual(firstCardsUnshuffled.Count, SHUFFLE_CARDS_TO_TEST);
            foreach (var unshuffled in firstCardsUnshuffled)
            {
                // Make sure it's not the default class value.
                Assert.IsNotNull(unshuffled);
                Assert.IsFalse(unshuffled == default(PlayingCard));

                unshuffledTest.Add(unshuffled);
            }

            // Shuffle the deck
            newShoe.Shuffle();
            var firstCardsShuffled = newShoe.PeekCards(0, SHUFFLE_CARDS_TO_TEST);
            Assert.IsNotNull(firstCardsShuffled);
            Assert.AreEqual(firstCardsShuffled.Count, SHUFFLE_CARDS_TO_TEST);
            foreach (var shuffled in firstCardsShuffled)
            {
                // Make sure we have actual cards
                Assert.IsNotNull(shuffled);
                Assert.IsFalse(shuffled == default(PlayingCard));

                shuffledTest.Add(shuffled);
            }

            var allCardsEqual = true;
            for (var iterCards = 0; iterCards < SHUFFLE_CARDS_TO_TEST; iterCards++)
            {
                if (!(unshuffledTest[iterCards].Equals(shuffledTest[iterCards]))) {
                    allCardsEqual = false;
                }
            }

            Assert.IsFalse(allCardsEqual);
        }

        /// <summary>
        /// Observes the frequency with which the first card appears the same over a large number of deck shuffles.
        /// 
        /// NOTE: There is a small chance that this test will fail due to simple statistics. 
        /// ////TODO: Find a fix for the above NOTE.
        /// </summary>
        [TestMethod]
        public void ShoeShuffle_CardFrequency()
        {
            var shoe = new BlackjackShoe(8);
            double matchCount = 0;

            shoe.Shuffle();
            var firstCard = shoe.PeekCards(0, 1).FirstOrDefault();
            // Make sure we have an actual card
            Assert.IsNotNull(firstCard);
            Assert.IsFalse(firstCard == default(PlayingCard));

            for (var iterTest = 0; iterTest < SHUFFLES_TO_TEST_RANDOMNESS; iterTest++)
            {
                shoe.Reset();
                
                shoe.Shuffle();

                var cardTest = shoe.PeekCards(0, 1).FirstOrDefault();
                if (cardTest.Equals(firstCard))
                {
                    matchCount++;
                }
            }

            double matchFreq = matchCount / Convert.ToDouble(SHUFFLES_TO_TEST_RANDOMNESS);

            System.Diagnostics.Debug.WriteLine("Frequency observed: " + matchFreq);

            Assert.IsTrue(matchFreq < SHUFFLES_RANDOMNESS_ACCEPTABLE_MATCHES);
        }
    }
}
