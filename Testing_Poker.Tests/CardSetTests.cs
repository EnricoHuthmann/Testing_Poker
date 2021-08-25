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
        public void GetPairs_ReturnsNull_WhenNoCardsAreGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "" }, null)]
        public void GetPairs_ReturnsNull_WhenAnEmptyCardIsGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "", "" }, null)]
        public void GetPairs_ReturnsNull_WhenDuplicateEmptyCardsAreGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "   " }, null)]
        public void GetPairs_ReturnsNull_WhenAWhitespaceCardIsGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "   ", "   " }, null)]
        public void GetPairs_ReturnsNull_WhenDuplicateWhitespaceCardsAreGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "Not a Card" }, null)]
        public void GetPairs_ReturnsNull_WhenNonsenseIsGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "Not a Card", "Not a Card" }, null)]
        public void GetPairs_ReturnsNull_WhenDuplicateNonsenseIsGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "H2" }, null)]
        public void GetPairs_ReturnsNull_WhenNoPairIsGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "C2" },
            new string[] { "H2", "C2" },
            new int[] { 2, 2 }
        )]
        public void GetPairs_ReturnsListOfPairs_HoldingOnePair_WhenOnePairIsGiven(
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
            var result = sut.GetPairs();

            // Assert
            for (int i = 0; i < listOfExpectedPairs.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(
            new string[] { "H3", "C3", "SA" },
            new string[] { "H3", "C3" },
            new int[] { 3, 3 }
        )]
        public void GetPairs_ReturnsListOfPairs_HoldingOnePair_WhenCardsIncludingOnePairAreGiven(
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
            var result = sut.GetPairs();

            // Assert
            for (int i = 0; i < listOfExpectedPairs.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(new string[] { "H2", "C8", "SA" }, null)]
        public void GetPairs_ReturnsNull_WhenCardsWithoutOnePairAreGiven(
            string[] givenCards,
            List<Pair>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetPairs();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "C2", "SA", "DA" },
            new string[] { "H2", "C2", "SA", "DA" },
            new int[] { 2, 2, 14, 14 }
        )]
        public void GetPairs_ReturnsListOfPairs_HoldingTwoPairs_WhenTwoPairsAreGiven(
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
            var result = sut.GetPairs();

            // Assert
            for (int i = 0; i < listOfExpectedPairs.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "H9", "SA", "C2", "D8", "DA" },
            new string[] { "H2", "C2", "SA", "DA" },
            new int[] { 2, 2, 14, 14 }
        )]
        public void GetPairs_ReturnsListOfPairs_HoldingTwoPairs_WhenCardsIncludingTwoPairsAreGiven(
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
            var result = sut.GetPairs();

            // Assert
            for (int i = 0; i < listOfExpectedPairs.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "H9", "SA", "C2", "D2" },
            new string[] { "H2", "C2", "D2" },
            new int[] { 2 }
        )]
        public void GetPairs_ReturnsListOfPairs_HoldingThreePairs_WhenThreeCardsOfTheSameValueAreGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Pair expectedPair1 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0])
                }
            );
            Pair expectedPair2 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                }
            );
            Pair expectedPair3 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0])
                }
            );

            List<Pair>? listOfExpectedPairs = new()
            {
                expectedPair1,
                expectedPair2,
                expectedPair3
            };

            var expectedReturn = listOfExpectedPairs;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetPairs();

            // Assert
            for (int i = 0; i < listOfExpectedPairs.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }
    }
}
