using System;
using System.Collections.Generic;
using Xunit;

namespace Testing_Poker.Tests
{
    public class PairTests
    {
        public PairTests()
        {
        }

        [Theory]
        [InlineData(
           new string[] { "H2", "C2" },
           new int[] { 2 })
        ]
        public void GetCards_ReturnsListOfKeyValuePairs_EqualingThoseUsedForThePairCreation(
           string[] expectedCards,
           int[] expectedValues)
        {
            {
                // Arrange
                var expectedReturn = new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                };

                var sut = new Pair(
                    new HashSet<KeyValuePair<string, int>> {
                        new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                        new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
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
        public void GetCards_ReturnsNull_WhenPairCreationWasInvalid(
           string[] expectedCards,
           int[] expectedValues)
        {
            {
                // Arrange
                List<KeyValuePair<string, int>>? expectedReturn = null;

                var sut = new Pair(
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
           new string[] { "H2", "C2" },
           new int[] { 2 })
        ]
        public void GetValue_ReturnsIntegerValueOfThePair_WhenUsedOnAValidPair(
           string[] expectedCards,
           int[] expectedValues)
        {
            {
                // Arrange
                var expectedReturn = 4;

                var sut = new Pair(
                    new HashSet<KeyValuePair<string, int>> {
                        new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                        new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
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
        public void GetValue_ReturnsNull_WhenPairCreationWasInvalid(
           string[] expectedCards,
           int[] expectedValues)
        {
            {
                // Arrange
                int? expectedReturn = null;

                var sut = new Pair(
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