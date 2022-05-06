
namespace GameOfLife
{
    /// <summary>
    /// Interface for board game functionality implementations.
    /// </summary>
    public interface IBoard : IBoardBase
    {
        /// <summary>
        /// Algorithm and flow of the board.
        /// </summary>
        public void Flow();

        /// <summary>
        /// Determines how board is iterated and what is updated.
        /// </summary>
        public void Iterate();

        /// <summary>
        /// Dictates how board is displayed.
        /// </summary>
        public void DisplayBoard();

    }
}
