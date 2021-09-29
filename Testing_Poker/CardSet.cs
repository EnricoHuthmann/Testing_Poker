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

        public List<Multiple>? GetMultiples()
        {
            if (cardSet == null) return null;

            var fourOfAKinds = GetFourOfAKind();

            var threeOfAKinds = GetThreeOfAKind();

            var pairs = GetPairs();

            List<Multiple>? listOfMultiples = null;

            if (fourOfAKinds != null) {
                listOfMultiples ??= new();
                listOfMultiples.AddRange(fourOfAKinds);
            }
            if (threeOfAKinds != null)
            {
                listOfMultiples ??= new();
                listOfMultiples.AddRange(threeOfAKinds);
            }
            if (pairs != null)
            {
                listOfMultiples ??= new();
                listOfMultiples.AddRange(pairs);
            }

            return listOfMultiples;
        }

        public List<FullHouse>? GetFullHouse()
        {
            if (cardSet == null) return null;

            var threeOfAKinds = GetThreeOfAKind();

            var pairs = GetPairs();

            List<FullHouse>? listOfFullHouses = null;

            if (threeOfAKinds != null && pairs != null)
            {
                foreach (var threeOfAKind in threeOfAKinds)
                {
                    var threeOfAKindCards = threeOfAKind.GetCards();

                    if (threeOfAKindCards == null) continue;

                    foreach (var pair in pairs)
                    {
                        var pairCards = pair.GetCards();

                        if (pairCards == null) continue;

                        if (threeOfAKindCards[0].Value == pairCards[0].Value) continue;

                        FullHouse fullHouse = new(threeOfAKind, pair);

                        listOfFullHouses ??= new();
                        listOfFullHouses.Add(fullHouse);
                    }
                }
            }

            return listOfFullHouses;
        }

        public List<Straight>? GetStraights()
        {
            if (cardSet == null) return null;

            if (cardSet.Count < 5) return null;

            var sortedCardSet = cardSet.ToList().OrderBy(keyValuePair => keyValuePair.Value).ToList();

            List<Straight>? straights = null;

            for (int i = 0; i < sortedCardSet.Count - 4; i++)
            {
                List<List<KeyValuePair<string, int>>>? tempStraights = new();

                var straightCards = sortedCardSet.Where(card => card.Value >= sortedCardSet[i].Value + 1 && card.Value <= sortedCardSet[i].Value + 4).ToList();

                straightCards.Add(sortedCardSet[i]);

                HashSet<int> tempValueSet = straightCards.Select(card => card.Value).ToHashSet();

                if (tempValueSet.Count < 5) continue;

                foreach (var card in straightCards)
                {
                    var tempValuesCount = straightCards.Where(c => c.Value == card.Value).ToList();

                    if (tempStraights.Count == 0)
                    {
                        tempStraights.Add(new List<KeyValuePair<string, int>>());
                    }

                    foreach (var tempStraight in tempStraights)
                    {
                        tempStraight.Add(card);
                    }

                    // if there is more than one card with the value of the current card
                    if (tempValuesCount.Count >= 1)
                    {
                        tempValuesCount.Remove(card);

                        foreach (var multipleCard in tempValuesCount)
                        {
                            foreach (var tempStraight in tempStraights)
                            {
                                var tempCopy = new List<KeyValuePair<string, int>>();

                                tempCopy.AddRange(tempStraight);

                                tempCopy.Remove(card);
                                tempCopy.Add(multipleCard);

                                tempStraights.Add(tempCopy);
                            }

                            straightCards.Remove(multipleCard);
                        }
                    }
                }
                //create straights from the temporary lists
                foreach (var straightList in tempStraights)
                {
                    var sortedStraightList = straightList.OrderBy(card => card.Value).ToList();

                    straights ??= new();

                    straights.Add(
                        new Straight(
                            new HashSet<KeyValuePair<string, int>>
                            {
                            sortedStraightList[0],
                            sortedStraightList[1],
                            sortedStraightList[2],
                            sortedStraightList[3],
                            sortedStraightList[4]
                            }
                        )
                    );
                }
            }
            
            return straights;
        }
    }
}