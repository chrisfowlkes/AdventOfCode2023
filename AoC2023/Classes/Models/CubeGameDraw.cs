using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// To get information, once a bag has been loaded with cubes, the Elf will reach into the bag, 
    /// grab a handful of random cubes, show them to you, and then put them back in the bag. He'll 
    /// do this a few times per game.
    /// </summary>
    public class CubeGameDraw
    {
        /// <summary>
        /// Number of red cubes in the draw.
        /// </summary>
        public int Red { get; set; }
        /// <summary>
        /// Number of blue cubes in the draw.
        /// </summary>
        public int Blue { get; set; }
        /// <summary>
        /// Number of green cubes in the draw.
        /// </summary>
        public int Green { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="desc">Description of the draw.</param>
        public CubeGameDraw(string desc)
        {
            /*
            Example data.
             1 red, 2 green, 6 blue
            */
            var colorCounts = desc.Split(',');
            foreach (var colorCount in colorCounts)
            {
                var split = colorCount.Trim().Split(' ');
                switch(split[1])
                {
                    case "red":
                        Red = int.Parse(split[0]); 
                        break;
                    case "blue":
                        Blue = int.Parse(split[0]); 
                        break;
                    case "green":
                        Green = int.Parse(split[0]); 
                        break;
                }
            }
        }
    }
}
