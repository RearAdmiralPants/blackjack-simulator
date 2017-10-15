namespace BlackjackSimulator.Abstractions
{
    using System.Collections.Generic;
    public abstract class CardDeck
    {
        public List<PlayingCard> Cards { get; private set; } = new List<PlayingCard>();
    }
}
