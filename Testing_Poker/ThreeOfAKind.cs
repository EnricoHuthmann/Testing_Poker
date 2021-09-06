using System.Collections.Generic;

namespace Testing_Poker
{
    public class ThreeOfAKind
    {
        private HashSet<KeyValuePair<string, int>>? hashSetOfCards;

        public ThreeOfAKind(HashSet<KeyValuePair<string, int>> hashSet)
        {
            if (hashSet.Count == 3)
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
                    return keyValuePair.Value * 3;
                }
            }
            return null;
        }
    }
}