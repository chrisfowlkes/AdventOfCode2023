using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Represents a boat race.
    /// </summary>
    public class Race
    {
        private readonly double time;
        private readonly double recordDistance;

        /// <summary>
        /// The product of winning hold times.
        /// </summary>
        public double WaysToWin { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Time">The amount of time for the race.</param>
        /// <param name="Distance">Record for the most distance covered in the time given for the race.</param>
        public Race(string Time, string Distance) 
        {
            time = double.Parse(Time.Trim());
            recordDistance = double.Parse(Distance.Trim());

            var hold = 0;
            double distance;
            do
            {
                // rate = hold * 1
                // distance = rate * (time - hold)
                // distance = time * hold - hold^2
                hold++;
                distance = time * hold - Math.Pow(hold, 2);
            } while (distance <= recordDistance);
            do
            {
                // rate = hold * 1
                // distance = rate * (time - hold)
                // distance = time * hold - hold^2
                WaysToWin++;
                hold++;
                distance = time * hold - Math.Pow(hold, 2);
            } while (distance > recordDistance);
        }
    }
}
