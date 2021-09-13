using System;
using System.Collections.Generic;

namespace Testing_Poker
{
    public class Multiple
    {
        private HashSet<KeyValuePair<string, int>>? hashSetOfCards;

        public Multiple(HashSet<KeyValuePair<string, int>> hashSet)
        {
            this.hashSetOfCards = hashSet;
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
            if (hashSetOfCards == null) return null;

            var value = 0;
            foreach (var keyValuePair in hashSetOfCards)
            {
                value += keyValuePair.Value;
            }
            return value;
        }
    }
}
