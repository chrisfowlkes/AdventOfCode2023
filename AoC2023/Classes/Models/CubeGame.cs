using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// As you walk, the Elf shows you a small bag and some cubes which are either red, green, or 
    /// blue. Each time you play this game, he will hide a secret number of cubes of each color in 
    /// the bag, and your goal is to figure out information about the number of cubes.
    /// </summary>
    public class CubeGame
    {
        /// <summary>
        /// The ID of the game.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Draws in the game.
        /// </summary>
        public List<CubeGameDraw> Draws { get; set; } = [];
        /// <summary>
        /// The minimum nuber of red cubes in the bag.
        /// </summary>
        public int MinimumRed { get { return Draws.Select(draw => draw.Red).Max(); } }
        /// <summary>
        /// The minimum nuber of green cubes in the bag.
        /// </summary>
        public int MinimumGreen { get { return Draws.Select(draw => draw.Green).Max(); } }
        /// <summary>
        /// The minimum nuber of blue cubes in the bag.
        /// </summary>
        public int MinimumBlue { get { return Draws.Select(draw => draw.Blue).Max(); } }
        /// <summary>
        /// The minimum number of cubes present in the bag.
        /// </summary>
        public int MinimumCubes {  get { return MinimumRed + MinimumGreen + MinimumBlue; } }
        /// <summary>
        /// The power of a set of cubes is equal to the numbers of red, green, and blue cubes 
        /// multiplied together.
        /// </summary>
        public int Power {  get { return MinimumRed * MinimumGreen * MinimumBlue; } }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="desc">Description of the game.</param>
        public CubeGame(string desc) 
        {
            /*
            Example data.
            Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            */
            var split = desc.Split(':');
            Id = int.Parse(split[0].Split(' ')[1]);

            var draws = split[1].Split(';');
            foreach (var draw in draws)
            {
                Draws.Add(new CubeGameDraw(draw));
            }
        }
    }
}
