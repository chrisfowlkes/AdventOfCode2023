using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// A node on the desert map.
    /// </summary>
    internal class DesertMapNode
    {
        /// <summary>
        /// ID of the node.
        /// </summary>
        internal string Id { get; set; }
        /// <summary>
        /// ID of the left node.
        /// </summary>
        internal string Left { get; set; }
        /// <summary>
        /// ID of the right node.
        /// </summary>
        internal string Right { get; set; }

        /// <summary>
        /// Data for the node.
        /// </summary>
        /// <param name="line">Data for the node.</param>
        internal DesertMapNode (string line)
        {
            Id = line.Substring(0, 3);
            Left = line.Substring(7, 3);
            Right = line.Substring(12, 3);
        }
    }
}
