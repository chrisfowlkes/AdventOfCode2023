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
        /// <returns>Sum of the possible game IDs.</returns>
        public static string SumPossibleGameIds(ICollection<string> data)
        {
            var games = new List<CubeGame>();
            foreach (var game in data)
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

        /// <summary>
        /// For each game, find the minimum set of cubes that must have been present. What is the 
        /// sum of the power of these sets?
        /// </summary>
        /// <param name="data">The games played.</param>
        /// <returns>Sum of the powers of th games</returns>
        public static string SumPowers(ICollection<string> data)
        {
            var games = new List<CubeGame>();
            foreach (var game in data)
            {
                games.Add(new CubeGame(game));
            }

            return games.Select(game => game.Power).Sum().ToString();
        }

        /// <summary>
        /// SUms the engine parts in a schematic document.
        /// </summary>
        /// <param name="data">Schematic.</param>
        /// <returns>Sum of the engine part numbers.</returns>
        public static string SumEnginePartNumbers(ICollection<string> data)
        {
            var schematic = new EngineSchematic(data);
            return schematic.EngineParts.Select(part => part.Number).Sum().ToString();
        }
    }
}
