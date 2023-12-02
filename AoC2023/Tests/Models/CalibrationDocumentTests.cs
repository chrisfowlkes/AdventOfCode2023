using Classes;
using Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    /// <summary>
    /// Tests for the calibration document class.
    /// </summary>
    public class CalibrationDocumentTests
    {
        /// <summary>
        /// Tests the calculate method.
        /// </summary>
        [Theory()]
        [InlineData(".\\Data\\1A.txt", false, 142)]
        [InlineData(".\\Data\\1B.txt", true, 281)]
        public void Calculate_DontTranslate_Calculates(string input, bool translate, int result)
        {
            //Arrange
            var data = File.ReadAllLines(input);
            var c = new CalibrationDocument(data);

            //Act
            var i = c.Calculate(translate);

            //Assert
            Assert.Equal(result, i);
        }
    }
}
