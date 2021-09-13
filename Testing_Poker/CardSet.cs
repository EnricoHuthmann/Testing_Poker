using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Poker
{
    public class CardSet
    {
        private HashSet<KeyValuePair<string, int>>? cardSet;

        public CardSet(string[] givenCards)
        {
            cardSet = null;

            foreach (var card in givenCards)
            {
                if (cardSet == null) cardSet = new();

                var deckOfCards = new DeckOfCards().deckOfCards;
                deckOfCards.TryGetValue(card, out int valueOfCard);
                cardSet.Add(new KeyValuePair<string, int>(card, valueOfCard));
            }
        }

        public List<Multiple>? GetPairs()
        {
            if (cardSet == null) return null;

            List<Multiple>? pairs = null;

            var cardSetArray = cardSet.ToArray();

            for (int i = 0; i < cardSetArray.Length - 1; i++)
            {
                for (int j = cardSetArray.Length - 1; j > i; j--)
                {
                    if (cardSetArray[i].Value == cardSetArray[j].Value)
                    {
                        if (pairs == null)
                        {
                            pairs = new();
                        }
                        pairs.Add(new Multiple(new HashSet<KeyValuePair<string, int>> { cardSetArray[i], cardSetArray[j] }));
                    }
                }
            }
            return pairs;
        }

        public List<Multiple>? GetThreeOfAKind()
        {
            if (cardSet == null) return null;

            List<Multiple>? listOfThreeOfAKind = null;

            var cardSetArray = cardSet.ToArray();

            var lastIndex = cardSetArray.Length - 1;

            for (int i = 0; i < lastIndex; i++)
            {
                for (int j = lastIndex; j > i; j--)
                {
                    if (cardSetArray[i].Value != cardSetArray[j].Value) continue;
                    
                    for (int k = i + 1; k < j; k++)
                    {
                        if (cardSetArray[i].Value == cardSetArray[k].Value)
                        {
                            if (listOfThreeOfAKind == null)
                            {
                                listOfThreeOfAKind = new();
                            }
                            listOfThreeOfAKind.Add(new Multiple(new HashSet<KeyValuePair<string, int>> { cardSetArray[i], cardSetArray[j], cardSetArray[k] }));
                        }
                    }
                }
            }
            return listOfThreeOfAKind;
        }

        public List<Multiple>? GetFourOfAKind()
        {
            if (cardSet == null) return null;

            List<Multiple>? listOfFourOfAKind = null;

            var cardSetArray = cardSet.ToArray();

            var lastIndex = cardSetArray.Length - 1;

            for (int i = 0; i < lastIndex; i++)
            {
                for (int j = lastIndex; j > i; j--)
                {
                    if (cardSetArray[i].Value != cardSetArray[j].Value) continue;

                    for (int k = j - 1; k > i; k--)
                    {
                        if (cardSetArray[i].Value != cardSetArray[k].Value) continue;

                        for (int l = i + 1; l < k; l++)
                        {
                            if (cardSetArray[i].Value != cardSetArray[l].Value) continue;
                            
                            if (listOfFourOfAKind == null)
                            {
                                listOfFourOfAKind = new();
                            }
                            listOfFourOfAKind.Add(
                                new Multiple(
                                    new HashSet<KeyValuePair<string, int>>
                                    {
                                        cardSetArray[i],
                                        cardSetArray[j],
                                        cardSetArray[k],
                                        cardSetArray[l]
                                    }
                                )
                            );
                        }
                    }                    
                }
            }
            return listOfFourOfAKind;
        }
    }
}