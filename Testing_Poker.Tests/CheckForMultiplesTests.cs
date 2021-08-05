using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing_Poker.Tests
{
    public class CheckForMultiplesTests
    {
        public CheckForMultiplesTests()
        {
        }

        [Theory]
        [InlineData(new object[] { new string[] { "H2" }, false })]
        public void CheckForTwoPair_ReturnsFalse_WhenNoPairIsGiven(string[] givenCards, bool expectedResult)
        {
            
        }
    }
}
