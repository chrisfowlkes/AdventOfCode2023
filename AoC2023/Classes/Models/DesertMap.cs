using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Classes.Models
{
    /// <summary>
    /// Map through the desert.
    /// </summary>
    public class DesertMap
    {
        private readonly char[] directions;
        private readonly List<DesertMapNode> nodes = [];

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
        /// <param name="multi">Pass true to traverse multiple paths at once.</param>
        /// <returns>The number of nodes to the destination.</returns>
        public string Navigate(bool multi = false)
        {
            var steps = 0L;
            DesertMapNode[] currentNodes;
            if (multi)
            {
                currentNodes = nodes.Where(n => n.Id.EndsWith('A')).ToArray();
            }
            else
            {
                currentNodes = [nodes.Where(n => n.Id == "AAA").First()];
            }
            var exits = new List<List<long>>();
            foreach(var node in currentNodes)
            {
                exits.Add(MapNode(node, multi));                
            }
            if (multi)
            {
                if(exits.Where(p => p.Count == 1).Any())
                {
                    //Atleast one of the oaths has only one exit. Find the largest of these and start multiplying.
                    var max = exits.Where(p => p.Count == 1).Select(p => p.Max()).Max();
                    var multiple = max;
                    var i = 2L;
                    while(! exits.All(p => p.Where(e => multiple % e == 0).Any()))
                    {
                        multiple = max * i++;
                    }
                    steps = multiple;
                }
                else
                {
                    //No path with a single exit. Start looking for common step count by multiplying.
                    var multiplier = 2;
                    var originalExits = new List<List<long>>();//Freeze the path in time.
                    for (int i = 0; i < exits.Count; i++)
                    {
                        originalExits.Add(new List<long>(exits[i]));
                    }
                    //Calculate multiples of exits to find the lowest common exit step.
                    long? commonExit = FindCommonExit(exits);
                    while (commonExit == null)
                    {
                        for (int i = 0; i < originalExits.Count; i++)
                        {
                            for (int j = 0; j < originalExits[i].Count; j++)
                            {
                                exits[i].Add(originalExits[i][j] * multiplier);
                            }
                        }
                        multiplier++;
                        commonExit = FindCommonExit(exits);
                    }
                    steps = commonExit.Value;
                }
            }
            else
            {
                steps = exits[0][0];
            }

            return steps.ToString();
        }

        private static long? FindCommonExit(List<List<long>> exits)
        {
            long? commonExit = null;

            //Find the minimum exit in each collection. We can drop any exit below the highest minimum 
            //as they will only get larger from here.
            long dropBelow = exits.Select(p => p.Min()).Max();
            foreach (var path in exits)
            {
                path.RemoveAll(e => e < dropBelow);
            }

            if(! exits.Where(p => p.Count == 0).Any())
            {
                foreach (var exit in exits[0])
                {
                    if (exits.Where(p => p.Contains(exit)).Count() == exits.Count)
                    {
                        //All paths contain the current exit.
                        commonExit = exit;
                        break;
                    }
                }
            }

            return commonExit;
        }

        private List<long> MapNode(DesertMapNode node, bool multi)
        {
            var steps = 0;
            var exits = new List<long>();
            var currentNode = node;

            do
            {
                foreach (var turn in directions)
                {
                    if (turn == 'L')
                    {
                        currentNode = nodes.Where(n => n.Id == currentNode.Left).First();
                    }
                    else
                    {
                        currentNode = nodes.Where(n => n.Id == currentNode.Right).First();
                    }
                    steps++;

                    if (multi)
                    {
                        if (currentNode.Id.EndsWith('Z'))
                        {
                            exits.Add(steps);
                        }
                    }
                    else
                    {
                        if (currentNode.Id == "ZZZ")
                        {
                            exits.Add(steps);
                            return exits;
                        }
                    }
                }
            } while (exits.Count == 0 || exits.Last() != steps);

            return exits;
        }
    }
}
