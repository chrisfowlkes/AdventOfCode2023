using Classes.Services;
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
            var data = File.ReadAllLines(".\\Data\\2.txt");

            //Act
            var result = AdventOfCodeService.SumPossibleGameIds(data);

            //Assert
            Assert.Equal("8", result);
        }

        /// <summary>
        /// Test for the SumPowers method.
        /// </summary>
        [Fact]
        public void SumPowers()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\2.txt");

            //Act
            var result = AdventOfCodeService.SumPowers(data);

            //Assert
            Assert.Equal("2286", result);
        }

        /// <summary>
        /// Test for the SumEnginePartNumbers method.
        /// </summary>
        [Fact]
        public void SumEnginePartNumbers()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\3.txt");

            //Act
            var result = AdventOfCodeService.SumEnginePartNumbers(data);

            //Assert
            Assert.Equal("4361", result);
        }

        /// <summary>
        /// Test for the SumEngineGearRatios method.
        /// </summary>
        [Fact]
        public void SumEngineGearRatios()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\3.txt");

            //Act
            var result = AdventOfCodeService.SumEngineGearRatios(data);

            //Assert
            Assert.Equal("467835", result);
        }

        /// <summary>
        /// Tests the SumScratchcardPoints method.
        /// </summary>
        [Fact]
        public void SumScratchcardPoints()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\4.txt");

            //Act
            var result = AdventOfCodeService.SumScratchcardPoints(data);

            //Assert
            Assert.Equal("13", result);
        }

        /// <summary>
        /// Tests the CountScratchcardPoints method.
        /// </summary>
        [Fact]
        public void CountScratchcardPoints()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\4.txt");

            //Act
            var result = AdventOfCodeService.CountScratchcards(data);

            //Assert
            Assert.Equal("30", result);
        }

        /// <summary>
        /// Tests the FindClosestSeedLocation method.
        /// </summary>
        /// <param name="expected">Expected result.</param>
        /// <param name="useRange">UseRange flag.</param>
        [Theory]
        [InlineData(false, "35")]
        [InlineData(true, "46")]
        public void FindClosestSeedLocation(bool useRange, string expected)
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\5.txt");

            //Act
            var result = AdventOfCodeService.FindClosestSeedLocation(data, useRange);

            //Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests the CalculateProductOfWaysToWinRaces method.
        /// </summary>
        [Fact]
        public void CalculateProductOfWaysToWinRaces()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\6.txt");

            //Act
            var result = AdventOfCodeService.CalculateProductOfWaysToWinRaces(data);

            //Assert
            Assert.Equal("288", result);
        }

        /// <summary>
        /// Tests the CalculateWaysToWinRace method.
        /// </summary>
        [Fact]
        public void CalculateWaysToWinRace()
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\6.txt");

            //Act
            var result = AdventOfCodeService.CalculateWaysToWinRace(data);

            //Assert
            Assert.Equal("71503", result);
        }

        /// <summary>
        /// Tests the PlayCamelCards method.
        /// </summary>
        /// <param name="wildcard">Wildcard flag.</param>
        /// <param name="expected">Expected result.</param>
        [InlineData(false, "6440")]
        [InlineData(true, "5905")]
        [Theory]
        public void PlayCamelCards(bool wildcard, string expected)
        {
            //Arrange
            var data = File.ReadAllLines(".\\Data\\7.txt");

            //Act
            var result = AdventOfCodeService.PlayCamelCards(data, wildcard);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
