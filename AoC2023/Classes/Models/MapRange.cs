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
        private readonly long destinationFirst;
        private readonly long sourceFirst;
        private readonly long length;
        private readonly long factor;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="description">Line from the almanac that describes the range.</param>
        public MapRange(string description)
        {
            var split = description.Split(' ');
            destinationFirst = long.Parse(split[0]);
            sourceFirst = long.Parse(split[1]);
            length = long.Parse(split[2]);
            factor = destinationFirst - sourceFirst;
        }

        /// <summary>
        /// Checks to see if a given source is in the range.
        /// </summary>
        /// <param name="source">The source to check.</param>
        /// <returns>True if the source is in range.</returns>
        public bool InRange(long source)
        {
            return source >= sourceFirst && source < sourceFirst + length;
        }

        /// <summary>
        /// Returns the destination value for the given source.
        /// </summary>
        /// <param name="Source">The source number to convert.</param>
        /// <returns>The destination number.</returns>
        public long Convert(long source)
        {
            return source + factor;             
        }
    }
}
