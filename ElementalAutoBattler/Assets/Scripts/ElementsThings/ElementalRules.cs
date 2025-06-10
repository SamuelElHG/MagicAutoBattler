using static Elements;
using System.Collections.Generic;

public static class ElementalRules
{
    private static readonly Dictionary<(Element defender, Element attacker), float> _multipliers =
        new Dictionary<(Element, Element), float>
        {
            // Fire > Grass
            {(Element.Grass, Element.Fire), 2f},
            {(Element.Fire, Element.Grass), 0.5f},

            // Grass > Water
            {(Element.Water, Element.Grass), 2f},
            {(Element.Grass, Element.Water), 0.5f},

            // Water > Fire
            {(Element.Fire, Element.Water), 2f},
            {(Element.Water, Element.Fire), 0.5f},

            // Normal vs Spirit
            {(Element.Spirit, Element.Normal), 2.5f}, // Spirit daña mucho a Normal
            {(Element.Normal, Element.Spirit), 0.25f}, // Normal hace poco a Spirit

            // Spirit vs Fire/Grass/Water
            {(Element.Fire, Element.Spirit), 0.75f},
            {(Element.Grass, Element.Spirit), 0.75f},
            {(Element.Water, Element.Spirit), 0.75f},

            {(Element.Spirit, Element.Fire), 1.25f},
            {(Element.Spirit, Element.Grass), 1.25f},
            {(Element.Spirit, Element.Water), 1.25f}
        };

    public static float GetMultiplier(Element defender, Element attacker)
    {
        if (_multipliers.TryGetValue((defender, attacker), out float value))
            return value;
        return 1f; // Neutral damage
    }
}
