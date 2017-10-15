namespace BlackjackSimulator.Abstractions
{
    using System;

    public class PlayingCard
    {
        public string Name { get; set; }

        public Suit Suit { get; set; }

        public int Value { get; set; }

        public Func<object, int> DeterminedValue { get; set; }
    }
}
