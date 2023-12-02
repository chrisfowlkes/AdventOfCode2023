using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Represents a clibration document.
    /// </summary>
    public class CalibrationDocument(ICollection<string> lines)
    {
        private readonly string[] digitNames = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

        /// <summary>
        /// Calculates the calibration value.
        /// </summary>
        /// <param name="translate">Pass as true to convert digit names to digits. Defaults to false.</param>
        /// <returns>Calibation value.</returns>
        public int Calculate(bool translate = false)
        {
            int total = 0;
            foreach (var line in lines)
            {
                var first = FindFirstDigit(line, translate);
                var last = FindLastDigit(line, translate);

                total += first * 10 + last;
            }

            return total;
        }

        private int FindFirstDigit(string s, bool translate)
        {
            var firstDigit = 0;
            do
            {
                if (char.IsDigit(s[0]))
                {
                    firstDigit = s[0] - '0';
                }
                else if (translate)
                {
                    for (var i = 0; i < digitNames.Length; i++)
                    {
                        if (s.StartsWith(digitNames[i]))
                        {
                            firstDigit = i + 1;
                            break;
                        }
                    }
                }

                if (firstDigit > 0)
                {
                    //Found it, we are done.
                    break;
                }

                s = s[1..];//Trim one character from beginning.
            } while (s.Length > 0);
            return firstDigit;
        }

        private int FindLastDigit(string s, bool translate)
        {
            var lastDigit = 0;
            do
            {
                var lastChar = s.Last();
                if (char.IsDigit(lastChar))
                {
                    lastDigit = lastChar - '0';
                }
                else if (translate)
                {
                    for (var i = 0; i < digitNames.Length; i++)
                    {
                        if (s.EndsWith(digitNames[i]))
                        {
                            lastDigit = i + 1;
                            break;
                        }
                    }
                }

                if (lastDigit > 0)
                {
                    //Found it, we are done.
                    break;
                }

                s = s[..^1];//Trim one character from end.
            } while (s.Length > 0);
            return lastDigit;
        }
    }
}
