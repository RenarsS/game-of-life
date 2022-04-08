using GameOfLife;
using Xunit;

namespace GameOfLifeTest
{
    public class ValidationTest
    {
        [Theory]
        [InlineData("1")]
        [InlineData("78")]
        [InlineData("100")]
        public void ValidateNaturalNum_ReturnTrue_ValidNumChars(string str)
        {
            bool result = Validation.ValidateNaturalNum(str);

            Assert.True(result);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("-1")]
        [InlineData("-10")]
        [InlineData("1.92")]
        [InlineData("-10.7")]
        public void ValidateNaturalNum_ReturnFalse_InvalidNumChars(string str)
        {
            bool result = Validation.ValidateNaturalNum(str);

            Assert.False(result);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("Z")]
        [InlineData("43dg")]
        [InlineData("s09c")]
        [InlineData("_")]
        [InlineData("128%kda")]
        public void ValidateNaturalNum_ReturnFalse_NonNumChars(string str)
        {
            bool result = Validation.ValidateNaturalNum(str);

            Assert.False(result);
        }
    }
}
