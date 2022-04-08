using GameOfLife;
using Xunit;

namespace GameOfLifeTest
{
    public class BoardTest
    {

        private Board board = new Board(10, 10);

        [Theory]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(3, false)]
        public void Determine_ReturnTrue_ValidInput(int count, bool state)
        {
            bool result = board.Determine(count, state);
            Assert.True(result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(1, false)]
        [InlineData(4, true)]
        [InlineData(4, false)]
        [InlineData(8, true)]
        [InlineData(8, false)]
        public void Determine_ReturnFalse_ValidInput(int count, bool state)
        {
            bool result = board.Determine(count, state);
            Assert.False(result);
        }

        [Theory]
        [InlineData(3, 0, 1)]
        [InlineData(0, 1, 2)]
        [InlineData(2, 3, 3)]
        [InlineData(2, 2, 4)]
        
        public void Count_ReturnCorrectCount_ValidInput(int x, int y, int count)
        {
            bool[,] _layout = new bool[5, 5]
            {
                { false, false, false, false, false },
                { false, true, true, true, false},
                { false, false, false, false, false},
                { false, true, false, false, true},
                { false, false, false, true, true}
            };

            Board board = new Board(_layout);
            
            int result = board.Count(x, y);

            Assert.Equal(count, result);

        }
    }
}