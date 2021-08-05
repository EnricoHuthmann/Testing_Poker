using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing_Poker.Tests
{
    public class CardSetTests
    {
        public CardSetTests()
        {
        }

        //CheckForTwoPair Tests

        [Theory]
        [InlineData(new object[] { new string[] { }, false })]
        public void CheckForTwoPair_ReturnsFalse_WhenNoCardsAreGiven(string[] givenCards, bool expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.CheckForTwoPair();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "" }, false })]
        public void CheckForTwoPair_ReturnsFalse_WhenAnEmptyCardIsGiven(string[] givenCards, bool expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.CheckForTwoPair();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "", "" }, false })]
        public void CheckForTwoPair_ReturnsFalse_WhenDuplicateEmptyCardsAreGiven(string[] givenCards, bool expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.CheckForTwoPair();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "   " }, false })]
        public void CheckForTwoPair_ReturnsFalse_WhenAWhitespaceCardIsGiven(string[] givenCards, bool expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.CheckForTwoPair();

            // Assert
            Assert.Equal(expectedReturn, result);
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "   ", "   " }, false })]
        public void CheckForTwoPair_ReturnsFalse_WhenDuplicateWhitespaceCardsAreGiven(string[] givenCards, bool expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.CheckForTwoPair();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "Not a Card" }, false })]
        public void CheckForTwoPair_ReturnsFalse_WhenNonsenseIsGiven(string[] givenCards, bool expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.CheckForTwoPair();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "Not a Card", "Not a Card" }, false })]
        public void CheckForTwoPair_ReturnsFalse_WhenDuplicateNonsenseIsGiven(string[] givenCards, bool expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.CheckForTwoPair();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "H2" }, false })]
        public void CheckForTwoPair_ReturnsFalse_WhenNoPairIsGiven(string[] givenCards, bool expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.CheckForTwoPair();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "H2", "C2" }, true })]
        public void CheckForTwoPair_ReturnsTrue_WhenOnePairIsGiven(string[] givenCards, bool expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.CheckForTwoPair();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "H2", "C2", "SA" }, true })]
        public void CheckForTwoPair_ReturnsTrue_WhenCardsIncludingOnePairAreGiven(string[] givenCards, bool expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);
            
            // Act
            var result = sut.CheckForTwoPair();

            // Assert
            Assert.Equal(expectedReturn, result);
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "H2", "C8", "SA" }, false })]
        public void CheckForTwoPair_ReturnsFalse_WhenCardsWithoutOnePairAreGiven(string[] givenCards, bool expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.CheckForTwoPair();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "H2", "C2", "SA", "DA" }, true })]
        public void CheckForTwoPair_ReturnsTrue_WhenCardsWithTwoPairsAreGiven(string[] givenCards, bool expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.CheckForTwoPair();

            // Assert
            Assert.Equal(expectedReturn, result);
        }
    }
}
