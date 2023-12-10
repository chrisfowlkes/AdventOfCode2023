using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A range within an almanac map.
    /// </summary>
    public class MapRange
    {
        private readonly long destinationStart;
        private readonly long sourceStart;
        private readonly long length;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="description">Line from the almanac that describes the range.</param>
        public MapRange(string description)
        {
            var split = description.Split(' ');
            destinationStart = long.Parse(split[0]);
            sourceStart = long.Parse(split[1]);
            length = long.Parse(split[2]);
        }

        /// <summary>
        /// Checks to see if a given source is in the range.
        /// </summary>
        /// <param name="source">The source to check.</param>
        /// <returns>True if the source is in range.</returns>
        public bool InRange(long source)
        {
            return source >= sourceStart && source < sourceStart + length;
        }

        /// <summary>
        /// Returns the destination value for the given source.
        /// </summary>
        /// <param name="Source">The source number to convert.</param>
        /// <returns>The destination number.</returns>
        public long Convert(long source)
        {
            return source - sourceStart + destinationStart;             
        }
    }
}
