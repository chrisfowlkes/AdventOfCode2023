using Classes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// Sums the engine parts in a schematic document.
        /// </summary>
        /// <param name="data">Schematic.</param>
        /// <returns>Sum of the engine part numbers.</returns>
        public static string SumEnginePartNumbers(ICollection<string> data)
        {
            var schematic = new EngineSchematic(data);
            return schematic.EngineParts.Select(part => part.Number).Sum().ToString();
        }

        /// <summary>
        /// Sums the engine gear ratios in a schematic document.
        /// </summary>
        /// <param name="data">Schematic.</param>
        /// <returns>Sum of the engine gear ratios.</returns>
        public static string SumEngineGearRatios(ICollection<string> data)
        {
            var schematic = new EngineSchematic(data);
            return schematic.EngineGears.Select(gear => gear.Ratio).Sum().ToString();
        }

        /// <summary>
        /// Sums the points for the given scratchcards.
        /// </summary>
        /// <param name="data">Scratchcards.</param>
        /// <returns>Sum of the points of the cards.</returns>
        public static string SumScratchcardPoints(ICollection<string> data)
        {
            var cards = new List<Scratchcard>();

            foreach (var line in data)
            {
                cards.Add(new Scratchcard(line));
            }

            return cards.Select(c => c.GetPoints()).Sum().ToString();
        }

        /// <summary>
        /// Counts the scratchcards.
        /// </summary>
        /// <param name="data">Scratchcards.</param>
        /// <returns>Total scratchcard count including scratchcards won.</returns>
        public static string CountScratchcards(ICollection<string> data)
        {
            var cards = new List<Scratchcard>();

            foreach (var line in data)
            {
                cards.Add(new Scratchcard(line));
            }

            foreach (var card in cards)
            {
                for (var i = 1; i <= card.Matches; i++)
                {
                    cards.Where(c => c.CardNumber == card.CardNumber + i).Single().Copies += card.Copies;
                }
            }

            return cards.Select(c => c.Copies).Sum().ToString();
        }

        /// <summary>
        /// Finds the closest seed location.
        /// </summary>
        /// <param name="data">Almanac data.</param>
        /// <param name="useRange">Flag to use seed line as a range.</param>
        /// <returns>The closest seed location.</returns>
        public static string FindClosestSeedLocation(ICollection<string> data, bool useRange = false)
        {
            //First line contains the seeds.
            var seeds = new List<long>();
            var seedLine = data.First();
            var seedLineSplit = seedLine.Split(':');
            var seedNumbers = seedLineSplit[1].Trim();
            var seedNumbersSplit = seedNumbers.Split(' ');

            if(useRange)
            {
                for(var i = 0; i < seedNumbersSplit.Length; i+=2)
                {
                    var start = long.Parse(seedNumbersSplit[i]);
                    var length = long.Parse(seedNumbersSplit[i + 1]);
                    var end = start + length;
                    for(var j=start;j<end;j++)
                    {
                        seeds.Add(j);
                    }
                }
            }
            else
            {
                foreach (var seedNumber in seedNumbersSplit)
                {
                    seeds.Add(long.Parse(seedNumber));
                }
            }

            var almanac = new Almanac(data.Skip(1).ToList());
            var closestLocation = long.MaxValue;

            foreach(var seed in seeds)
            {
                var currentLocation = almanac.CalculateSeedLocation(seed);
                closestLocation = Math.Min(closestLocation, currentLocation);
            }

            return closestLocation.ToString();
        }

        /// <summary>
        /// Determines the ways to win boat races.
        /// </summary>
        /// <param name="data">Description of the races.</param>
        /// <returns>The prodict of the number of ways to win races.</returns>
        public static string CalculateProductOfWaysToWinRaces(ICollection<string> data)
        {
            var times = data.ElementAt(0).Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var distances = data.ElementAt(1).Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double product = 1;
            for(int i=1;i<times.Length;i++)
            {
                var race = new Race(times[i], distances[i]);
                product *= race.WaysToWin;
            }

            return product.ToString();
        }
    }
}
