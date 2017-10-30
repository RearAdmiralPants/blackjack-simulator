namespace BlackjackSimulator.Abstractions
{
    using System;
    using Windows.Graphics.Imaging;
    using BlackjackSimulator.Abstractions.Model;
    
    /// <summary>
    /// Defines methods for retrieving decorative elements for the game of BlackJack (e.g. cards, suits, etc.).
    /// </summary>
    //// TODO: Implement graphical representation (PRIORITY: LOW)
    public static class BlackjackDecorations
    {
        /// <summary>
        /// Retrieves an ASCII symbol appropriate for BlackJack for a given card suit.
        /// </summary>
        /// <param name="suit">The <see cref="Suit"/> for which to retrieve an ASCII symbol.</param>
        /// <returns>An ASCII symbol appropriate for the suit in question.</returns>
        public static string GetSymbol(Suit suit)
        {
            switch (suit)
            {
                case Suit.Clubs:
                    return "C";
                case Suit.Diamonds:
                    return "D";
                case Suit.Hearts:
                    return "H";
                case Suit.Spades:
                    return "S";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Retrieves an image appropriate for BlackJack for a given card.
        /// </summary>
        /// <param name="card">The <see cref="PlayingCard"/> for which to retrieve an image.</param>
        /// <returns>A <see cref="SoftwareBitmap"/> containing the image retrieved for the requested <paramref name="card"/>.</returns>
        public static SoftwareBitmap GetImage(PlayingCard card)
        {
            throw new NotImplementedException("Feature not yet implemented.");
        }
    }
}
