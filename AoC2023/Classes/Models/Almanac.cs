using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Almanac that lists all of the seeds that need to be planted. It also lists what type of 
    /// soil to use with each kind of seed, what type of fertilizer to use with each kind of soil, 
    /// what type of water to use with each kind of fertilizer, and so on.
    /// </summary>
    public class Almanac
    {
        private readonly List<AlmanacMap> maps = [];

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="text">The almanac text.</param>
        public Almanac(ICollection<string> text)
        {
            List<string>? lines = null;

            foreach(var line in text)
            {
                if(lines != null && string.IsNullOrEmpty(line))
                {
                    maps.Add(new AlmanacMap(lines));
                    lines = null;
                }
                else
                {
                    lines ??= [];
                    if(! string.IsNullOrEmpty(line))
                    {
                        lines.Add(line);
                    }
                }
            }

            if (lines != null)
            {
                maps.Add(new AlmanacMap(lines));
            }
        }

        /// <summary>
        /// COnverts a seed to a location.
        /// </summary>
        /// <param name="seed"></param>
        /// <returns>The location for the seed.</returns>
        public long CalculateSeedLocation(long seed)
        {
            var location = seed;
            foreach(var map in maps)
            {
                location = map.Map(location);
            }

            return location;
        }
    }
}
