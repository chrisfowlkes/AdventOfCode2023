using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A gear is any * symbol that is adjacent to exactly two part numbers. 
    /// </summary>
    public class EngineGear
    {
        private EnginePart[] parts = new EnginePart[2];
        /// <summary>
        /// Its gear ratio is the result of multiplying the two part numbers together.
        /// </summary>
        public int Ratio { get { return parts[0].Number * parts[1].Number; } }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="part1">The first engine part adjacent to the gear.</param>
        /// <param name="part2">The second engine part adjacent to the gear.</param>
        public EngineGear(EnginePart part1, EnginePart part2) 
        {
            parts[0] = part1;
            parts[1] = part2;
        }
    }
}
