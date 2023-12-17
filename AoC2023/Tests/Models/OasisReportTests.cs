using Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tests.Models
{
    /// <summary>
    /// Tests for the OASIS report.
    /// </summary>
    public class OasisReportTests
    {
        /// <summary>
        /// Tests the SumExtrapolatedNextValues method.
        /// </summary>
        [Fact]
        public void SumExtrapolatedNextValues()
        {
            //Arrange
            var data = File.ReadAllLines(@".\Data\9.txt");
            var report = new OasisReport(data);

            //Act
            var result = report.SumExtrapolatedNextValues();

            //Assert
            Assert.Equal("114", result);
        }

        /// <summary>
        /// Tests the SumExtrapolatedPreviousValues method.
        /// </summary>
        [Fact]
        public void SumExtrapolatedPreviousValues()
        {
            //Arrange
            var data = File.ReadAllLines(@".\Data\9.txt");
            var report = new OasisReport(data);

            //Act
            var result = report.SumExtrapolatedPreviousValues();

            //Assert
            Assert.Equal("2", result);
        }
    }
}
