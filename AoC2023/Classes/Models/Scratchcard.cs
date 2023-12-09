using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Represents a scratchcard.
    /// </summary>
    public class Scratchcard
    {
        /// <summary>
        /// The winning numbers for the scratchcard.
        /// </summary>
        public List<int> WinningNumbers { get; set; } = [];
        /// <summary>
        /// The actual numbers on the scratchcard.
        /// </summary>
        public List<int> Numbers { get; set; } = [];
        /// <summary>
        /// The number of matches of winning numbers.
        /// </summary>
        public int Matches { get { return WinningNumbers.Intersect(Numbers).Count(); } }
        /// <summary>
        /// The card number.
        /// </summary>
        public int CardNumber { get; set; }
        /// <summary>
        /// Number of copies of the card.
        /// </summary>
        public int Copies { get; set; } = 1;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Scratchcard(string description) 
        {
            var descriptionSplit = description.Split(':');
            CardNumber = int.Parse(descriptionSplit[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);

            var numberSplit = descriptionSplit[1].Split('|');
            InsertNumbers(numberSplit[0], WinningNumbers);
            InsertNumbers(numberSplit[1], Numbers);
        }

        private static void InsertNumbers(string numbers,  List<int> collection)
        {
            var numbersSplit = numbers.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in numbersSplit)
            {
                var i = int.Parse(number);
                collection.Add(i);
            }
        }

        /// <summary>
        /// The first match makes the card worth one point and each match after the first doubles 
        /// the point value of that card.
        /// </summary>
        /// <returns>Number of points the card is worth.</returns>
        public double GetPoints()
        {
            double points;
            if(Matches == 0)
            {
                points = 0;
            }
            else
            {
                points = Math.Pow(2, Matches-1);
            }

            return points;
        }
    }
}
