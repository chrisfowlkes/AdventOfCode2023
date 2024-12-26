using Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    /// <summary>
    /// Tests for the surface pipe sketch.
    /// </summary>
    public class SurfacePipeSketchTests
    {
        /// <summary>
        /// Tests the method that calculates distance to furthest pipe.
        /// </summary>
        /// <param name="fileName">Input file.</param>
        /// <param name="expected">Expected value.</param>
        [InlineData(@".\Data\10A.txt", "4")]
        [InlineData(@".\Data\10B.txt", "8")]
        [Theory]
        public void CalculateDistanceToFurthestPipe(string fileName, string expected)
        {
            //Arrange
            var data = File.ReadAllLines(fileName);
            var sketch = new SurfacePipeSketch(data);

            //Act
            var result = sketch.CalculateDistanceToFurthestPipe();

            //Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests the method that calculates distance to furthest pipe.
        /// </summary>
        /// <param name="fileName">Input file.</param>
        /// <param name="expected">Expected value.</param>
        [InlineData(@".\Data\10C.txt", "4")]
        [Theory]
        public void CountInternalPoints(string fileName, string expected)
        {
            //Arrange
            var data = File.ReadAllLines(fileName);
            var sketch = new SurfacePipeSketch(data);

            //Act
            var result = sketch.CountInternalPoints();

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
