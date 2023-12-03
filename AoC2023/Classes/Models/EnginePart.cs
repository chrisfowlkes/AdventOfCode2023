using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A part in the engine schematic.
    /// </summary>
    public class EnginePart
    {
        /// <summary>
        /// The number of the part.
        /// </summary>
        public int Number {  get; set; }
        /// <summary>
        /// The row in which the part appears in the schematic.
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// The zero based column at which the part appears in the schematic.
        /// </summary>
        public int StartColumn { get; set; }
        /// <summary>
        /// The length of the string version of the part number.
        /// </summary>
        public int PartNumberLength { get; set; }
        /// <summary>
        /// The zero based column at which the part number ends in the schematic.
        /// </summary>
        public int EndColumn { get; set; }
    }
}
