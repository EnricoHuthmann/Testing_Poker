using System;
using Xunit;

namespace Testing_Poker.Tests
{
    public class InputValidatorTests
    {
        public InputValidatorTests()
        {
        }

        [Theory]
        [InlineData("", false)]
        public void CheckInput_ReturnsFalse_WhenInputIsEmpty(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("   ", false)]
        public void CheckInput_ReturnsFalse_WhenInputIsAWhitespaceOnlyString(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("NonCardInput", false)]
        public void CheckInput_ReturnsFalse_WhenInputIsNotACard(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("H2", false)]
        public void CheckInput_ReturnsFalse_WhenInputIsNotInASet(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("[DX]", false)]
        public void CheckInput_ReturnsFalse_WhenInputIsLessCardsThanMinAmountOfCards(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("[DX, H2]", false)]
        public void CheckInput_ReturnsFalse_WhenInputIsLessCardsThanSpecifiedMinAmountOfCards(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData, minAmountOfCards: 3);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("[DX, H2, CJ]", true)]
        public void CheckInput_ReturnsTrue_WhenInputIsEqualAmountOfCardsToSpecifiedMinAmountOfCards(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData, minAmountOfCards: 3);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("[H2, DX, CJ, SA, H5, DQ, CA, HA]", false)]
        public void CheckInput_ReturnsFalse_WhenInputIsMoreCardsThanMaxAmountOfCards(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("[H2, DX, CJ, SA, H5, DQ, CA, HA, CQ]", false)]
        public void CheckInput_ReturnsFalse_WhenInputIsMoreCardsThanSpecifiedMaxAmountOfCards(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData, maxAmountOfCards: 8);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("[H2, DX, CJ, SA, H5, DQ, CA, HA]", true)]
        public void CheckInput_ReturnsTrue_WhenInputIsEqualAmountOfCardsToSpecifiedMaxAmountOfCards(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData, maxAmountOfCards: 8);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("[H2, DX, CJ]", false)]
        public void CheckInput_ReturnsFalse_WhenInputIsLessCardsThanSpecified_AndMinAndMaxAmountOfCardsAreTheSame(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData, minAmountOfCards: 4, maxAmountOfCards: 4);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("[H2, DX, CJ, SA, H5]", false)]
        public void CheckInput_ReturnsFalse_WhenInputIsMoreCardsThanSpecified_AndMinAndMaxAmountOfCardsAreTheSame(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData, minAmountOfCards: 4, maxAmountOfCards: 4);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("[H2, DX, CJ, SA]", true)]
        public void CheckInput_ReturnsTrue_WhenInputIsEqualAmountOfCardsToSpecified_AndMinAndMaxAmountOfCardsAreTheSame(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData, minAmountOfCards: 4, maxAmountOfCards: 4);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("[H2, DX, CJ, SA, HH]", false)]
        public void CheckInput_ReturnsFalse_WhenInputContainsANonCardString(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("[H2, DX, CJ, SA, H5, DQ, SA]", false)]
        public void CheckInput_ReturnsFalse_WhenInputSetOfCardsContainsDuplicates(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData);

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData("[H2, DX, CJ, SA, H5]", true)]
        public void CheckInput_ReturnsTrue_WhenInputIsAValidSetOfCards(string inputData, bool expectedReturn)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            var result = sut.CheckInput(inputData);

            // Assert
            Assert.Equal(expectedReturn, result);
        }
    }
}