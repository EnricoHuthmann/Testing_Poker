using System;
using System.Collections.Generic;

namespace Testing_Poker
{
    public class FullHouse
    {
        private Multiple? threeOfAKind;
        private Multiple? pair;

        public FullHouse(Multiple threeOfAKind, Multiple pair)
        {
            this.threeOfAKind = threeOfAKind;
            this.pair = pair;
        }

        public List<Multiple>? GetCards()
        {
            if (threeOfAKind == null || pair == null) return null;

            List<Multiple>? multiples = new()
            {
                threeOfAKind,
                pair
            };

            return multiples;
        }

        public int? GetValue()
        {
            if (threeOfAKind == null || pair == null) return null;

            var value = 0;
            foreach (var keyValuePair in threeOfAKind.GetCards())
            {
                value += keyValuePair.Value;
            }
            
            foreach (var keyValuePair in pair.GetCards())
            {
                value += keyValuePair.Value;
            }

            return value;
        }
    }
}
