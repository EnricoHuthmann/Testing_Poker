using System;
using System.Collections.Generic;
using Xunit;

namespace Testing_Poker.Tests
{
    public class FourOfAKindTests
    {
        public FourOfAKindTests()
        {
        }

        [Theory]
        [InlineData(
           new string[] { "H2", "C2", "D2", "S2" },
           new int[] { 2 })
        ]
        public void GetCards_ReturnsListOfKeyValuePairs_EqualingThoseUsedForTheFourOfAKindCreation(
           string[] expectedCards,
           int[] expectedValues)
        {
            {
                // Arrange
                var expectedReturn = new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0])
                };

                var sut = new FourOfAKind(
                    new HashSet<KeyValuePair<string, int>> {
                        new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                        new KeyValuePair<string, int>(expectedCards[1], expectedValues[0]),
                        new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                        new KeyValuePair<string, int>(expectedCards[3], expectedValues[0])
                    }
                );

                // Act
                var result = sut.GetCards();

                // Assert
                Assert.Equal(expectedReturn, result);
            }
        }

        [Theory]
        [InlineData(
           new string[] { "H2" },
           new int[] { 2 })
        ]
        public void GetCards_ReturnsNull_WhenFourOfAKindCreationWasInvalid(
           string[] expectedCards,
           int[] expectedValues)
        {
            {
                // Arrange
                List<KeyValuePair<string, int>>? expectedReturn = null;

                var sut = new FourOfAKind(
                    new HashSet<KeyValuePair<string, int>> {
                        new KeyValuePair<string, int>(expectedCards[0], expectedValues[0])
                    }
                );

                // Act
                var result = sut.GetCards();

                // Assert
                Assert.Equal(expectedReturn, result);
            }
        }

        [Theory]
        [InlineData(
           new string[] { "H2", "C2", "D2", "S2" },
           new int[] { 2 })
        ]
        public void GetValue_ReturnsIntegerValueOfTheFourOfAKind_WhenUsedOnAValidFourOfAKind(
           string[] expectedCards,
           int[] expectedValues)
        {
            {
                // Arrange
                var expectedReturn = expectedValues[0] * 4;

                var sut = new FourOfAKind(
                    new HashSet<KeyValuePair<string, int>> {
                        new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                        new KeyValuePair<string, int>(expectedCards[1], expectedValues[0]),
                        new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                        new KeyValuePair<string, int>(expectedCards[3], expectedValues[0])
                    }
                );

                // Act
                var result = sut.GetValue();

                // Assert
                Assert.Equal(expectedReturn, result);
            }
        }

        [Theory]
        [InlineData(
           new string[] { "H2" },
           new int[] { 2 })
        ]
        public void GetValue_ReturnsNull_WhenFourOfAKindCreationWasInvalid(
           string[] expectedCards,
           int[] expectedValues)
        {
            {
                // Arrange
                int? expectedReturn = null;

                var sut = new FourOfAKind(
                    new HashSet<KeyValuePair<string, int>> {
                        new KeyValuePair<string, int>(expectedCards[0], expectedValues[0])
                    }
                );

                // Act
                var result = sut.GetValue();

                // Assert
                Assert.Equal(expectedReturn, result);
            }
        }
    }
}
