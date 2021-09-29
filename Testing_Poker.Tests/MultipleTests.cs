using System;
using System.Collections.Generic;
using Xunit;

namespace Testing_Poker.Tests
{
    public class MultipleTests
    {
        public MultipleTests()
        {
        }

        [Theory]
        [InlineData(
            new string[] { "H3" },
            new int[] { 3 },
            null
        )]
        public void GetCards_ReturnsNull_WhenOnlyOneCardIsGiven(string[] givenCards, int[] givenValues, List<KeyValuePair<string, int>>? expectedReturn )
        {
            // Arrange
            var hashSetOfGivenCards = new HashSet<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>(givenCards[0], givenValues[0])
            };

            var sut = new Multiple(hashSetOfGivenCards);

            // Act
            var result = sut.GetCards();

            // Assert
            Assert.Equal(expectedReturn, result);
        }
    }
}
