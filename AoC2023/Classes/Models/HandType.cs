using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Camel cards hands types.
    /// Five of a kind, where all five cards have the same label: AAAAA
    /// Four of a kind, where four cards have the same label and one card has a different label: AA8AA
    /// Full house, where three cards have the same label, and the remaining two cards share a different label: 23332
    /// Three of a kind, where three cards have the same label, and the remaining two cards are each different from any other card in the hand: TTT98
    /// Two pair, where two cards share one label, two other cards share a second label, and the remaining card has a third label: 23432
    /// One pair, where two cards share one label, and the other three cards have a different label from the pair and each other: A23A4
    /// High card, where all cards' labels are distinct: 23456
    /// </summary>
    internal enum HandType
    {
        /// <summary>
        /// High card, where all cards' labels are distinct: 23456
        /// </summary>
        HighCard = 0,
        /// <summary>
        /// One pair, where two cards share one label, and the other three cards have a different label from the pair and each other: A23A4
        /// </summary>
        OnePair = 1,
        /// <summary>
        /// Two pair, where two cards share one label, two other cards share a second label, and the remaining card has a third label: 23432
        /// </summary>
        TwoPair = 2,
        /// <summary>
        /// Three of a kind, where three cards have the same label, and the remaining two cards are each different from any other card in the hand: TTT98
        /// </summary>
        ThreeOfAKind = 3,
        /// <summary>
        /// Full house, where three cards have the same label, and the remaining two cards share a different label: 23332
        /// </summary>
        FullHouse = 4,
        /// Four of a kind, where four cards have the same label and one card has a different label: AA8AA
        FourOfAKind = 5,
        /// Five of a kind, where all five cards have the same label: AAAAA
        FiveOfAKind = 6
    }
}
