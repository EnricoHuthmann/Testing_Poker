﻿using System;
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

        public List<Pair>? GetPairs()
        {
            if (cardSet == null) return null;

            List<Pair>? pairs = null;

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
                        pairs.Add(new Pair(new HashSet<KeyValuePair<string, int>> { cardSetArray[i], cardSetArray[j] }));
                    }
                }
            }
            return pairs;
        }

        public List<ThreeOfAKind>? GetThreeOfAKind()
        {
            if (cardSet == null) return null;

            List<ThreeOfAKind>? listOfThreeOfAKind = null;

            bool hasFoundPair;

            var foundPairCard = new KeyValuePair<string, int>();

            var cardSetArray = cardSet.ToArray();

            for (int i = 0; i < cardSetArray.Length - 1; i++)
            {
                hasFoundPair = false;
                for (int j = cardSetArray.Length - 1; j > i; j--)
                {
                    if (cardSetArray[i].Value == cardSetArray[j].Value)
                    {
                        if (!hasFoundPair)
                        {
                            hasFoundPair = true;
                            foundPairCard = cardSetArray[j];
                            continue;
                        }

                        if (listOfThreeOfAKind == null)
                        {
                            listOfThreeOfAKind = new();
                        }
                        listOfThreeOfAKind.Add(new ThreeOfAKind(new HashSet<KeyValuePair<string, int>> { cardSetArray[i], foundPairCard, cardSetArray[j] }));
                    }
                }
            }
            return listOfThreeOfAKind;
        }
    }
}