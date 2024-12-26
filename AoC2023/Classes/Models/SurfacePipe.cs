using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Represents a pipe on the surface of the metal island.
    /// </summary>
    /// <remarks>
    /// Constructor.
    /// </remarks>
    /// <param name="pipeType">Character describing the type of pipe.</param>
    /// <param name="x">X coordinate of the pipe.</param>
    /// <param name="y">Y coordinate of the pipe.</param>
    internal class SurfacePipe(char pipeType, int x, int y)
    {
        /// <summary>
        /// Type of pipe.
        /// </summary>
        public char PipeType { get; set; } = pipeType;
        /// <summary>
        /// Location of the pipe.
        /// </summary>
        internal Point Location { get; set; } = new Point(x, y);

        /// <summary>
        /// Gets the locations connected to the pipe. May return invalid coordinates as bounds are not checked.
        /// </summary>
        /// <returns>The locations connected to the pipe.</returns>
        public List<Point> GetConnectedLocations()
        {
            var connected = new List<Point>();
            switch(PipeType)
            {
                case '|':
                    connected.Add(new Point(Location.X, Location.Y - 1));
                    connected.Add(new Point(Location.X, Location.Y + 1));
                    break;
                case '-':
                    connected.Add(new Point(Location.X - 1, Location.Y));
                    connected.Add(new Point(Location.X + 1, Location.Y));
                    break;
                case 'L':
                    connected.Add(new Point(Location.X, Location.Y - 1));
                    connected.Add(new Point(Location.X + 1, Location.Y));
                    break;
                case 'J':
                    connected.Add(new Point(Location.X, Location.Y - 1));
                    connected.Add(new Point(Location.X - 1, Location.Y));
                    break;
                case '7':
                    connected.Add(new Point(Location.X, Location.Y + 1));
                    connected.Add(new Point(Location.X - 1, Location.Y));
                    break;
                case 'F':
                    connected.Add(new Point(Location.X, Location.Y + 1));
                    connected.Add(new Point(Location.X + 1, Location.Y));
                    break;
            }

            return connected;
        }
    }
}
