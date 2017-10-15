namespace BlackjackSimulator.Abstractions
{
    using System;

    public class AceValue
    {
        public int Value { get; private set; }

        public void SetValue(int newValue)
        {
            if (newValue != 1 && newValue != 11)
            {
                throw new FormatException("Ace values in Blackjack may only be 1 or 11.");
            }

            this.Value = newValue;
        }
    }
}
