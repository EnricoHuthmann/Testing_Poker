using System;
using System.Collections.Generic;

namespace Testing_Poker
{
    public class Straight
    {
        private HashSet<KeyValuePair<string, int>>? hashSetOfCards;

        public Straight(HashSet<KeyValuePair<string, int>> hashSet)
        {
            if (hashSet.Count != 5) return;

            int? temp = null;

            foreach (var keyValuePair in hashSet)
            {
                if (temp != null)
                {
                    if (keyValuePair.Value != temp + 1) return;
                }
                temp = keyValuePair.Value;
            }
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