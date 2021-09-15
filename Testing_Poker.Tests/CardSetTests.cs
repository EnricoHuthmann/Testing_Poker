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
            List<Multiple>? expectedReturn)
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
            List<Multiple>? expectedReturn)
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
            List<Multiple>? expectedReturn)
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
            List<Multiple>? expectedReturn)
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
            List<Multiple>? expectedReturn)
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
            List<Multiple>? expectedReturn)
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
            List<Multiple>? expectedReturn)
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
            List<Multiple>? expectedReturn)
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
            Multiple expectedPair = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[1])
                });

            List<Multiple>? listOfExpectedPairs = new()
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
            Multiple expectedPair = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[1])
                });

            List<Multiple>? listOfExpectedPairs = new()
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
            List<Multiple>? expectedReturn)
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
            Multiple expectedPair1 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[1])
                });
            Multiple expectedPair2 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[2]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[3])
                });

            List<Multiple>? listOfExpectedPairs = new()
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
            Multiple expectedPair1 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[1])
                });
            Multiple expectedPair2 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[2]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[3])
                });

            List<Multiple>? listOfExpectedPairs = new()
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
            Multiple expectedPair1 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0])
                }
            );
            Multiple expectedPair2 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                }
            );
            Multiple expectedPair3 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0])
                }
            );

            List<Multiple>? listOfExpectedPairs = new()
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

        //
        // Three of a kind
        //

        [Theory]
        [InlineData(new string[] { }, null)]
        public void GetThreeOfAKind_ReturnsNull_WhenNoCardsAreGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "" }, null)]
        public void GetThreeOfAKind_ReturnsNull_WhenAnEmptyCardIsGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "", "", "" }, null)]
        public void GetThreeOfAKind_ReturnsNull_WhenMultipleEmptyCardsAreGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "   " }, null)]
        public void GetThreeOfAKind_ReturnsNull_WhenAWhitespaceCardIsGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "   ", "   ", "   " }, null)]
        public void GetThreeOfAKind_ReturnsNull_WhenMultipleWhitespaceCardsAreGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "Not a Card" }, null)]
        public void GetThreeOfAKind_ReturnsNull_WhenNonsenseIsGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "Not a Card", "Not a Card", "Not a Card" }, null)]
        public void GetThreeOfAKind_ReturnsNull_WhenMultipleNonsenseIsGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "H2" }, null)]
        public void GetThreeOfAKind_ReturnsNull_WhenNoThreeOfAKindIsGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "C2", "S2" },
            new string[] { "H2", "C2", "S2" },
            new int[] { 2 }
        )]
        public void GetThreeOfAKind_ReturnsListOfThreeOfAKind_HoldingOneThreeOfAKind_WhenOneThreeOfAKindIsGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Multiple expectedThreeOfAKind = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                });

            List<Multiple>? listOfExpectedThreeOfAKind = new()
            {
                expectedThreeOfAKind
            };

            var expectedReturn = listOfExpectedThreeOfAKind;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            for (int i = 0; i < listOfExpectedThreeOfAKind.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(
            new string[] { "H3", "C3", "SA", "S3" },
            new string[] { "H3", "C3", "S3" },
            new int[] { 3 }
        )]
        public void GetThreeOfAKind_ReturnsListOfThreeOfAKind_HoldingOneThreeOfAKind_WhenCardsIncludingOneThreeOfAKindAreGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Multiple expectedThreeOfAKind = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                });

            List<Multiple>? listOfExpectedThreeOfAKind = new()
            {
                expectedThreeOfAKind
            };

            var expectedReturn = listOfExpectedThreeOfAKind;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            for (int i = 0; i < listOfExpectedThreeOfAKind.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(new string[] { "H2", "C8", "SA" }, null)]
        public void GetThreeOfAKind_ReturnsNull_WhenCardsWithoutOneThreeOfAKindAreGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "C2", "S2", "HA", "SA", "DA" },
            new string[] { "H2", "C2", "S2", "HA", "SA", "DA" },
            new int[] { 2, 14 }
        )]
        public void GetThreeOfAKind_ReturnsListOfThreeOfAKind_HoldingTwoThreeOfAKind_WhenTwoThreeOfAKindAreGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Multiple expectedThreeOfAKind1 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                });
            Multiple expectedThreeOfAKind2 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[1]),
                    new KeyValuePair<string, int>(expectedCards[5], expectedValues[1]),
                    new KeyValuePair<string, int>(expectedCards[4], expectedValues[1])
                });

            List<Multiple>? listOfExpectedThreeOfAKind = new()
            {
                expectedThreeOfAKind1,
                expectedThreeOfAKind2
            };

            var expectedReturn = listOfExpectedThreeOfAKind;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            for (int i = 0; i < listOfExpectedThreeOfAKind.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "H9", "SA", "C2", "D8", "DA", "S2", "HA" },
            new string[] { "H2", "C2", "S2", "SA", "DA", "HA" },
            new int[] { 2, 14 }
        )]
        public void GetThreeOfAKind_ReturnsListOfThreeOfAKind_HoldingTwoThreeOfAKind_WhenCardsIncludingTwoThreeOfAKindAreGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Multiple expectedThreeOfAKind1 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                });
            Multiple expectedThreeOfAKind2 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[1]),
                    new KeyValuePair<string, int>(expectedCards[5], expectedValues[1]),
                    new KeyValuePair<string, int>(expectedCards[4], expectedValues[1])
                });

            List<Multiple>? listOfExpectedThreeOfAKind = new()
            {
                expectedThreeOfAKind1,
                expectedThreeOfAKind2
            };

            var expectedReturn = listOfExpectedThreeOfAKind;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            for (int i = 0; i < listOfExpectedThreeOfAKind.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "H9", "S2", "SA", "C2", "D2" },
            new string[] { "H2", "S2", "C2", "D2" },
            new int[] { 2 }
        )]
        public void GetThreeOfAKind_ReturnsListOfThreeOfAKind_HoldingFourThreeOfAKind_WhenFourCardsOfTheSameValueAreGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Multiple expectedThreeOfAKind1 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                }
            );
            Multiple expectedThreeOfAKind2 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0])
                }
            );
            Multiple expectedThreeOfAKind3 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                }
            );
            Multiple expectedThreeOfAKind4 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0])
                }
            );

            List<Multiple>? listOfExpectedThreeOfAKind = new()
            {
                expectedThreeOfAKind1,
                expectedThreeOfAKind2,
                expectedThreeOfAKind3,
                expectedThreeOfAKind4
            };

            var expectedReturn = listOfExpectedThreeOfAKind;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetThreeOfAKind();

            // Assert
            for (int i = 0; i < listOfExpectedThreeOfAKind.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        //
        // Four of a kind
        //

        [Theory]
        [InlineData(new string[] { }, null)]
        public void GetFourOfAKind_ReturnsNull_WhenNoCardsAreGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "" }, null)]
        public void GetFourOfAKind_ReturnsNull_WhenAnEmptyCardIsGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "", "", "", "" }, null)]
        public void GetFourOfAKind_ReturnsNull_WhenMultipleEmptyCardsAreGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "   " }, null)]
        public void GetFourOfAKind_ReturnsNull_WhenAWhitespaceCardIsGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "   ", "   ", "   ", "   " }, null)]
        public void GetFourOfAKind_ReturnsNull_WhenMultipleWhitespaceCardsAreGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "Not a Card" }, null)]
        public void GetFourOfAKind_ReturnsNull_WhenNonsenseIsGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "Not a Card", "Not a Card", "Not a Card", "Not a Card" }, null)]
        public void GetFourOfAKind_ReturnsNull_WhenMultipleNonsenseIsGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(new string[] { "H2" }, null)]
        public void GetFourOfAKind_ReturnsNull_WhenNoFourOfAKindIsGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "C2", "S2", "D2" },
            new string[] { "H2", "C2", "S2", "D2" },
            new int[] { 2 }
        )]
        public void GetFourOfAKind_ReturnsListOfFourOfAKind_HoldingOneFourOfAKind_WhenOneFourOfAKindIsGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Multiple expectedFourOfAKind = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                });

            List<Multiple>? listOfExpectedFourOfAKind = new()
            {
                expectedFourOfAKind
            };

            var expectedReturn = listOfExpectedFourOfAKind;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            for (int i = 0; i < listOfExpectedFourOfAKind.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(
            new string[] { "H3", "C3", "SA", "S3", "DA", "D3" },
            new string[] { "H3", "C3", "S3", "D3" },
            new int[] { 3 }
        )]
        public void GetFourOfAKind_ReturnsListOfFourOfAKind_HoldingOneFourOfAKind_WhenCardsIncludingOneThreeOfAKindAreGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Multiple expectedFourOfAKind = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                });

            List<Multiple>? listOfExpectedFourOfAKind = new()
            {
                expectedFourOfAKind
            };

            var expectedReturn = listOfExpectedFourOfAKind;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            for (int i = 0; i < listOfExpectedFourOfAKind.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(new string[] { "H2", "C8", "SA", "D3" }, null)]
        public void GetFourOfAKind_ReturnsNull_WhenCardsWithoutOneFourOfAKindAreGiven(
            string[] givenCards,
            List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            Assert.Equal(expectedReturn, result);
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "C2", "S2", "HA", "SA", "DA", "D2", "CA" },
            new string[] { "H2", "C2", "S2", "D2", "HA", "SA", "DA", "CA" },
            new int[] { 2, 14 }
        )]
        public void GetFourOfAKind_ReturnsListOfFourOfAKind_HoldingTwoFourOfAKind_WhenTwoFourOfAKindAreGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Multiple expectedFourOfAKind1 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                });
            Multiple expectedFourOfAKind2 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[4], expectedValues[1]),
                    new KeyValuePair<string, int>(expectedCards[7], expectedValues[1]),
                    new KeyValuePair<string, int>(expectedCards[6], expectedValues[1]),
                    new KeyValuePair<string, int>(expectedCards[5], expectedValues[1])
                });

            List<Multiple>? listOfExpectedFourOfAKind = new()
            {
                expectedFourOfAKind1,
                expectedFourOfAKind2
            };

            var expectedReturn = listOfExpectedFourOfAKind;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            for (int i = 0; i < listOfExpectedFourOfAKind.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "H9", "SA", "C2", "D8", "DA", "S2", "HA", "D2", "CA" },
            new string[] { "H2", "C2", "S2", "D2", "SA", "DA", "HA", "CA" },
            new int[] { 2, 14 }
        )]
        public void GetFourOfAKind_ReturnsListOfFourOfAKind_HoldingTwoFourOfAKind_WhenCardsIncludingTwoFourOfAKindAreGiven(
            string[] givenCards,
            string[] expectedCards,
            int[] expectedValues)
        {
            // Arrange
            Multiple expectedFourOfAKind1 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                });
            Multiple expectedFourOfAKind2 = new(
                new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[4], expectedValues[1]),
                    new KeyValuePair<string, int>(expectedCards[7], expectedValues[1]),
                    new KeyValuePair<string, int>(expectedCards[6], expectedValues[1]),
                    new KeyValuePair<string, int>(expectedCards[5], expectedValues[1])
                });

            List<Multiple>? listOfExpectedFourOfAKind = new()
            {
                expectedFourOfAKind1,
                expectedFourOfAKind2
            };

            var expectedReturn = listOfExpectedFourOfAKind;

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFourOfAKind();

            // Assert
            for (int i = 0; i < listOfExpectedFourOfAKind.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        //
        // Multiples Tests
        //

        [Theory]
        [InlineData(new string[] { }, null)]
        public void GetMultiples_ReturnsNull_WhenNoCardsAreGiven(string[] givenCards, List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetMultiples();

            // Assert
            Assert.Equal(result, expectedReturn);
        }

        [Theory]
        [InlineData(new string[] { "H2", "C3", "CA" }, null)]
        public void GetMultiples_ReturnsNull_WhenNoPairIsGiven(string[] givenCards, List<Multiple>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetMultiples();

            // Assert
            Assert.Equal(result, expectedReturn);
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "C2", "CA" },
            new string[] { "H2", "C2" },
            new int[] { 2 }
        )]
        public void GetMultiples_ReturnsListOfMultiples_WhenAPairIsGiven(string[] givenCards, string[] expectedCards, int[] expectedValues)
        {
            // Arrange
            Multiple expectedPair = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                 });

            List<Multiple> expectedReturn = new()
            {
                expectedPair
            };

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetMultiples();

            // Assert
            for (int i = 0; i < expectedReturn.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "C2", "D2", "SA" },
            new string[] { "H2", "C2", "D2" },
            new int[] { 2 }
        )]
        public void GetMultiples_ReturnsListOfMultiples_WhenAThreeOfAKindIsGiven(string[] givenCards, string[] expectedCards, int[] expectedValues)
        {
            // Arrange
            Multiple expectedThreeOfAKind = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                 });
            Multiple expectedPair1 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0])
                 });
            Multiple expectedPair2 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                 });
            Multiple expectedPair3 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0])
                 });

            List<Multiple> expectedReturn = new()
            {
                expectedThreeOfAKind,
                expectedPair1,
                expectedPair2,
                expectedPair3
            };

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetMultiples();

            // Assert
            for (int i = 0; i < expectedReturn.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "C2", "D2", "SA", "S2" },
            new string[] { "H2", "C2", "D2", "S2" },
            new int[] { 2 }
        )]
        public void GetMultiples_ReturnsListOfMultiples_WhenAFourOfAKindIsGiven(string[] givenCards, string[] expectedCards, int[] expectedValues)
        {
            // Arrange
            Multiple expectedFourOfAKind = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                 });
            Multiple expectedThreeOfAKind1 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                 });
            Multiple expectedThreeOfAKind2 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0])
                 });
            Multiple expectedThreeOfAKind3 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                 });
            Multiple expectedThreeOfAKind4 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0])
                 });
            Multiple expectedPair1 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0])
                 });
            Multiple expectedPair2 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0])
                 });
            Multiple expectedPair3 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                 });
            Multiple expectedPair4 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0])
                 });
            Multiple expectedPair5 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0])
                 });
            Multiple expectedPair6 = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[0])
                 });

            List<Multiple> expectedReturn = new()
            {
                expectedFourOfAKind,
                expectedThreeOfAKind1,
                expectedThreeOfAKind2,
                expectedThreeOfAKind3,
                expectedThreeOfAKind4,
                expectedPair1,
                expectedPair2,
                expectedPair3,
                expectedPair4,
                expectedPair5,
                expectedPair6
            };

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetMultiples();

            // Assert
            for (int i = 0; i < expectedReturn.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }

        //
        // FullHouse Tests
        //

        [Theory]
        [InlineData(new string[] { }, null)]
        public void GetFullHouse_ReturnsNull_WhenNoCardsAreGiven(string[] givenCards, List<FullHouse>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFullHouse();

            // Assert
            Assert.Equal(result, expectedReturn);
        }

        [Theory]
        [InlineData(new string[] { "H2", "C3", "CA", "C2", "D2" }, null)]
        public void GetFullHouse_ReturnsNull_WhenAThreeOfAKindIsGiven_ButNoExtraPairIsGiven(string[] givenCards, List<FullHouse>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFullHouse();

            // Assert
            Assert.Equal(result, expectedReturn);
        }

        [Theory]
        [InlineData(new string[] { "H2", "C3", "CA", "D2" }, null)]
        public void GetFullHouse_ReturnsNull_WhenAPairIsGiven_ButNoExtraThreeOfAKindIsGiven(string[] givenCards, List<FullHouse>? expectedReturn)
        {
            // Arrange
            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFullHouse();

            // Assert
            Assert.Equal(result, expectedReturn);
        }

        [Theory]
        [InlineData(
            new string[] { "H2", "C2", "CA", "D2", "DA" },
            new string[] { "H2", "C2", "D2", "CA", "DA" },
            new int[] { 2, 14 }
        )]
        public void GetFullHouse_ReturnsListOfFullHouses_WhenAFullHouseIsGiven(string[] givenCards, string[] expectedCards, int[] expectedValues)
        {
            // Arrange
            Multiple expectedThreeOfAKind = new(
                new HashSet<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>(expectedCards[0], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[2], expectedValues[0]),
                    new KeyValuePair<string, int>(expectedCards[1], expectedValues[0])
                });

            Multiple expectedPair = new(
                 new HashSet<KeyValuePair<string, int>> {
                    new KeyValuePair<string, int>(expectedCards[3], expectedValues[1]),
                    new KeyValuePair<string, int>(expectedCards[4], expectedValues[1])
                 });

            List<FullHouse> expectedReturn = new()
            {
                new FullHouse(expectedThreeOfAKind, expectedPair)
            };

            var sut = new CardSet(givenCards);

            // Act
            var result = sut.GetFullHouse();

            // Assert
            for (int i = 0; i < expectedReturn.Count; i++)
            {
                Assert.Equal(expectedReturn[i].GetCards(), result[i].GetCards());
                Assert.Equal(expectedReturn[i].GetValue(), result[i].GetValue());
            }
        }
    }
}