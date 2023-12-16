using Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    /// <summary>
    /// Tests for the DesertMap class.
    /// </summary>
    public class DesertMapTests
    {
        /// <summary>
        /// Tests the navigate method.
        /// </summary>
        [Theory()]
        [InlineData(".\\Data\\8A.txt", "2")]
        [InlineData(".\\Data\\8B.txt", "6")]
        public void Navigate(string input, string expected)
        {
            //Arrange
            var data = File.ReadAllLines(input);
            var map = new DesertMap(data);

            //Act
            var steps = map.Navigate();

            //Assert
            Assert.Equal(expected, steps);
        }
    }
}
