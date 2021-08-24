using System;
using System.Collections.Generic;

namespace Testing_Poker
{
    public class InputValidator
    {
        public InputValidator()
        {
        }

        public bool CheckInput(string inputData, int minAmountOfCards = 2, int maxAmountOfCards = 7)
        {
            //check for emtpy string
            if (inputData.Length == 0)
            {
                return false;
            }
            
            string[] inputCards = Array.Empty<string>();
            if (inputData.Contains('['))
            {
                inputData = inputData[1..^1];
                inputCards = inputData.Split(',');
            }
            else
            {
                //input is not set as a sequence of cards with brackets
                return false;
            }

            //by default minimum cards are 2, maximum cards are 7
            if (inputCards.Length < minAmountOfCards || inputCards.Length > maxAmountOfCards)
            {
                return false;
            }  

            var deckOfCards = new DeckOfCards().deckOfCards;
            var cardSet = new HashSet<string>();
            //check if all input cards are in the deck
            foreach (string card in inputCards)
            {
                var trimmedCard = card.Trim();
                cardSet.Add(trimmedCard);
                if (!deckOfCards.ContainsKey(trimmedCard))
                {
                    return false;
                }
            }
            
            if (cardSet.Count < inputCards.Length)
            {
                //this means that there was at least one card twice, which is invalid
                return false;
            }

            return true;
        }
    }
}
