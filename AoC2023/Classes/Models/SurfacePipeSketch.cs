using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Models
{
    /// <summary>
    /// Map or sketch of the surface pipes on the metal island.
    /// </summary>
    public class SurfacePipeSketch
    {
        private readonly List<List<SurfacePipe>> pipes = [];
        private readonly SurfacePipe? start;
        private readonly List<SurfacePipe> path = [];

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pipes">Data making up the sketch.</param>
        public SurfacePipeSketch(ICollection<string> pipes)
        {
            //Build the map or sketch.
            int y = 0;
            foreach(var rowData in pipes)
            {
                var row = new List<SurfacePipe>();
                int x = 0;

                foreach(var pipeType in rowData)
                {
                    var pipe = new SurfacePipe(pipeType, x, y);
                    row.Add(pipe);
                    if(pipeType == 'S')
                    {
                        start = pipe;
                    }
                    x++;
                }
                this.pipes.Add(row);
                y++;
            }

            Trace();
        }

        public string CalculateDistanceToFurthestPipe()
        {
            int steps = path.Count / 2;
            return steps.ToString();
        }

        public string CountInternalPoints()
        {
            var count = 0;

            foreach (var row in this.pipes)
            {
                var inside = false;
                foreach (var pipe in row)
                {
                    if (path.Contains(pipe))
                    {
                        if (pipe.PipeType != '-')//This is a continuation of the last threshold.
                        {
                            inside = !inside;
                        }
                    }
                    else
                    {
                        if(inside)
                        {
                            count++;
                        }
                    }
                }
            }

            return count.ToString();
        }

        private void Trace()
        {
            //Trace the pipes from the start.
            if (start != null)
            {
                FindStart();

                //Walk through pipes till we get back to the furthest pipe.
                List<SurfacePipe> currentPipes = [start];
                while (path.Last().GetConnectedLocations().Where(l => path.Select(p => p.Location).Contains(l)).Count() == 1)
                {
                    var next = path.Last().GetConnectedLocations().Where(l => l != path[path.Count-2].Location).Single();
                    path.Add(this.pipes[next.Y][next.X]);
                }
            }
        }

        private void FindStart()
        {
            if(start != null)
            {
                path.Add(this.start);
                //Need to analyze the tiles around the start and see which ones connect to it.
                var minX = Math.Max(0, start.Location.X - 1);
                var maxX = Math.Min(this.pipes[0].Count - 1, start.Location.X + 1);
                var minY = Math.Max(0, start.Location.Y - 1);
                var maxY = Math.Min(this.pipes.Count - 1, start.Location.Y + 1);

                for (int y = minY; y <= maxY; y++)
                {
                    for (int x = minX; x <= maxX; x++)
                    {
                        if (start.Location.X != x || start.Location.Y != y)//Don't check the start tile.
                        {
                            if (this.pipes[y][x].GetConnectedLocations().Where(p => p.X == start.Location.X && p.Y == start.Location.Y).Any())
                            {
                                path.Add(this.pipes[y][x]);
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
