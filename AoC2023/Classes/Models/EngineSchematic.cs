using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// The engine schematic consists of a visual representation of the engine. There are lots of 
    /// numbers and symbols you don't really understand, but apparently any number adjacent to a 
    /// symbol, even diagonally, is a "part number".
    /// </summary>
    public partial class EngineSchematic
    {

        [GeneratedRegex(@"\d+")]
        private static partial Regex MyRegex();
        public List<EnginePart> EngineParts { get; set; } = [];
        private readonly ICollection<string> data;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Data from the schematic.</param>
        public EngineSchematic(ICollection<string> data) 
        { 
            this.data = data;
            FindEngineParts();
        }

        private void FindEngineParts()
        {
            for(int i=0;i<data.Count;i++)
            {
                EngineParts.AddRange(GetEngineParts(i));
            }
        }

        private List<EnginePart> GetEngineParts(int row) 
        {
            var parts = new List<EnginePart>();
            var match = MyRegex().Match(data.ElementAt(row));
            while(match.Success)
            {
                var part = new EnginePart()
                {
                    Number = int.Parse(match.Value),
                    Row = row,
                    StartColumn = match.Index,
                    PartNumberLength = match.Length
                };
                if(IsPart(part))
                {
                    parts.Add(part);
                }
                match = match.NextMatch();
            }
            return parts;
        }

        private bool IsPart(EnginePart part)
        {
            return ContainsSymbol(part.Row - 1, part.Row + 1, part.StartColumn - 1, part.PartNumberLength + 2);
        }

        private bool ContainsSymbol(int firstRow, int lastRow, int firstCol, int colCount)
        {
            firstRow = Math.Max(0, firstRow);
            lastRow = Math.Min(lastRow, data.Count - 1);
            int rowCount = lastRow - firstRow + 1;
            return ContainsSymbol(data.Skip(firstRow).Take(rowCount), firstCol, colCount);
        }

        private bool ContainsSymbol(IEnumerable<string> lines, int start, int count)
        {
            return lines.Where(l => ContainsSymbol(l, start, count)).Any();
        }

        private bool ContainsSymbol(string line, int start, int count)
        {
            start = Math.Max(0, start);
            count = Math.Min(count, line.Length - start);
            line = line.Substring(start, count);
            return line.Where(c => IsSymbol(c)).Any();
        }

        private bool IsSymbol(char c) 
        {
            return c != '.' && !char.IsDigit(c);
        }
    }
}
