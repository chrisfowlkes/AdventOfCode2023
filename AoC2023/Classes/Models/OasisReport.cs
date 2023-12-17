using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A report from the OASIS.
    /// </summary>
    public class OasisReport
    {
        private readonly List<OasisReportHistory> histories = [];

        public OasisReport(ICollection<string> data)
        {
            foreach(var line in data)
            {
                histories.Add(new OasisReportHistory(line));
            }
        }

        /// <summary>
        /// Sums the extrapolated next values from the histories.
        /// </summary>
        /// <returns>Sum of the extrapolated next history values.</returns>
        public string SumExtrapolatedNextValues()
        {
            return histories.Select(h => h.ExtrapolatedNextValue).Sum().ToString();
        }

        /// <summary>
        /// Sums the extrapolated previous values from the histories.
        /// </summary>
        /// <returns>Sum of the extrapolated previous history values.</returns>
        public string SumExtrapolatedPreviousValues()
        {
            return histories.Select(h => h.ExtrapolatedPreviousValue).Sum().ToString();
        }
    }
}
