﻿using Classes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services
{
    /// <summary>
    /// Tests for the main application service.
    /// </summary>
    public class AdventOfCodeServiceTests
    {
        /// <summary>
        /// Test for the SumPossibleGameIds method.
        /// </summary>
        [Fact]
        public void SumPossibleGameIds()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\2A.txt");

            //Act
            var result = AdventOfCodeService.SumPossibleGameIds(data);

            //Assert
            Assert.Equal("8", result);
        }
    }
}
