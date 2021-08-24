using System.Collections.Generic;
using Xunit;

namespace Testing_Poker.Tests
{
    public class CardSetTests
    {       

        public CardSetTests()
        {
        }

        [Theory]
        [InlineData(new string[] { }, null)]
        public void GetTwoPairs_ReturnsNull_WhenNoCardsAreGiven(
            string[] givenCards, 
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "" }, null)]
        public void GetTwoPairs_ReturnsNull_WhenAnEmptyCardIsGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "", "" }, null)]
        public void GetTwoPairs_ReturnsNull_WhenDuplicateEmptyCardsAreGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "   " }, null)]
        public void GetTwoPairs_ReturnsNull_WhenAWhitespaceCardIsGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "   ", "   " }, null)]
        public void GetTwoPairs_ReturnsNull_WhenDuplicateWhitespaceCardsAreGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "Not a Card" }, null)]
        public void GetTwoPairs_ReturnsNull_WhenNonsenseIsGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "Not a Card", "Not a Card" }, null)]
        public void GetTwoPairs_ReturnsNull_WhenDuplicateNonsenseIsGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }
         
        [Theory]
        [InlineData(new string[] { "H2" }, null)]
        public void GetTwoPairs_ReturnsNull_WhenNoPairIsGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "C2" },
            new string[] { "H2", "C2" },
            new int[] { 2, 2 }
        )]
        public void GetTwoPairs_ReturnsListOfPairs_HoldingOnePair_WhenOnePairIsGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Pair expectedPair = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[1])
                });

            List<Pair>? listOfExpectedPairs = new()
            {
                expectedPair
            };

            var expectedReturn = listOfExpectedPairs;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
            [InlineData(
            new string[] { "H3", "C3", "SA" },
            new string[] { "H3", "C3" },
            new int[] { 3, 3 }
        )]
        public void GetTwoPairs_ReturnsListOfPairs_HoldingOnePair_WhenCardsIncludingOnePairAreGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Pair expectedPair = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[1])
                });

            List<Pair>? listOfExpectedPairs = new()
            {
                expectedPair
            };

            var expectedReturn = listOfExpectedPairs;

            var sut = new CardSet(givenCards);
            
            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "H2", "C8", "SA" }, null)]
        public void GetTwoPairs_ReturnsNull_WhenCardsWithoutOnePairAreGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "C2", "SA", "DA" },
            new string[] { "H2", "C2", "SA", "DA" },
            new int[] { 2, 2, 14, 14}
        )]
        public void GetTwoPairs_ReturnsListOfPairs_HoldingTwoPairs_WhenTwoPairsAreGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Pair expectedPair1 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[1])
                });
            Pair expectedPair2 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[2]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[3])
                });

            List<Pair>? listOfExpectedPairs = new()
            {
                expectedPair1,
                expectedPair2
            };

            var expectedReturn = listOfExpectedPairs;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "H9", "SA", "C2", "SA", "D8", "DA" },
            new string[] { "H2", "C2", "SA", "DA" },
            new int[] { 2, 2, 14, 14 }
        )]
        public void GetTwoPairs_ReturnsListOfPairs_HoldingTwoPairs_WhenCardsIncludingTwoPairsAreGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Pair expectedPair1 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[1])
                });
            Pair expectedPair2 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[2]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[3])
                });

            List<Pair>? listOfExpectedPairs = new()
            {
                expectedPair1,
                expectedPair2
            };

            var expectedReturn = listOfExpectedPairs;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetTwoPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }
    }
}
