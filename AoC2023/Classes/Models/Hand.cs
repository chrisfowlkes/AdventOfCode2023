using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Classes.Models
{
    /// <summary>
    /// A camel cards hand.
    /// Five of a kind, where all five cards have the same label: AAAAA
    /// Four of a kind, where four cards have the same label and one card has a different label: AA8AA
    /// Full house, where three cards have the same label, and the remaining two cards share a different label: 23332
    /// Three of a kind, where three cards have the same label, and the remaining two cards are each different from any other card in the hand: TTT98
    /// Two pair, where two cards share one label, two other cards share a second label, and the remaining card has a third label: 23432
    /// One pair, where two cards share one label, and the other three cards have a different label from the pair and each other: A23A4
    /// High card, where all cards' labels are distinct: 23456
    /// </summary>
    public class Hand : IComparable<Hand>
    {
        private readonly char[] cards;
        /// <summary>
        /// The bid for the hand.
        /// </summary>
        internal int Bid { get; private set; }
        /// <summary>
        /// Rank of the hand.
        /// </summary>
        internal HandType HandType { get; private set; }
        private readonly bool wildcard;
        private readonly char[] cardRanks;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="description">Description of the hand.</param>
        public Hand(string description, bool wildcard = false)
        {
            var split = description.Trim().Split(' ');
            cards = split[0].ToCharArray();
            Bid = int.Parse(split[1]);
            this.wildcard = wildcard;
            if(wildcard)
            {
                cardRanks = ['J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A'];
            }
            else
            {
                cardRanks = ['2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'];
            }
            RankHand();
        }

        private void RankHand()
        {
            var labelCounts = CountLabels();
            int wildcardCount;
            if(wildcard)
            {
                wildcardCount = labelCounts[0];
                labelCounts = labelCounts.Skip(1).ToArray();
            }
            else
            {
                wildcardCount = 0;
            }
            var maxCount = labelCounts.Max() + wildcardCount;
            if (maxCount == 5)
            {
                HandType = HandType.FiveOfAKind;
            } 
            else
            {
                if (maxCount == 4)
                {
                    HandType = HandType.FourOfAKind;
                }
                else
                {
                    var uniqueTypes = labelCounts.Where(i => i > 0).Count();
                    if (uniqueTypes <= 2)
                    {
                        HandType = HandType.FullHouse;
                    }
                    else if (maxCount == 3)
                    {
                        HandType = HandType.ThreeOfAKind;
                    }
                    else if (uniqueTypes == 3)
                    {
                        HandType = HandType.TwoPair;
                    }
                    else if (maxCount == 2)
                    {
                        HandType = HandType.OnePair;
                    }
                    else
                    {
                        HandType = HandType.HighCard;
                    }
                }
            }
        }

        private int[] CountLabels()
        {
            var counts = new int[cardRanks.Length];
            for (var i = 0; i < cardRanks.Length; i++)
            {
                counts[i] = CountLabels(cardRanks[i]);
            }

            return counts;
        }

        private int CountLabels(char label)
        {
            return cards.Where(c => c == label).Count();
        }

        /// <summary>
        /// Compares hands.
        /// </summary>
        /// <param name="other">The hand to compare to.</param>
        /// <returns>Negative if this hand preceeds the other, positive if the other preceeds this, 0 if equal.</returns>
        public int CompareTo(Hand? other)
        {
            int result;
            if(other == null)
            {
                result = -1;
            }
            else
            {
                result = HandType - other.HandType;

                if (result == 0)
                {
                    result = CardRanks().CompareTo(other.CardRanks());
                }
            }

            return result;
        }

        private int CardRanks()
        {
            var rank = "0x";

            for(int i=0; i < cards.Length; i++)
            {
                rank += Array.IndexOf(cardRanks, cards[i]).ToString("X");
            }

            var rankInt = Convert.ToInt32(rank, 16);
            return rankInt;
        }
    }
}
