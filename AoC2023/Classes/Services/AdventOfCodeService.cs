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
    }
}
