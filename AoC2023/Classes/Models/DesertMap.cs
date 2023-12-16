using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Map through the desert.
    /// </summary>
    public class DesertMap
    {
        private char[] directions;
        private List<DesertMapNode> nodes = [];

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Map data.</param>
        public DesertMap(ICollection<string> data)
        {
            directions = data.ElementAt(0).ToCharArray();
            var nodeData = data.Skip(2);
            foreach (var node in nodeData)
            {
                nodes.Add(new DesertMapNode(node));
            }
        }

        /// <summary>
        /// Navigates the map.
        /// </summary>
        /// <returns>The number of nodes to the destination.</returns>
        public string Navigate()
        {
            var steps = 0;
            var node = nodes.Where(n => n.Id == "AAA").First();
            
            while (true)
            {
                foreach(var turn in directions)
                {
                    string nextNodeId;
                    if(turn == 'L')
                    {
                        nextNodeId = node.Left;
                    }
                    else
                    {
                        nextNodeId = node.Right;
                    }

                    steps++;
                    if(nextNodeId == "ZZZ")
                    {
                        return steps.ToString();
                    }
                    else
                    {
                        node = nodes.Where(n => n.Id == nextNodeId).First();
                    }
                }
            }
        }
    }
}
