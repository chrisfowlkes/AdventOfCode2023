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
        /// Constructor.
        /// </summary>
        public Scratchcard(string description) 
        {
            var split = description.Split(':')[1].Split('|');

            InsertNumbers(split[0], WinningNumbers);
            InsertNumbers(split[1], Numbers);
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
            var matches = WinningNumbers.Intersect(Numbers).Count();

            double points;
            if(matches == 0)
            {
                points = 0;
            }
            else
            {
                points = Math.Pow(2, matches-1);
            }

            return points;
        }
    }
}
