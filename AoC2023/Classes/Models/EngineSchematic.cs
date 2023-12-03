using System;
using System.Collections.Generic;
using System.IO;
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
        private static partial Regex PartRegex();
        [GeneratedRegex(@"\*")]
        private static partial Regex GearRegex();
        /// <summary>
        /// All parts found in the schematic.
        /// </summary>
        public List<EnginePart> EngineParts { get; set; } = [];
        /// <summary>
        /// All gears found in the schematic.
        /// </summary>
        public List<EngineGear> EngineGears { get; set; } = [];
        private readonly ICollection<string> data;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Data from the schematic.</param>
        public EngineSchematic(ICollection<string> data) 
        { 
            this.data = data;
            FindEngineParts();
            FindEngineGears();
        }

        private void FindEngineParts()
        {
            for (int i = 0; i < data.Count; i++)
            {
                EngineParts.AddRange(GetEngineParts(i));
            }
        }

        private void FindEngineGears()
        {
            for (int i = 0; i < data.Count; i++)
            {
                EngineGears.AddRange(GetEngineGears(i));
            }
        }

        private List<EnginePart> GetEngineParts(int row) 
        {
            var parts = new List<EnginePart>();
            var match = PartRegex().Match(data.ElementAt(row));
            while(match.Success)
            {
                var part = new EnginePart()
                {
                    Number = int.Parse(match.Value),
                    Row = row,
                    StartColumn = match.Index,
                    PartNumberLength = match.Length,
                    EndColumn = match.Index + match.Length - 1
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

        private List<EngineGear> GetEngineGears(int row)
        {
            var gears = new List<EngineGear>();
            var match = GearRegex().Match(data.ElementAt(row));
            while (match.Success)
            {
                var parts = GetAdjacentParts(row, match.Index);
                if (parts.Count == 2)
                {
                    gears.Add(new EngineGear(parts[0], parts[1]));
                }
                match = match.NextMatch();
            }
            return gears;
        }

        private List<EnginePart> GetAdjacentParts(int row, int col)
        {
            var startRow = row - 1;
            var endRow = row + 1;
            var startCol = col - 1;
            var endCol = col + 1;
            return EngineParts.Where(p => p.Row >= startRow 
                                        && p.Row <= endRow 
                                        && p.StartColumn <= endCol 
                                        && p.EndColumn >= startCol).ToList();
        }
    }
}
