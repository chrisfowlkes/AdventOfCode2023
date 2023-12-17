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
        /// <param name="input">Input file.</param>
        /// <param name="multi">Multi flag passed to method.</param>
        /// <param name="expected">Expected value.</param>
        [Theory()]
        [InlineData(".\\Data\\8A.txt", false, "2")]
        [InlineData(".\\Data\\8B.txt", false, "6")]
        [InlineData(".\\Data\\8C.txt", true, "6")]
        public void Navigate(string input, bool multi, string expected)
        {
            //Arrange
            var data = File.ReadAllLines(input);
            var map = new DesertMap(data);

            //Act
            var steps = map.Navigate(multi);

            //Assert
            Assert.Equal(expected, steps);
        }
    }
}
