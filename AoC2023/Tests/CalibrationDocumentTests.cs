using Classes;
using Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    /// <summary>
    /// Tests for the calibration document class.
    /// </summary>
    public class CalibrationDocumentTests
    {
        /// <summary>
        /// Tests the calculate method without transalation.
        /// </summary>
        [Fact]
        public void Calculate_DontTranslate_Calculates()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\1A.txt");
            var c = new CalibrationDocument(data);

            //Act
            var i = c.Calculate();

            //Assert
            Assert.Equal(142, i);
        }

        /// <summary>
        /// Tests the calculate method with transalation.
        /// </summary>
        [Fact]
        public void Calculate_Translate_Calculates()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\1B.txt");
            var c = new CalibrationDocument(data);

            //Act
            var i = c.Calculate(true);

            //Assert
            Assert.Equal(281, i);
        }
    }
}
