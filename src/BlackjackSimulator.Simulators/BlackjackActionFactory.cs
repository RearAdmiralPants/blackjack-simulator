namespace BlackjackSimulator.Simulators
{
    using System;
    using BlackjackSimulator.Abstractions;
    using BlackjackSimulator.Abstractions.Model;

    public static class BlackjackActionFactory
    {
        public static BlackjackAction BlackjackActionFromDataString(string data, IBlackjackRules rules, BlackjackSimulator.Abstractions.Model.BlackjackHand currentHand)
        {
            switch (data)
            {
                case "H":
                    return BlackjackAction.Hit;
                case "S":
                    return BlackjackAction.Stand;
                case "P":
                    return BlackjackAction.Split;
                case "DH":
                    if (rules.CanDouble(currentHand))
                    {
                        return BlackjackAction.DoubleDown;
                    }
                    return BlackjackAction.Hit;
                case "DS":
                    if (rules.CanDouble(currentHand))
                    {
                        return BlackjackAction.DoubleDown;
                    }
                    return BlackjackAction.Stand;
                case "PH":
                    if (rules.DoubleAfterSplitAllowed)
                    {
                        return BlackjackAction.Split;
                    }
                    return BlackjackAction.Hit;
                case "RH":
                    if (rules.SurrenderValue > 0)
                    {
                        return BlackjackAction.Surrender;
                    }
                    return BlackjackAction.Hit;
                case "RS":
                    if (rules.SurrenderValue > 0)
                    {
                        return BlackjackAction.Surrender;
                    }
                    return BlackjackAction.Stand;
                case "RP":
                    if (rules.SurrenderValue > 0)
                    {
                        return BlackjackAction.Surrender;
                    }
                    ////TODO: Should split - but what if you can't?
                    return BlackjackAction.Split;
                default:
                    throw new ArgumentException("Could not parse '" + data + "' into a blackjack action.");
            }
        }
    }
}