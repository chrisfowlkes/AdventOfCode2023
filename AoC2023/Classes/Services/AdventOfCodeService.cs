using Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Services
{
    /// <summary>
    /// Main service for the Advent of Code.
    /// </summary>
    public class AdventOfCodeService
    {
        /// <summary>
        /// Calculates a calibration value from the input.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>The calibration document.</returns>
        public static string ReadCalibration(ICollection<string> data, bool translate = false)
        {
            var doc = new CalibrationDocument(data);
            return doc.Calculate(translate).ToString();
        }

        /// <summary>
        /// Determine which games would have been possible if the bag had been loaded with only 12 
        /// red cubes, 13 green cubes, and 14 blue cubes.
        /// </summary>
        /// <param name="data">The games played.</param>
        /// <returns></returns>
        public static string SumPossibleGameIds(ICollection<string> data)
        {
            var games = new List<CubeGame>();
            foreach(var game in data)
            {
                games.Add(new CubeGame(game));
            }

            return games.Where(
                game => game.MinimumRed <= 12 
                && game.MinimumGreen <= 13 
                && game.MinimumBlue <= 14 
                && game.MinimumCubes <= 39)
                .Select(game => game.Id)
                .Sum()
                .ToString();
        }
    }
}
