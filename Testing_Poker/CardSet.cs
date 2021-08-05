using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Poker
{
    public class CardSet
    {
        private HashSet<KeyValuePair<string, int>> cardSet;

        private HashSet<KeyValuePair<string, int>>? twoPairsSubSet = null;

        public CardSet(string[] givenCards)
        {
            cardSet = new HashSet<KeyValuePair<string, int>>();

            foreach (var card in givenCards)
            {
                var deckOfCards = new DeckOfCards().deckOfCards;
                deckOfCards.TryGetValue(card, out int valueOfCard);
                cardSet.Add(new KeyValuePair<string, int>(card, valueOfCard));
            }
        }

        public bool CheckForTwoPair()
        {
            var cardSetArray = cardSet.ToArray();

            for (int i = 0; i < cardSetArray.Length - 1; i++)
            {
                for (int j = cardSetArray.Length - 1; j > i; j--)
                {
                    if (cardSetArray[i].Value == cardSetArray[j].Value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public HashSet<KeyValuePair<string, int>>? GetTwoPairs()
        {
            var cardSetArray = cardSet.ToArray();

            for (int i = 0; i < cardSetArray.Length - 1; i++)
            {
                for (int j = cardSetArray.Length - 1; j > i; j--)
                {
                    if (cardSetArray[i].Value == cardSetArray[j].Value)
                    {
                        if (twoPairsSubSet == null)
                        {
                            twoPairsSubSet = new HashSet<KeyValuePair<string, int>>();
                        }
                        twoPairsSubSet.Add(cardSetArray[i]);
                        twoPairsSubSet.Add(cardSetArray[j]);
                    }
                }
            }
            return twoPairsSubSet;
        }
    }
}