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
        /// Tests the SumExtrapolatedValues method.
        /// </summary>
        [Fact]
        public void SumExtrapolatedValues()
        {
            //Arrange
            var data = File.ReadAllLines(@".\Data\9.txt");
            var report = new OasisReport(data);

            //Act
            var result = report.SumExtrapolatedValues();

            //Assert
            Assert.Equal("114", result);
        }
    }
}
