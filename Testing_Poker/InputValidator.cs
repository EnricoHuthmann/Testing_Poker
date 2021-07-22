using System;
using System.Collections.Generic;

namespace Testing_Poker
{
    public class InputValidator
    {
        private readonly Dictionary<string, int> deckOfCards;

        public InputValidator()
        {
            deckOfCards = new Dictionary<string, int>()
            {
                ["H2"] = 2,
                ["H3"] = 3,
                ["H4"] = 4,
                ["H5"] = 5,
                ["H6"] = 6,
                ["H7"] = 7,
                ["H8"] = 8,
                ["H9"] = 9,
                ["HX"] = 10,
                ["HJ"] = 11,
                ["HQ"] = 12,
                ["HK"] = 13,
                ["HA"] = 14,

                ["D2"] = 2,
                ["D3"] = 3,
                ["D4"] = 4,
                ["D5"] = 5,
                ["D6"] = 6,
                ["D7"] = 7,
                ["D8"] = 8,
                ["D9"] = 9,
                ["DX"] = 10,
                ["DJ"] = 11,
                ["DQ"] = 12,
                ["DK"] = 13,
                ["DA"] = 14,

                ["C2"] = 2,
                ["C3"] = 3,
                ["C4"] = 4,
                ["C5"] = 5,
                ["C6"] = 6,
                ["C7"] = 7,
                ["C8"] = 8,
                ["C9"] = 9,
                ["CX"] = 10,
                ["CJ"] = 11,
                ["CQ"] = 12,
                ["CK"] = 13,
                ["CA"] = 14,

                ["S2"] = 2,
                ["S3"] = 3,
                ["S4"] = 4,
                ["S5"] = 5,
                ["S6"] = 6,
                ["S7"] = 7,
                ["S8"] = 8,
                ["S9"] = 9,
                ["SX"] = 10,
                ["SJ"] = 11,
                ["SQ"] = 12,
                ["SK"] = 13,
                ["SA"] = 14
            };
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
