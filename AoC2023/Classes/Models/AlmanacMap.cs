using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A map from the almanac.
    /// </summary>
    public class AlmanacMap
    {
        private readonly MapRange[] ranges;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="description">Description of the map.</param>
        public AlmanacMap(ICollection<string> description) 
        { 
            //first line is a description we don't need.
            ranges = new MapRange[description.Count - 1];
            for (int i = 0; i < ranges.Length; i++)
            {
                ranges[i] = new MapRange(description.ElementAt(i + 1));
            }
        }

        /// <summary>
        /// Maps the source number to a destination number.
        /// </summary>
        /// <param name="source">Number to map.</param>
        /// <returns>The destination.</returns>
        public long Map(long source)
        {
            var range = ranges.Where(r => r.InRange(source)).FirstOrDefault();
            return range?.Convert(source) ?? source;
        }
    }
}
