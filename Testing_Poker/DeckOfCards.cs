using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Poker
{
    public class DeckOfCards
    {
        public Dictionary<string, int> deckOfCards = new Dictionary<string, int>()
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

        public DeckOfCards()
        {

        }
    }
}