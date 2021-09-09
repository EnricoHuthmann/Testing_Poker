using System;
using System.Collections.Generic;

namespace Testing_Poker
{
    public class FourOfAKind
    {
        private HashSet<KeyValuePair<string, int>>? hashSetOfCards;

        public FourOfAKind(HashSet<KeyValuePair<string, int>> hashSet)
        {
            if (hashSet.Count == 4)
            {
                this.hashSetOfCards = hashSet;
            }
        }

        public List<KeyValuePair<string, int>>? GetCards()
        {
            if (hashSetOfCards == null) return null;

            List<KeyValuePair<string, int>> cards = new();

            foreach (var keyValuePair in hashSetOfCards)
            {
                cards.Add(keyValuePair);
            }
            return cards;
        }

        public int? GetValue()
        {
            if (hashSetOfCards != null)
            {
                foreach (var keyValuePair in hashSetOfCards)
                {
                    return keyValuePair.Value * 4;
                }
            }
            return null;
        }
    }
}
