using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// The history of a single value in the OASIS history report.
    /// </summary>
    internal class OasisReportHistory
    {
        private readonly List<List<int>> sequences = [];

        /// <summary>
        /// The extrapolated next value for the history.
        /// </summary>
        internal int ExtrapolatedNextValue { get { return sequences[0].Last(); } }
        /// <summary>
        /// The extrapolated next value for the history.
        /// </summary>
        internal int ExtrapolatedPreviousValue { get { return sequences[0][0]; } }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="history">History of the value.</param>
        public OasisReportHistory(string history) 
        {
            var split = history.Split(' ');
            sequences.Add([]);

            //Parse the input into a sequence.
            //Each line in the report contains the history of a single value.
            foreach (var item in split) 
            {
                sequences[0].Add(int.Parse(item));
            }

            //start by making a new sequence from the difference at each step of your history. If
            //that sequence is not all zeroes, repeat this process, using the sequence you just
            //generated as the input sequence.
            var lastSequence = sequences[0];
            while (lastSequence.Where(i => i != 0).Any())
            {
                var newSequence = new List<int>();
                for (int i = 0; i < lastSequence.Count - 1; i++)
                {
                    newSequence.Add(lastSequence[i + 1] - lastSequence[i]);
                }
                sequences.Add(newSequence);
                lastSequence = newSequence;
            }

            //Once all of the values in your latest sequence are zeroes, you can extrapolate what
            //the next value of the original history should be. Start by adding a zero to the last 
            //sequnce, then adding the sum of the value just added and the last value in the
            //previous collection, to the previous collection. 
            lastSequence.Add(0);
            for(int i = sequences.Count - 1; i > 0; i--)
            {
                sequences[i - 1].Add(sequences[i - 1].Last() + sequences[i].Last());
            }

            //Use a similar algorithm to extrapolate a previous value.
            lastSequence.Add(0);//The last row is all 0, so it doesn't matter that we put this at the end.
            for (int i = sequences.Count - 1; i > 0; i--)
            {
                sequences[i - 1].Insert(0, sequences[i - 1][0] - sequences[i][0]);
            }
        }
    }
}
