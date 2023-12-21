using System;
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
        }

        public string CalculateDistanceToFurthestPipe()
        {
            int steps = 0;
            //Trace the pipes from the start.
            if (start != null)
            {
                //Need to analyze the tiles around the start and see which ones connect to it.
                var nextPipes = new List<SurfacePipe>();
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
                                nextPipes.Add(this.pipes[y][x]);
                            }
                        }
                    }
                }

                //Walk through pipes till we get back to the furthest pipe.
                List<SurfacePipe> currentPipes = [start];
                steps++;//Account for the first step.
                while (nextPipes.Select(p => p.Location).Distinct().Count() > 1)
                {
                    var lastLocations = currentPipes.Select(p => p.Location);
                    currentPipes = nextPipes;
                    nextPipes = [];
                    var nextLocations = currentPipes.SelectMany(p => p.GetConnectedLocations()).Where(l => !lastLocations.Contains(l));
                    foreach (var location in nextLocations)
                    {
                        nextPipes.Add(this.pipes[location.Y][location.X]);
                    }
                    steps++;
                }
            }
            return steps.ToString();
        }
    }
}
